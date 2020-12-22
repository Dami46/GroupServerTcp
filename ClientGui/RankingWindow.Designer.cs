namespace ClientGui
{
    partial class RankingWindow
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
            this.rankingTextBox = new System.Windows.Forms.RichTextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rankingTextBox
            // 
            this.rankingTextBox.Location = new System.Drawing.Point(112, 50);
            this.rankingTextBox.Name = "rankingTextBox";
            this.rankingTextBox.Size = new System.Drawing.Size(270, 184);
            this.rankingTextBox.TabIndex = 0;
            this.rankingTextBox.Text = "";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(186, 256);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(107, 45);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ranking";
            // 
            // RankingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.rankingTextBox);
            this.Name = "RankingWindow";
            this.Text = "RankingWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rankingTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label1;
    }
}