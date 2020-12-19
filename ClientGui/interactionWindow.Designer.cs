namespace ClientGui
{
    partial class removeButton
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
            this.choiceButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.beginButton = new System.Windows.Forms.Button();
            this.rankingButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // choiceButton
            // 
            this.choiceButton.Location = new System.Drawing.Point(351, 241);
            this.choiceButton.Name = "choiceButton";
            this.choiceButton.Size = new System.Drawing.Size(75, 23);
            this.choiceButton.TabIndex = 0;
            this.choiceButton.Text = "Confirm";
            this.choiceButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.changeButton);
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.rankingButton);
            this.panel1.Controls.Add(this.beginButton);
            this.panel1.Location = new System.Drawing.Point(272, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 161);
            this.panel1.TabIndex = 2;
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
            // rankingButton
            // 
            this.rankingButton.Location = new System.Drawing.Point(0, 42);
            this.rankingButton.Name = "rankingButton";
            this.rankingButton.Size = new System.Drawing.Size(227, 36);
            this.rankingButton.TabIndex = 3;
            this.rankingButton.Text = "Show Ranking";
            this.rankingButton.UseVisualStyleBackColor = true;
            this.rankingButton.Click += new System.EventHandler(this.rankingButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(0, 126);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(227, 36);
            this.logoutButton.TabIndex = 4;
            this.logoutButton.Text = "Log out";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(0, 84);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(227, 36);
            this.changeButton.TabIndex = 5;
            this.changeButton.Text = "Change Password";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // removeButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 343);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.choiceButton);
            this.Name = "removeButton";
            this.Text = "Remove User";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button choiceButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button rankingButton;
        private System.Windows.Forms.Button changeButton;
    }
}