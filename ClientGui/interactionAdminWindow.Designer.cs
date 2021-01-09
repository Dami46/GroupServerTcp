namespace ClientGui
{
    partial class InteractionAdminWindow
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.rankingButton = new System.Windows.Forms.Button();
            this.remButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.beginButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.rankingButton);
            this.panel1.Controls.Add(this.remButton);
            this.panel1.Controls.Add(this.registerButton);
            this.panel1.Controls.Add(this.beginButton);
            this.panel1.Location = new System.Drawing.Point(164, 76);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 164);
            this.panel1.TabIndex = 4;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(0, 136);
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
            this.rankingButton.Location = new System.Drawing.Point(0, 103);
            this.rankingButton.Margin = new System.Windows.Forms.Padding(2);
            this.rankingButton.Name = "rankingButton";
            this.rankingButton.Size = new System.Drawing.Size(170, 29);
            this.rankingButton.TabIndex = 3;
            this.rankingButton.Text = "Show Ranking";
            this.rankingButton.UseVisualStyleBackColor = true;
            this.rankingButton.Click += new System.EventHandler(this.rankingButton_Click);
            // 
            // remButton
            // 
            this.remButton.Location = new System.Drawing.Point(0, 69);
            this.remButton.Margin = new System.Windows.Forms.Padding(2);
            this.remButton.Name = "remButton";
            this.remButton.Size = new System.Drawing.Size(170, 29);
            this.remButton.TabIndex = 2;
            this.remButton.Text = "Remove User";
            this.remButton.UseVisualStyleBackColor = true;
            this.remButton.Click += new System.EventHandler(this.remButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(0, 34);
            this.registerButton.Margin = new System.Windows.Forms.Padding(2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(170, 29);
            this.registerButton.TabIndex = 1;
            this.registerButton.Text = "Register User";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(0, 0);
            this.beginButton.Margin = new System.Windows.Forms.Padding(2);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(170, 29);
            this.beginButton.TabIndex = 0;
            this.beginButton.Text = "Begin Game";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // InteractionAdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 324);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InteractionAdminWindow";
            this.Text = "Admin Window";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button rankingButton;
        private System.Windows.Forms.Button remButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button beginButton;
    }
}