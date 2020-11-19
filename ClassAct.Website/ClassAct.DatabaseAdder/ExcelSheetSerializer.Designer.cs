namespace ClassAct.DatabaseAdder
{
    partial class ExcelSheetSerializer
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnName = new System.Windows.Forms.Button();
            this.btnAddFeaturesToResturants = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "SerializeData";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(185, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(229, 77);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add Data to DB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(257, 130);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(75, 23);
            this.btnName.TabIndex = 5;
            this.btnName.Text = "features";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // btnAddFeaturesToResturants
            // 
            this.btnAddFeaturesToResturants.Location = new System.Drawing.Point(53, 207);
            this.btnAddFeaturesToResturants.Name = "btnAddFeaturesToResturants";
            this.btnAddFeaturesToResturants.Size = new System.Drawing.Size(265, 23);
            this.btnAddFeaturesToResturants.TabIndex = 6;
            this.btnAddFeaturesToResturants.Text = "AddFeatures to resturants";
            this.btnAddFeaturesToResturants.UseVisualStyleBackColor = true;
            this.btnAddFeaturesToResturants.Click += new System.EventHandler(this.btnAddFeaturesToResturants_Click);
            // 
            // ExcelSheetSerializer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 344);
            this.Controls.Add(this.btnAddFeaturesToResturants);
            this.Controls.Add(this.btnName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "ExcelSheetSerializer";
            this.Text = "ExcelSheetSerializer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.Button btnAddFeaturesToResturants;
    }
}