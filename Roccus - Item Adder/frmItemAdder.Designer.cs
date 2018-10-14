namespace Roccus___Item_Adder
{
    partial class frmItemAdder
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableList = new System.Windows.Forms.ComboBox();
            this.DBTableBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.db2Box = new System.Windows.Forms.ComboBox();
            this.DB2toCSVBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.proceduralHotfixBtn = new System.Windows.Forms.Button();
            this.weaponHotfixBtn = new System.Windows.Forms.Button();
            this.armorHotfixBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableList);
            this.groupBox1.Controls.Add(this.DBTableBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 517);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB Table Backup";
            // 
            // tableList
            // 
            this.tableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableList.FormattingEnabled = true;
            this.tableList.Location = new System.Drawing.Point(51, 172);
            this.tableList.Name = "tableList";
            this.tableList.Size = new System.Drawing.Size(146, 21);
            this.tableList.TabIndex = 3;
            // 
            // DBTableBtn
            // 
            this.DBTableBtn.Location = new System.Drawing.Point(36, 265);
            this.DBTableBtn.Name = "DBTableBtn";
            this.DBTableBtn.Size = new System.Drawing.Size(179, 80);
            this.DBTableBtn.TabIndex = 2;
            this.DBTableBtn.Text = "DB Table Backup";
            this.DBTableBtn.UseVisualStyleBackColor = true;
            this.DBTableBtn.Click += new System.EventHandler(this.DBTableBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.db2Box);
            this.groupBox2.Controls.Add(this.DB2toCSVBtn);
            this.groupBox2.Location = new System.Drawing.Point(592, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 517);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB2 To CSV Custom";
            // 
            // db2Box
            // 
            this.db2Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.db2Box.FormattingEnabled = true;
            this.db2Box.Location = new System.Drawing.Point(50, 173);
            this.db2Box.Name = "db2Box";
            this.db2Box.Size = new System.Drawing.Size(146, 21);
            this.db2Box.TabIndex = 4;
            // 
            // DB2toCSVBtn
            // 
            this.DB2toCSVBtn.Location = new System.Drawing.Point(35, 265);
            this.DB2toCSVBtn.Name = "DB2toCSVBtn";
            this.DB2toCSVBtn.Size = new System.Drawing.Size(179, 80);
            this.DB2toCSVBtn.TabIndex = 1;
            this.DB2toCSVBtn.Text = "DB2 to CSV Custom";
            this.DB2toCSVBtn.UseVisualStyleBackColor = true;
            this.DB2toCSVBtn.Click += new System.EventHandler(this.DB2toCSVBtn_Click);
            this.DB2toCSVBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DB2toCSVBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.proceduralHotfixBtn);
            this.groupBox3.Controls.Add(this.weaponHotfixBtn);
            this.groupBox3.Controls.Add(this.armorHotfixBtn);
            this.groupBox3.Location = new System.Drawing.Point(295, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 517);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hotfix Section";
            // 
            // proceduralHotfixBtn
            // 
            this.proceduralHotfixBtn.Location = new System.Drawing.Point(44, 416);
            this.proceduralHotfixBtn.Name = "proceduralHotfixBtn";
            this.proceduralHotfixBtn.Size = new System.Drawing.Size(179, 80);
            this.proceduralHotfixBtn.TabIndex = 2;
            this.proceduralHotfixBtn.Text = "Procedural Hotfix";
            this.proceduralHotfixBtn.UseVisualStyleBackColor = true;
            this.proceduralHotfixBtn.Click += new System.EventHandler(this.proceduralHotfixBtn_Click);
            // 
            // weaponHotfixBtn
            // 
            this.weaponHotfixBtn.Location = new System.Drawing.Point(44, 265);
            this.weaponHotfixBtn.Name = "weaponHotfixBtn";
            this.weaponHotfixBtn.Size = new System.Drawing.Size(179, 80);
            this.weaponHotfixBtn.TabIndex = 1;
            this.weaponHotfixBtn.Text = "Weapon Hotfix";
            this.weaponHotfixBtn.UseVisualStyleBackColor = true;
            this.weaponHotfixBtn.Click += new System.EventHandler(this.weaponHotfixBtn_Click);
            // 
            // armorHotfixBtn
            // 
            this.armorHotfixBtn.Location = new System.Drawing.Point(44, 114);
            this.armorHotfixBtn.Name = "armorHotfixBtn";
            this.armorHotfixBtn.Size = new System.Drawing.Size(179, 80);
            this.armorHotfixBtn.TabIndex = 0;
            this.armorHotfixBtn.Text = "Armor Hotfix";
            this.armorHotfixBtn.UseVisualStyleBackColor = true;
            this.armorHotfixBtn.Click += new System.EventHandler(this.armorHotfixBtn_Click);
            // 
            // frmItemAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 598);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmItemAdder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface";
            this.Load += new System.EventHandler(this.frmItemAdder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DBTableBtn;
        private System.Windows.Forms.Button DB2toCSVBtn;
        private System.Windows.Forms.Button proceduralHotfixBtn;
        private System.Windows.Forms.Button weaponHotfixBtn;
        private System.Windows.Forms.Button armorHotfixBtn;
        private System.Windows.Forms.ComboBox tableList;
        private System.Windows.Forms.ComboBox db2Box;
    }
}

