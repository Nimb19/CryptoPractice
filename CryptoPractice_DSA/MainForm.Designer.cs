using System;

namespace CryptoPractice_DSA
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btAddSubscriber = new System.Windows.Forms.Button();
            this.tbParamP = new System.Windows.Forms.TextBox();
            this.tbParamG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbParamQ = new System.Windows.Forms.TextBox();
            this.btSetRandomCommonParams = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btSetRandomSubscriberParams = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSubscriberName = new System.Windows.Forms.TextBox();
            this.tbOpenedKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbClosedKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.subscribersDataGrid = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOpenedKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reciepent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subscribersDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.SuspendLayout();
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
            // btAddSubscriber
            // 
            this.btAddSubscriber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddSubscriber.Location = new System.Drawing.Point(14, 139);
            this.btAddSubscriber.Name = "btAddSubscriber";
            this.btAddSubscriber.Size = new System.Drawing.Size(488, 36);
            this.btAddSubscriber.TabIndex = 1;
            this.btAddSubscriber.Text = "Добавить абонента";
            this.btAddSubscriber.UseVisualStyleBackColor = true;
            this.btAddSubscriber.Click += new System.EventHandler(this.BtAddSubscriber_Click);
            // 
            // tbParamP
            // 
            this.tbParamP.Location = new System.Drawing.Point(146, 34);
            this.tbParamP.Name = "tbParamP";
            this.tbParamP.Size = new System.Drawing.Size(100, 27);
            this.tbParamP.TabIndex = 2;
            // 
            // tbParamG
            // 
            this.tbParamG.Location = new System.Drawing.Point(402, 34);
            this.tbParamG.Name = "tbParamG";
            this.tbParamG.Size = new System.Drawing.Size(100, 27);
            this.tbParamG.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Параметр g:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbParamQ);
            this.groupBox1.Controls.Add(this.btSetRandomCommonParams);
            this.groupBox1.Controls.Add(this.tbParamG);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbParamP);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 164);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общие параметры:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Параметр q:";
            // 
            // tbParamQ
            // 
            this.tbParamQ.Location = new System.Drawing.Point(146, 72);
            this.tbParamQ.Name = "tbParamQ";
            this.tbParamQ.Size = new System.Drawing.Size(100, 27);
            this.tbParamQ.TabIndex = 14;
            // 
            // btSetRandomCommonParams
            // 
            this.btSetRandomCommonParams.Location = new System.Drawing.Point(14, 107);
            this.btSetRandomCommonParams.Name = "btSetRandomCommonParams";
            this.btSetRandomCommonParams.Size = new System.Drawing.Size(488, 36);
            this.btSetRandomCommonParams.TabIndex = 12;
            this.btSetRandomCommonParams.Text = "Random";
            this.btSetRandomCommonParams.UseVisualStyleBackColor = true;
            this.btSetRandomCommonParams.Click += new System.EventHandler(this.BtSetRandomCommonParams_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btSetRandomSubscriberParams);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbSubscriberName);
            this.groupBox2.Controls.Add(this.tbOpenedKey);
            this.groupBox2.Controls.Add(this.btAddSubscriber);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbClosedKey);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 181);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки нового абонента:";
            // 
            // btSetRandomSubscriberParams
            // 
            this.btSetRandomSubscriberParams.Location = new System.Drawing.Point(270, 86);
            this.btSetRandomSubscriberParams.Name = "btSetRandomSubscriberParams";
            this.btSetRandomSubscriberParams.Size = new System.Drawing.Size(232, 31);
            this.btSetRandomSubscriberParams.TabIndex = 11;
            this.btSetRandomSubscriberParams.Text = "Random";
            this.btSetRandomSubscriberParams.UseVisualStyleBackColor = true;
            this.btSetRandomSubscriberParams.Click += new System.EventHandler(this.BtSetRandomSubscriberParams);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Имя абонента:";
            // 
            // tbSubscriberName
            // 
            this.tbSubscriberName.Location = new System.Drawing.Point(146, 88);
            this.tbSubscriberName.Name = "tbSubscriberName";
            this.tbSubscriberName.Size = new System.Drawing.Size(100, 27);
            this.tbSubscriberName.TabIndex = 10;
            // 
            // tbOpenedKey
            // 
            this.tbOpenedKey.Location = new System.Drawing.Point(402, 35);
            this.tbOpenedKey.Name = "tbOpenedKey";
            this.tbOpenedKey.ReadOnly = true;
            this.tbOpenedKey.Size = new System.Drawing.Size(100, 27);
            this.tbOpenedKey.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Закрытый ключ:";
            // 
            // tbClosedKey
            // 
            this.tbClosedKey.Location = new System.Drawing.Point(146, 35);
            this.tbClosedKey.Name = "tbClosedKey";
            this.tbClosedKey.Size = new System.Drawing.Size(100, 27);
            this.tbClosedKey.TabIndex = 6;
            this.tbClosedKey.TextChanged += new System.EventHandler(this.TbClosedKey_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Открытый ключ:";
            // 
            // subscribersDataGrid
            // 
            this.subscribersDataGrid.AllowUserToAddRows = false;
            this.subscribersDataGrid.AllowUserToDeleteRows = false;
            this.subscribersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subscribersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnOpenedKey});
            this.subscribersDataGrid.Location = new System.Drawing.Point(533, 35);
            this.subscribersDataGrid.Name = "subscribersDataGrid";
            this.subscribersDataGrid.ReadOnly = true;
            this.subscribersDataGrid.Size = new System.Drawing.Size(789, 327);
            this.subscribersDataGrid.TabIndex = 7;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnName.HeaderText = "Имя подписчика:";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 156;
            // 
            // ColumnOpenedKey
            // 
            this.ColumnOpenedKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnOpenedKey.HeaderText = "Открытый ключ";
            this.ColumnOpenedKey.Name = "ColumnOpenedKey";
            this.ColumnOpenedKey.ReadOnly = true;
            this.ColumnOpenedKey.Width = 140;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(888, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Пользователи:";
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHistory.ColumnHeadersHeight = 50;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M,
            this.dataGridViewTextBoxColumn1,
            this.Reciepent,
            this.P,
            this.Q,
            this.G,
            this.X,
            this.Y,
            this.K,
            this.R,
            this.S,
            this.W,
            this.U1,
            this.U2,
            this.V});
            this.dataGridViewHistory.Location = new System.Drawing.Point(12, 407);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.ReadOnly = true;
            this.dataGridViewHistory.RowHeadersWidth = 39;
            this.dataGridViewHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHistory.Size = new System.Drawing.Size(1310, 272);
            this.dataGridViewHistory.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(583, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "История сообщений:";
            // 
            // M
            // 
            this.M.HeaderText = "m (hash)";
            this.M.Name = "M";
            this.M.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "Отправитель";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 129;
            // 
            // Reciepent
            // 
            this.Reciepent.HeaderText = "Получатель";
            this.Reciepent.Name = "Reciepent";
            this.Reciepent.ReadOnly = true;
            // 
            // P
            // 
            this.P.HeaderText = "p";
            this.P.Name = "P";
            this.P.ReadOnly = true;
            // 
            // Q
            // 
            this.Q.HeaderText = "q";
            this.Q.Name = "Q";
            this.Q.ReadOnly = true;
            // 
            // G
            // 
            this.G.HeaderText = "g";
            this.G.Name = "G";
            this.G.ReadOnly = true;
            // 
            // X
            // 
            this.X.HeaderText = "x";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            // 
            // Y
            // 
            this.Y.HeaderText = "y";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            // 
            // K
            // 
            this.K.HeaderText = "k";
            this.K.Name = "K";
            this.K.ReadOnly = true;
            // 
            // R
            // 
            this.R.HeaderText = "r";
            this.R.Name = "R";
            this.R.ReadOnly = true;
            // 
            // S
            // 
            this.S.HeaderText = "s";
            this.S.Name = "S";
            this.S.ReadOnly = true;
            // 
            // W
            // 
            this.W.HeaderText = "w";
            this.W.Name = "W";
            this.W.ReadOnly = true;
            // 
            // U1
            // 
            this.U1.HeaderText = "u1";
            this.U1.Name = "U1";
            this.U1.ReadOnly = true;
            // 
            // U2
            // 
            this.U2.HeaderText = "u2";
            this.U2.Name = "U2";
            this.U2.ReadOnly = true;
            // 
            // V
            // 
            this.V.HeaderText = "v";
            this.V.Name = "V";
            this.V.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 691);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridViewHistory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subscribersDataGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Электронная цифровая подпись DSA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subscribersDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAddSubscriber;
        private System.Windows.Forms.TextBox tbParamP;
        private System.Windows.Forms.TextBox tbParamG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView subscribersDataGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOpenedKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbClosedKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSetRandomSubscriberParams;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSubscriberName;
        private System.Windows.Forms.Button btSetRandomCommonParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOpenedKey;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbParamQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reciepent;
        private System.Windows.Forms.DataGridViewTextBoxColumn P;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q;
        private System.Windows.Forms.DataGridViewTextBoxColumn G;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn K;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.DataGridViewTextBoxColumn W;
        private System.Windows.Forms.DataGridViewTextBoxColumn U1;
        private System.Windows.Forms.DataGridViewTextBoxColumn U2;
        private System.Windows.Forms.DataGridViewTextBoxColumn V;
    }
}

