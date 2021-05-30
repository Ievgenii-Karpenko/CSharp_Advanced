
using System;

namespace ClientChat1
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
            this.outputMessageBox = new System.Windows.Forms.RichTextBox();
            this.input_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outputMessageBox
            // 
            this.outputMessageBox.Location = new System.Drawing.Point(30, 30);
            this.outputMessageBox.Name = "outputMessageBox";
            this.outputMessageBox.ReadOnly = true;
            this.outputMessageBox.Size = new System.Drawing.Size(481, 245);
            this.outputMessageBox.TabIndex = 0;
            this.outputMessageBox.Text = "";
            // 
            // input_textBox
            // 
            this.input_textBox.Location = new System.Drawing.Point(39, 316);
            this.input_textBox.Name = "input_textBox";
            this.input_textBox.Size = new System.Drawing.Size(355, 20);
            this.input_textBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(563, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(39, 359);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(132, 20);
            this.ipTextBox.TabIndex = 1;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(563, 357);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.input_textBox);
            this.Controls.Add(this.outputMessageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputMessageBox;
        private System.Windows.Forms.TextBox input_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Button ConnectBtn;
    }
}

