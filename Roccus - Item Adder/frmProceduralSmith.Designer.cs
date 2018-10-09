namespace Roccus___Item_Adder
{
    partial class frmProceduralSmith
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
            this.DB2TextureBtn = new System.Windows.Forms.Button();
            this.DB2ItemBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DB2TextureBtn
            // 
            this.DB2TextureBtn.Location = new System.Drawing.Point(59, 78);
            this.DB2TextureBtn.Name = "DB2TextureBtn";
            this.DB2TextureBtn.Size = new System.Drawing.Size(207, 82);
            this.DB2TextureBtn.TabIndex = 0;
            this.DB2TextureBtn.Text = "Texture";
            this.DB2TextureBtn.UseVisualStyleBackColor = true;
            this.DB2TextureBtn.Click += new System.EventHandler(this.DB2TextureBtn_Click);
            // 
            // DB2ItemBtn
            // 
            this.DB2ItemBtn.Location = new System.Drawing.Point(59, 258);
            this.DB2ItemBtn.Name = "DB2ItemBtn";
            this.DB2ItemBtn.Size = new System.Drawing.Size(207, 82);
            this.DB2ItemBtn.TabIndex = 1;
            this.DB2ItemBtn.Text = "Model";
            this.DB2ItemBtn.UseVisualStyleBackColor = true;
            this.DB2ItemBtn.Click += new System.EventHandler(this.DB2ItemBtn_Click);
            // 
            // frmProceduralSmith
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 395);
            this.Controls.Add(this.DB2ItemBtn);
            this.Controls.Add(this.DB2TextureBtn);
            this.Name = "frmProceduralSmith";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmArmorSmith";
            this.Load += new System.EventHandler(this.frmProceduralSmith_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DB2TextureBtn;
        private System.Windows.Forms.Button DB2ItemBtn;
    }
}