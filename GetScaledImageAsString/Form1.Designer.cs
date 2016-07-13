namespace GetScaledImageAsString
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
            this.btnScale = new System.Windows.Forms.Button();
            this.txbImage = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.gvSize = new System.Windows.Forms.DataGridView();
            this.btnGetImageAsString = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScale
            // 
            this.btnScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScale.Location = new System.Drawing.Point(364, 236);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(75, 23);
            this.btnScale.TabIndex = 0;
            this.btnScale.Text = "Scale";
            this.btnScale.UseVisualStyleBackColor = true;
            this.btnScale.Click += new System.EventHandler(this.btnScale_Click);
            // 
            // txbImage
            // 
            this.txbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbImage.Location = new System.Drawing.Point(85, 12);
            this.txbImage.Name = "txbImage";
            this.txbImage.Size = new System.Drawing.Size(315, 22);
            this.txbImage.TabIndex = 1;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseImage.Location = new System.Drawing.Point(406, 13);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(33, 23);
            this.btnBrowseImage.TabIndex = 2;
            this.btnBrowseImage.Text = "...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(12, 15);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(46, 17);
            this.lblImage.TabIndex = 3;
            this.lblImage.Text = "Image";
            // 
            // gvSize
            // 
            this.gvSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSize.Location = new System.Drawing.Point(85, 40);
            this.gvSize.Name = "gvSize";
            this.gvSize.RowTemplate.Height = 24;
            this.gvSize.Size = new System.Drawing.Size(315, 150);
            this.gvSize.TabIndex = 4;
            // 
            // btnGetImageAsString
            // 
            this.btnGetImageAsString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetImageAsString.Location = new System.Drawing.Point(195, 236);
            this.btnGetImageAsString.Name = "btnGetImageAsString";
            this.btnGetImageAsString.Size = new System.Drawing.Size(163, 23);
            this.btnGetImageAsString.TabIndex = 0;
            this.btnGetImageAsString.Text = "Get as Base64 string";
            this.btnGetImageAsString.UseVisualStyleBackColor = true;
            this.btnGetImageAsString.Click += new System.EventHandler(this.btnGetImageAsString_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 271);
            this.Controls.Add(this.gvSize);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.txbImage);
            this.Controls.Add(this.btnGetImageAsString);
            this.Controls.Add(this.btnScale);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gvSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScale;
        private System.Windows.Forms.TextBox txbImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.DataGridView gvSize;
        private System.Windows.Forms.Button btnGetImageAsString;
    }
}

