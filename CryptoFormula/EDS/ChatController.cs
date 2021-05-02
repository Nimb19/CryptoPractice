using System;
using System.Numerics;
using System.Windows.Forms;
using CryptoFormulaLibrary.EDSAdapters;

namespace CryptoFormulaLibrary.EDS
{
    public class ChatController<TSub> where TSub : Subscriber
    {
        public TSub Subscriber { get; }
        public TextBox MainChatBox { get; }

        private const string DateTimeFormat = "g";

        public ChatController(TextBox chatBox, TSub sub)
        {
            MainChatBox = chatBox;
            Subscriber = sub;
        }

        public void WriteMessageTo(ChatController<TSub> recipientChatController, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            var encryptedHash = Subscriber.Controller.EncryptHashCode(message.GetHashCode());
            recipientChatController.WriteReceivedMessage(message, encryptedHash, Subscriber);

            WriteInfo($"To {recipientChatController.Subscriber.Name}: {message}");
        }

        private void WriteReceivedMessage(string message, BigInteger encryptedHash, TSub sender)
        {
            var hash = message.GetHashCode();
            var decryptedHash = sender.Controller.DecryptHashCode(encryptedHash);

            if (hash == decryptedHash)
                WriteInfo($"Hash {hash} == DecryptedHash {decryptedHash}. Хэш не отличается. Сообщение не было изменено", showDate: false);
            else
                WriteInfo($"Hash {hash} != DecryptedHash {decryptedHash}. Хэш отличается. Сообщение было изменено", showDate: false);

            WriteInfo($"{Subscriber.Name}: {message}");
        }

        public void WriteInfo(string info, bool showDate = true)
        {
            if (string.IsNullOrWhiteSpace(info))
                return;

            if (showDate)
                MainChatBox.Text += $"{GetDateTime()} {info}{Environment.NewLine}";
            else
                MainChatBox.Text += $"[{info}]{Environment.NewLine}";
        }

        private string GetDateTime(string format = DateTimeFormat)
        {
            return $"[{DateTime.Now.ToString(format)}]";
        }
    }
}
