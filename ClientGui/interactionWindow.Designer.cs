namespace ClientGui
{
    partial class InteractionWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.rankingButton = new System.Windows.Forms.Button();
            this.beginButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.changeButton);
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.rankingButton);
            this.panel1.Controls.Add(this.beginButton);
            this.panel1.Location = new System.Drawing.Point(158, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 131);
            this.panel1.TabIndex = 2;
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(2, 69);
            this.changeButton.Margin = new System.Windows.Forms.Padding(2);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(170, 29);
            this.changeButton.TabIndex = 5;
            this.changeButton.Text = "Change Password";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(2, 102);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(170, 29);
            this.logoutButton.TabIndex = 4;
            this.logoutButton.Text = "Log out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // rankingButton
            // 
            this.rankingButton.Location = new System.Drawing.Point(2, 33);
            this.rankingButton.Margin = new System.Windows.Forms.Padding(2);
            this.rankingButton.Name = "rankingButton";
            this.rankingButton.Size = new System.Drawing.Size(170, 29);
            this.rankingButton.TabIndex = 3;
            this.rankingButton.Text = "Show Ranking";
            this.rankingButton.UseVisualStyleBackColor = true;
            this.rankingButton.Click += new System.EventHandler(this.rankingButton_Click);
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(2, 0);
            this.beginButton.Margin = new System.Windows.Forms.Padding(2);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(170, 29);
            this.beginButton.TabIndex = 0;
            this.beginButton.Text = "Begin Game";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // InteractionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 304);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InteractionWindow";
            this.Text = "User Menu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button rankingButton;
        private System.Windows.Forms.Button changeButton;
    }
}