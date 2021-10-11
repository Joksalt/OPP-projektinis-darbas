
namespace PingPong3
{
    partial class StartForm
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
            this.StartButton = new System.Windows.Forms.Button();
            this.messagesLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(277, 88);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(56, 19);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Play";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // messagesLog
            // 
            this.messagesLog.Location = new System.Drawing.Point(41, 137);
            this.messagesLog.Name = "messagesLog";
            this.messagesLog.Size = new System.Drawing.Size(522, 170);
            this.messagesLog.TabIndex = 1;
            this.messagesLog.Text = "";
            this.messagesLog.TextChanged += new System.EventHandler(this.messagesLog_TextChanged);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.messagesLog);
            this.Controls.Add(this.StartButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        public System.Windows.Forms.RichTextBox messagesLog;
    }
}