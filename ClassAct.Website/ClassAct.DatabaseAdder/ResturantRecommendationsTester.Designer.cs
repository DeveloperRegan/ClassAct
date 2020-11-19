namespace ClassAct.DatabaseAdder
{
    partial class ResturantRecommendationsTester
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
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 16;
            this.lstRecommendations.Location = new System.Drawing.Point(144, 12);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(554, 356);
            this.lstRecommendations.TabIndex = 0;
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(30, 39);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 1;
            this.btnGO.Text = "Go";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // ResturantRecommendationsTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 386);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.lstRecommendations);
            this.Name = "ResturantRecommendationsTester";
            this.Text = "ResturantRecommendationsTester";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Button btnGO;
    }
}