using System;
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

            var encryptedHashResults = Subscriber.Controller.EncryptHashCode(message.GetHashCode(), recipientChatController.Subscriber.OpenedKey);
            var msgArgs = new MessageEventArgs<TSub>(message, Subscriber, recipientChatController.Subscriber, encryptedHashResults);
            
            recipientChatController.WriteReceivedMessage(msgArgs);
            WriteMessage(msgArgs);
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

        private void WriteReceivedMessage(MessageEventArgs<TSub> msgArgs)
        {
            var hash = msgArgs.Text.GetHashCode();
            var decryptedHash = msgArgs.To.Controller.DecryptHashCode(msgArgs.ResultOfEncryptionHash);

            if (hash == decryptedHash)
                WriteInfo($"Hash {hash} == DecryptedHash {decryptedHash}. Хэш не отличается. Сообщение не было изменено");
            else
                WriteInfo($"Hash {hash} != DecryptedHash {decryptedHash}. Хэш отличается. Сообщение было изменено");

            WriteMessage(msgArgs);
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
