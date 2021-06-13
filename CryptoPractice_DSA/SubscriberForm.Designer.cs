using System;

namespace CryptoPractice_DSA
{
    partial class SubscriberForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatBox = new System.Windows.Forms.TextBox();
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.tbOpenedKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbClosedKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbParamG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbParamP = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.subComboBox = new System.Windows.Forms.ComboBox();
            this.tbParamQ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(12, 356);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(543, 249);
            this.chatBox.TabIndex = 0;
            // 
            // groupBoxParams
            // 
            this.groupBoxParams.Controls.Add(this.tbParamQ);
            this.groupBoxParams.Controls.Add(this.label8);
            this.groupBoxParams.Controls.Add(this.tbOpenedKey);
            this.groupBoxParams.Controls.Add(this.label4);
            this.groupBoxParams.Controls.Add(this.tbClosedKey);
            this.groupBoxParams.Controls.Add(this.label5);
            this.groupBoxParams.Controls.Add(this.tbParamG);
            this.groupBoxParams.Controls.Add(this.label1);
            this.groupBoxParams.Controls.Add(this.label2);
            this.groupBoxParams.Controls.Add(this.tbParamP);
            this.groupBoxParams.Location = new System.Drawing.Point(12, 12);
            this.groupBoxParams.Name = "groupBoxParams";
            this.groupBoxParams.Size = new System.Drawing.Size(543, 132);
            this.groupBoxParams.TabIndex = 6;
            this.groupBoxParams.TabStop = false;
            this.groupBoxParams.Text = "Параметры подписчика @name:";
            // 
            // tbOpenedKey
            // 
            this.tbOpenedKey.Location = new System.Drawing.Point(424, 77);
            this.tbOpenedKey.Name = "tbOpenedKey";
            this.tbOpenedKey.ReadOnly = true;
            this.tbOpenedKey.Size = new System.Drawing.Size(100, 27);
            this.tbOpenedKey.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Закрытый ключ:";
            // 
            // tbClosedKey
            // 
            this.tbClosedKey.Location = new System.Drawing.Point(146, 77);
            this.tbClosedKey.Name = "tbClosedKey";
            this.tbClosedKey.ReadOnly = true;
            this.tbClosedKey.Size = new System.Drawing.Size(100, 27);
            this.tbClosedKey.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Открытый ключ:";
            // 
            // tbParamG
            // 
            this.tbParamG.Location = new System.Drawing.Point(310, 34);
            this.tbParamG.Name = "tbParamG";
            this.tbParamG.ReadOnly = true;
            this.tbParamG.Size = new System.Drawing.Size(44, 27);
            this.tbParamG.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Параметр p:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Параметр g:";
            // 
            // tbParamP
            // 
            this.tbParamP.Location = new System.Drawing.Point(130, 34);
            this.tbParamP.Name = "tbParamP";
            this.tbParamP.ReadOnly = true;
            this.tbParamP.Size = new System.Drawing.Size(44, 27);
            this.tbParamP.TabIndex = 2;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(12, 194);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(543, 82);
            this.tbMessage.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Сообщение:";
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(241, 150);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(314, 38);
            this.buttonSendMessage.TabIndex = 9;
            this.buttonSendMessage.Text = "Отправить";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.ButtonSendMessage_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label6.Location = new System.Drawing.Point(252, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Чат:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label7.Location = new System.Drawing.Point(12, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Отправить";
            // 
            // subComboBox
            // 
            this.subComboBox.FormattingEnabled = true;
            this.subComboBox.Location = new System.Drawing.Point(241, 282);
            this.subComboBox.Name = "subComboBox";
            this.subComboBox.Size = new System.Drawing.Size(314, 29);
            this.subComboBox.TabIndex = 12;
            // 
            // tbParamQ
            // 
            this.tbParamQ.Location = new System.Drawing.Point(480, 34);
            this.tbParamQ.Name = "tbParamQ";
            this.tbParamQ.ReadOnly = true;
            this.tbParamQ.Size = new System.Drawing.Size(44, 27);
            this.tbParamQ.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(360, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Параметр q:";
            // 
            // SubscriberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 617);
            this.Controls.Add(this.subComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.groupBoxParams);
            this.Controls.Add(this.chatBox);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SubscriberForm";
            this.Text = "2.1 тема. Форма подписчика @name.";
            this.groupBoxParams.ResumeLayout(false);
            this.groupBoxParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.GroupBox groupBoxParams;
        private System.Windows.Forms.TextBox tbParamG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbParamP;
        private System.Windows.Forms.TextBox tbOpenedKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbClosedKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox subComboBox;
        private System.Windows.Forms.TextBox tbParamQ;
        private System.Windows.Forms.Label label8;
    }
}