namespace SeleniumParse
{
    partial class Form1
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
            this.ParsePageButtom = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.StopBrowserButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.СurrentNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.parseCar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParsePageButtom
            // 
            this.ParsePageButtom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ParsePageButtom.Location = new System.Drawing.Point(3, 12);
            this.ParsePageButtom.Name = "ParsePageButtom";
            this.ParsePageButtom.Size = new System.Drawing.Size(129, 44);
            this.ParsePageButtom.TabIndex = 0;
            this.ParsePageButtom.Text = "парсинг страниц";
            this.ParsePageButtom.UseVisualStyleBackColor = true;
            this.ParsePageButtom.Click += new System.EventHandler(this.ParsePageButtom_Click);
            // 
            // TestButton
            // 
            this.TestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TestButton.Location = new System.Drawing.Point(3, 80);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(129, 44);
            this.TestButton.TabIndex = 1;
            this.TestButton.Text = "runTest";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // StopBrowserButton
            // 
            this.StopBrowserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StopBrowserButton.Location = new System.Drawing.Point(3, 149);
            this.StopBrowserButton.Name = "StopBrowserButton";
            this.StopBrowserButton.Size = new System.Drawing.Size(129, 41);
            this.StopBrowserButton.TabIndex = 2;
            this.StopBrowserButton.Text = "stop";
            this.StopBrowserButton.UseVisualStyleBackColor = true;
            this.StopBrowserButton.Click += new System.EventHandler(this.StopBrowserButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.16524F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.83476F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.Controls.Add(this.StopBrowserButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ParsePageButtom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TestButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.СurrentNum, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.parseCar, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 340);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // СurrentNum
            // 
            this.СurrentNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.СurrentNum.Location = new System.Drawing.Point(323, 23);
            this.СurrentNum.Name = "СurrentNum";
            this.СurrentNum.Size = new System.Drawing.Size(181, 22);
            this.СurrentNum.TabIndex = 3;
            this.СurrentNum.Text = "1";
            this.СurrentNum.TextChanged += new System.EventHandler(this.СurentNum_TextChanged);
            this.СurrentNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.СurentNum_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "с какой страницы начать";
            // 
            // parseCar
            // 
            this.parseCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.parseCar.Location = new System.Drawing.Point(3, 220);
            this.parseCar.Name = "parseCar";
            this.parseCar.Size = new System.Drawing.Size(129, 35);
            this.parseCar.TabIndex = 5;
            this.parseCar.Text = "парсинг машин";
            this.parseCar.UseVisualStyleBackColor = true;
            this.parseCar.Click += new System.EventHandler(this.parseCar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 340);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ParsePageButtom;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button StopBrowserButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox СurrentNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button parseCar;
    }
}

