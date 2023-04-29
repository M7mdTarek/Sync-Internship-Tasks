using System.Windows.Forms;

namespace Sync_Task2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button voteButton;


        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            candidateListBox = new ListBox();
            voteButton = new Button();
            winnerLabel = new Label();
            SuspendLayout();
            // 
            // candidateListBox
            // 
            candidateListBox.FormattingEnabled = true;
            candidateListBox.ItemHeight = 20;
            candidateListBox.Location = new System.Drawing.Point(16, 18);
            candidateListBox.Margin = new Padding(4, 5, 4, 5);
            candidateListBox.Name = "candidateListBox";
            candidateListBox.Size = new System.Drawing.Size(265, 264);
            candidateListBox.TabIndex = 0;
            
            // 
            // voteButton
            // 
            voteButton.Location = new System.Drawing.Point(16, 294);
            voteButton.Margin = new Padding(4, 5, 4, 5);
            voteButton.Name = "voteButton";
            voteButton.Size = new System.Drawing.Size(267, 35);
            voteButton.TabIndex = 1;
            voteButton.Text = "Vote";
            voteButton.UseVisualStyleBackColor = true;
            voteButton.Click += voteButton_Click;
            // 
            // winnerLabel
            // 
            winnerLabel.AutoSize = true;
            winnerLabel.Location = new System.Drawing.Point(16, 352);
            winnerLabel.Margin = new Padding(4, 0, 4, 0);
            winnerLabel.Name = "winnerLabel";
            winnerLabel.Size = new System.Drawing.Size(0, 20);
            winnerLabel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(299, 402);
            Controls.Add(winnerLabel);
            Controls.Add(voteButton);
            Controls.Add(candidateListBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Election System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
