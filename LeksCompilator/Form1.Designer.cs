namespace LeksCompilator
{
    partial class Form1
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
            this.loadBtn = new System.Windows.Forms.Button();
            this.expressionTxt = new System.Windows.Forms.RichTextBox();
            this.prevExprBtn = new System.Windows.Forms.Button();
            this.nextExprBtn = new System.Windows.Forms.Button();
            this.leksemsTable = new System.Windows.Forms.DataGridView();
            this.Leksema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meaning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.textTxt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorsTxt = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.leksemsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(309, 28);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(79, 24);
            this.loadBtn.TabIndex = 3;
            this.loadBtn.Text = "Загрузить";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // expressionTxt
            // 
            this.expressionTxt.Location = new System.Drawing.Point(33, 12);
            this.expressionTxt.Name = "expressionTxt";
            this.expressionTxt.Size = new System.Drawing.Size(252, 49);
            this.expressionTxt.TabIndex = 6;
            this.expressionTxt.Text = "";
            this.expressionTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputStringTxt_KeyPress);
            // 
            // prevExprBtn
            // 
            this.prevExprBtn.Enabled = false;
            this.prevExprBtn.Location = new System.Drawing.Point(33, 69);
            this.prevExprBtn.Name = "prevExprBtn";
            this.prevExprBtn.Size = new System.Drawing.Size(120, 34);
            this.prevExprBtn.TabIndex = 8;
            this.prevExprBtn.Text = "Предыдущее выражение";
            this.prevExprBtn.UseVisualStyleBackColor = true;
            this.prevExprBtn.Click += new System.EventHandler(this.prevExprBtn_Click);
            // 
            // nextExprBtn
            // 
            this.nextExprBtn.Enabled = false;
            this.nextExprBtn.Location = new System.Drawing.Point(162, 69);
            this.nextExprBtn.Name = "nextExprBtn";
            this.nextExprBtn.Size = new System.Drawing.Size(123, 34);
            this.nextExprBtn.TabIndex = 7;
            this.nextExprBtn.Text = "Следующее выражение";
            this.nextExprBtn.UseVisualStyleBackColor = true;
            this.nextExprBtn.Click += new System.EventHandler(this.nextExprBtn_Click);
            // 
            // leksemsTable
            // 
            this.leksemsTable.AllowUserToAddRows = false;
            this.leksemsTable.AllowUserToDeleteRows = false;
            this.leksemsTable.AllowUserToResizeColumns = false;
            this.leksemsTable.AllowUserToResizeRows = false;
            this.leksemsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.leksemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leksemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Leksema,
            this.Type,
            this.Meaning});
            this.leksemsTable.Location = new System.Drawing.Point(417, 28);
            this.leksemsTable.Name = "leksemsTable";
            this.leksemsTable.Size = new System.Drawing.Size(429, 302);
            this.leksemsTable.TabIndex = 9;
            // 
            // Leksema
            // 
            this.Leksema.HeaderText = "Лексема";
            this.Leksema.Name = "Leksema";
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.Name = "Type";
            // 
            // Meaning
            // 
            this.Meaning.HeaderText = "Значение";
            this.Meaning.Name = "Meaning";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Таблица лексем:";
            // 
            // textTxt
            // 
            this.textTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textTxt.Location = new System.Drawing.Point(34, 122);
            this.textTxt.Name = "textTxt";
            this.textTxt.Size = new System.Drawing.Size(354, 350);
            this.textTxt.TabIndex = 11;
            this.textTxt.Text = "";
            this.textTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputStringTxt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Текст:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Вывод:";
            // 
            // errorsTxt
            // 
            this.errorsTxt.Location = new System.Drawing.Point(417, 354);
            this.errorsTxt.Name = "errorsTxt";
            this.errorsTxt.Size = new System.Drawing.Size(429, 118);
            this.errorsTxt.TabIndex = 15;
            this.errorsTxt.Text = "";
            this.errorsTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputStringTxt_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 484);
            this.Controls.Add(this.errorsTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.leksemsTable);
            this.Controls.Add(this.prevExprBtn);
            this.Controls.Add(this.nextExprBtn);
            this.Controls.Add(this.expressionTxt);
            this.Controls.Add(this.loadBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Андронатий 21ПИ";
            ((System.ComponentModel.ISupportInitialize)(this.leksemsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.RichTextBox expressionTxt;
        private System.Windows.Forms.Button prevExprBtn;
        private System.Windows.Forms.Button nextExprBtn;
        private System.Windows.Forms.DataGridView leksemsTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox textTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leksema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meaning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox errorsTxt;
    }
}

