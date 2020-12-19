namespace ClientGui
{
    partial class interactionAdminWindow
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
            this.choiceButton = new System.Windows.Forms.Button();
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
            this.panel1.Location = new System.Drawing.Point(287, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 202);
            this.panel1.TabIndex = 4;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(0, 167);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(227, 36);
            this.logoutButton.TabIndex = 4;
            this.logoutButton.Text = "Log out";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // rankingButton
            // 
            this.rankingButton.Location = new System.Drawing.Point(0, 127);
            this.rankingButton.Name = "rankingButton";
            this.rankingButton.Size = new System.Drawing.Size(227, 36);
            this.rankingButton.TabIndex = 3;
            this.rankingButton.Text = "Show Ranking";
            this.rankingButton.UseVisualStyleBackColor = true;
            // 
            // remButton
            // 
            this.remButton.Location = new System.Drawing.Point(0, 85);
            this.remButton.Name = "remButton";
            this.remButton.Size = new System.Drawing.Size(227, 36);
            this.remButton.TabIndex = 2;
            this.remButton.Text = "Remove Button";
            this.remButton.UseVisualStyleBackColor = true;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(0, 42);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(227, 36);
            this.registerButton.TabIndex = 1;
            this.registerButton.Text = "Register Button";
            this.registerButton.UseVisualStyleBackColor = true;
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(0, 0);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(227, 36);
            this.beginButton.TabIndex = 0;
            this.beginButton.Text = "Begin Game";
            this.beginButton.UseVisualStyleBackColor = true;
            // 
            // choiceButton
            // 
            this.choiceButton.Location = new System.Drawing.Point(364, 328);
            this.choiceButton.Name = "choiceButton";
            this.choiceButton.Size = new System.Drawing.Size(75, 23);
            this.choiceButton.TabIndex = 3;
            this.choiceButton.Text = "Confirm";
            this.choiceButton.UseVisualStyleBackColor = true;
            // 
            // interactionAdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.choiceButton);
            this.Name = "interactionAdminWindow";
            this.Text = "interactionAdminWindow";
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
        private System.Windows.Forms.Button choiceButton;
    }
}