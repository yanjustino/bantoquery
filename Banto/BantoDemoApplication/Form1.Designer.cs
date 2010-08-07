namespace BantoDemoApplication
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnConverter = new System.Windows.Forms.Button();
            this.txtLDM = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "LMD Text";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(538, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL Command";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConverter
            // 
            this.btnConverter.Location = new System.Drawing.Point(3, 401);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(162, 31);
            this.btnConverter.TabIndex = 4;
            this.btnConverter.Text = "Converter";
            this.btnConverter.UseVisualStyleBackColor = true;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // txtLDM
            // 
            this.txtLDM.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLDM.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLDM.Location = new System.Drawing.Point(0, 23);
            this.txtLDM.Multiline = true;
            this.txtLDM.Name = "txtLDM";
            this.txtLDM.Size = new System.Drawing.Size(538, 173);
            this.txtLDM.TabIndex = 5;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 222);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(514, 150);
            this.dataGridView2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 438);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnConverter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLDM);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Banto Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConverter;
        private System.Windows.Forms.TextBox txtLDM;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

