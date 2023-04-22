
namespace ThinkArctBank
{
    partial class TransactHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.historyDataGrid = new System.Windows.Forms.DataGridView();
            this.searchHistory = new System.Windows.Forms.Button();
            this.historyTimeBox = new System.Windows.Forms.Panel();
            this.historyMessage = new System.Windows.Forms.Label();
            this.accountNumber = new System.Windows.Forms.Label();
            this.historyAcct = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGrid)).BeginInit();
            this.historyTimeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // historyDataGrid
            // 
            this.historyDataGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.historyDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.historyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDataGrid.Location = new System.Drawing.Point(1, 243);
            this.historyDataGrid.Name = "historyDataGrid";
            this.historyDataGrid.RowTemplate.Height = 25;
            this.historyDataGrid.Size = new System.Drawing.Size(453, 239);
            this.historyDataGrid.TabIndex = 33;
            this.historyDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.historyDataGrid_CellContentClick);
            // 
            // searchHistory
            // 
            this.searchHistory.Location = new System.Drawing.Point(170, 161);
            this.searchHistory.Name = "searchHistory";
            this.searchHistory.Size = new System.Drawing.Size(108, 34);
            this.searchHistory.TabIndex = 31;
            this.searchHistory.Text = "Search";
            this.searchHistory.UseVisualStyleBackColor = true;
            this.searchHistory.Click += new System.EventHandler(this.searchHistory_Click);
            // 
            // historyTimeBox
            // 
            this.historyTimeBox.BackColor = System.Drawing.Color.AliceBlue;
            this.historyTimeBox.Controls.Add(this.historyMessage);
            this.historyTimeBox.Controls.Add(this.searchHistory);
            this.historyTimeBox.Controls.Add(this.accountNumber);
            this.historyTimeBox.Controls.Add(this.historyAcct);
            this.historyTimeBox.Controls.Add(this.dateTimePicker1);
            this.historyTimeBox.Controls.Add(this.label1);
            this.historyTimeBox.Controls.Add(this.dateTimePicker2);
            this.historyTimeBox.Controls.Add(this.label2);
            this.historyTimeBox.Location = new System.Drawing.Point(5, 5);
            this.historyTimeBox.Name = "historyTimeBox";
            this.historyTimeBox.Size = new System.Drawing.Size(446, 205);
            this.historyTimeBox.TabIndex = 32;
            // 
            // historyMessage
            // 
            this.historyMessage.AutoSize = true;
            this.historyMessage.Location = new System.Drawing.Point(131, 142);
            this.historyMessage.Name = "historyMessage";
            this.historyMessage.Size = new System.Drawing.Size(0, 15);
            this.historyMessage.TabIndex = 29;
            // 
            // accountNumber
            // 
            this.accountNumber.AutoSize = true;
            this.accountNumber.BackColor = System.Drawing.Color.AliceBlue;
            this.accountNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.accountNumber.Location = new System.Drawing.Point(89, 120);
            this.accountNumber.Name = "accountNumber";
            this.accountNumber.Size = new System.Drawing.Size(46, 15);
            this.accountNumber.TabIndex = 28;
            this.accountNumber.Text = "Acc No";
            // 
            // historyAcct
            // 
            this.historyAcct.FormattingEnabled = true;
            this.historyAcct.Location = new System.Drawing.Point(174, 117);
            this.historyAcct.Name = "historyAcct";
            this.historyAcct.Size = new System.Drawing.Size(208, 23);
            this.historyAcct.TabIndex = 27;
            this.historyAcct.SelectedIndexChanged += new System.EventHandler(this.historyAcct_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 25);
            this.dateTimePicker1.MaxDate = new System.DateTime(2590, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(208, 23);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.Value = new System.DateTime(2022, 12, 5, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(89, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Start Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(174, 76);
            this.dateTimePicker2.MaxDate = new System.DateTime(2182, 12, 3, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(208, 23);
            this.dateTimePicker2.TabIndex = 24;
            this.dateTimePicker2.Value = new System.DateTime(2023, 1, 25, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(89, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "End Date";
            // 
            // TransactHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.historyDataGrid);
            this.Controls.Add(this.historyTimeBox);
            this.Name = "TransactHistory";
            this.Size = new System.Drawing.Size(456, 486);
            this.Load += new System.EventHandler(this.TransactHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGrid)).EndInit();
            this.historyTimeBox.ResumeLayout(false);
            this.historyTimeBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView historyDataGrid;
        private System.Windows.Forms.Button searchHistory;
        private System.Windows.Forms.Panel historyTimeBox;
        private System.Windows.Forms.Label historyMessage;
        private System.Windows.Forms.Label accountNumber;
        private System.Windows.Forms.ComboBox historyAcct;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
    }
}
