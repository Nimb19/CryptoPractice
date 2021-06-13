using System;
using System.Numerics;
using System.Linq;
using CryptoFormulaLibrary.EDS;
using CryptoFormulaLibrary.EDS.EDSModels;

namespace CryptoFormulaLibrary.ChatController
{
    public class ChatController<TSub> 
        where TSub : IEDSSubscriber
    {
        public TSub Subscriber { get; }
        public event EventHandler<MessageEventArgs<TSub>> OnNewMessage;
        public event EventHandler<string> OnNewInfo;

        private const string DateTimeFormat = "g";

        public ChatController(TSub sub, EventHandler<MessageEventArgs<TSub>> onNewMessage = null, EventHandler<string> onNewInfo = null)
        {
            Subscriber = sub;

            if (onNewMessage != null)
                OnNewMessage += onNewMessage;
            if (onNewInfo != null)
                OnNewInfo += onNewInfo;
        }

        public void WriteMessageTo(ChatController<TSub> recipientChatController, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;
            if (recipientChatController == null)
                throw new ArgumentNullException($"{nameof(recipientChatController)} не должен быть равен NULL");

            var encryptedHashResults = Subscriber.Controller.EncryptHashCode(GetHash(message), recipientChatController.Subscriber.OpenedKey);
            var msgArgs = new MessageEventArgs<TSub>(message, Subscriber, recipientChatController.Subscriber, encryptedHashResults);
            
            recipientChatController.WriteReceivedMessage(msgArgs);
            WriteMessage(msgArgs);
        }

        private void WriteReceivedMessage(MessageEventArgs<TSub> msgArgs)
        {
            var isVerified = msgArgs.To.Controller.DecryptHashCode(msgArgs.ResultOfEncryptionHash);

            if (isVerified)
                WriteInfo($"Сообщение не было изменено");
            else
                WriteInfo($"Сообщение было изменено");

            WriteMessage(msgArgs);
        }

        private BigInteger GetHash(string message)
        {
            char[] mess = message.ToCharArray();
            return mess.Select(x => (int)x).Aggregate((x, y) => x + y);
        }

        public void WriteInfo(string info, bool showDate = false)
        {
            if (string.IsNullOrWhiteSpace(info))
                return;

            string text;

            if (showDate)
                text = $"{GetDateTime()} {info}{Environment.NewLine}";
            else
                text = $"[{info}]{Environment.NewLine}";

            OnNewInfo.Invoke(this, text);
        }

        private void WriteMessage(MessageEventArgs<TSub> msgArgs)
        {
            // Если отправитель это текущий подписчик, то выводится - кому было направлено -> "To {messageEventArgs.To}"
            if (msgArgs.From.Equals(Subscriber))
                msgArgs.Message = $"{FormatDate(msgArgs.DateCreated)} " +
                                        $"To {msgArgs.To}: {msgArgs.Text}{Environment.NewLine}";
            else // Если же сообщение пришло от другого контроллера, то:
                msgArgs.Message = $"{FormatDate(msgArgs.DateCreated)} " +
                                        $"{msgArgs.From}: {msgArgs.Text}{Environment.NewLine}";
            
            OnNewMessage.Invoke(this, msgArgs);
        }

        private string GetDateTime(string format = DateTimeFormat)
        {
            return FormatDate(DateTime.Now, format);
        }

        private string FormatDate(DateTime dateTime, string format = DateTimeFormat)
        {
            return $"[{dateTime.ToLocalTime().ToString(format)}]";
        }
    }
}
