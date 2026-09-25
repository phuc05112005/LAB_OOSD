namespace QuanLyKhachSan
{
    partial class Form2
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
            this.btnTestDB_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestDB_Click
            // 
            this.btnTestDB_Click.Location = new System.Drawing.Point(181, 106);
            this.btnTestDB_Click.Name = "btnTestDB_Click";
            this.btnTestDB_Click.Size = new System.Drawing.Size(264, 100);
            this.btnTestDB_Click.TabIndex = 0;
            this.btnTestDB_Click.Text = "button1";
            this.btnTestDB_Click.UseVisualStyleBackColor = true;
            this.btnTestDB_Click.Click += new System.EventHandler(this.btnTestDB_Click_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTestDB_Click);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestDB_Click;
    }
}