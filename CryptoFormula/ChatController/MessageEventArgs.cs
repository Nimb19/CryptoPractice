using System;
using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSAdapters;

namespace CryptoFormulaLibrary.ChatController
{
    public class MessageEventArgs<TSub> : EventArgs 
        where TSub : IEDSSubscriber
    {
        /// <summary> Полное сообщение в чат с датой и т.п. </summary>
        public string Message { get; set; }

        public string Text { get; }
        public DateTime DateCreated { get; }
        public TSub From { get; }
        public TSub To { get; }
        public IResultOfEncryptionHash ResultOfEncryptionHash { get; }

        public MessageEventArgs(string text, TSub from, TSub to, IResultOfEncryptionHash resultOfEncryptionHash)
        {
            Text = text;
            From = from;
            To = to;
            ResultOfEncryptionHash = resultOfEncryptionHash;
            DateCreated = DateTime.UtcNow;

            // Полное сообщение в чат с датой и т.п. Должно быть заполнено каким нибудь контроллером, если это будет нужно
            Message = this.ToString();
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
