using System;
using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSModels;

namespace CryptoFormulaLibrary.ChatController
{
    public class MessageEventArgs<TSub> : EventArgs 
        where TSub : IEDSSubscriber
    {
        /// <summary> Полное сообщение в чат с датой и т.п. </summary>
        public string Message { get; set; }

        /// <summary> Текст сообщения. </summary>
        public string Text { get; }
        public DateTime DateCreated { get; }
        public TSub From { get; }
        public TSub To { get; }
        /// <summary> Контроллер сам определит какой ему нужен класс, с какими параметрами. Пустой интерфейс. </summary>
        public IResultOfEncryptionHash ResultOfEncryptionHash { get; }

        public MessageEventArgs(string text, TSub from, TSub to, IResultOfEncryptionHash resultOfEncryptionHash)
        {
            Text = text;
            From = from;
            To = to;
            ResultOfEncryptionHash = resultOfEncryptionHash;
            DateCreated = DateTime.UtcNow;
    
            // Полное сообщение в чат с датой и т.п. Должно быть заполнено каким нибудь контроллером, если это будет нужно
            Message = text;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
