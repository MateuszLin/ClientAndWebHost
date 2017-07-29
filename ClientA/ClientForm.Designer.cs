namespace ClientA
{
    partial class ClientForm
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.labelConnecting = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(51, 55);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(53, 13);
            this.labelMessage.TabIndex = 15;
            this.labelMessage.Text = "Message:";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(110, 52);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(246, 20);
            this.textBoxMessage.TabIndex = 14;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(296, 99);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(110, 35);
            this.SendBtn.TabIndex = 16;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // labelConnecting
            // 
            this.labelConnecting.AutoSize = true;
            this.labelConnecting.Location = new System.Drawing.Point(162, 99);
            this.labelConnecting.Name = "labelConnecting";
            this.labelConnecting.Size = new System.Drawing.Size(115, 13);
            this.labelConnecting.TabIndex = 17;
            this.labelConnecting.Text = "Trying connect to Host";
            this.labelConnecting.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 42);
            this.button1.TabIndex = 18;
            this.button1.Text = "Saved Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 259);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelConnecting);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.textBoxMessage);
            this.Name = "ClientForm";
            this.Text = "Client - A";
            this.Shown += new System.EventHandler(this.ClientForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Label labelConnecting;
        private System.Windows.Forms.Button button1;
    }
}

