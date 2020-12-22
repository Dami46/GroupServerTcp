namespace ClientGui
{
    partial class GameWindow
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
            this.backButton = new System.Windows.Forms.Button();
            this.gameStatus = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(194, 225);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(107, 45);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // gameStatus
            // 
            this.gameStatus.AutoSize = true;
            this.gameStatus.Location = new System.Drawing.Point(225, 71);
            this.gameStatus.Name = "gameStatus";
            this.gameStatus.Size = new System.Drawing.Size(42, 15);
            this.gameStatus.TabIndex = 1;
            this.gameStatus.Text = "Zimno";
            this.gameStatus.Click += new System.EventHandler(this.gameStatus_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(194, 159);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(107, 44);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Check Number";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(194, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 354);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.gameStatus);
            this.Controls.Add(this.backButton);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label gameStatus;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}