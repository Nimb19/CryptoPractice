using System;
using System.Windows.Forms;

using CryptoFormulaLibrary.Models;

namespace CryptoPractice_2._1
{
    public class ChatController
    {
        public Subscriber Subscriber { get; }
        public TextBox MainChatBox { get; }

        public ChatController(TextBox chatBox, Subscriber sub)
        {
            MainChatBox = chatBox;
            Subscriber = sub;
        }

        public void PushMessage(ChatController senderChatController, string message)
        {
            var dateTime = DateTime.Now.ToString("g");
            MainChatBox.Text += $"{dateTime} {senderChatController.Subscriber.Name}: {message};{Environment.NewLine}";
            senderChatController.MainChatBox.Text += $"{dateTime} To {Subscriber.Name}: {message};{Environment.NewLine}";
        }
    }
}
