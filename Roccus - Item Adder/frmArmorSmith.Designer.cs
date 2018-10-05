namespace Roccus___Item_Adder
{
    partial class frmArmorSmith
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.previewBtn = new System.Windows.Forms.Button();
            this.hotfixBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.itemIDTxt = new System.Windows.Forms.TextBox();
            this.iconFileDataIDTxt = new System.Windows.Forms.TextBox();
            this.materialBox = new System.Windows.Forms.ComboBox();
            this.inventoryTypeBox = new System.Windows.Forms.ComboBox();
            this.maxIDBtn = new System.Windows.Forms.Button();
            this.itemAppMaxIDBtn = new System.Windows.Forms.Button();
            this.objectSlotBox = new System.Windows.Forms.ComboBox();
            this.displayIDTxt = new System.Windows.Forms.TextBox();
            this.itemID2Txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemModAppMaxIDBtn = new System.Windows.Forms.Button();
            this.itemID3Txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemDescTxt = new System.Windows.Forms.TextBox();
            this.itemNameTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.qualityBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logoBox);
            this.groupBox1.Controls.Add(this.previewBox);
            this.groupBox1.Location = new System.Drawing.Point(383, 413);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // logoBox
            // 
            this.logoBox.BackgroundImage = global::Roccus___Item_Adder.Properties.Resources.temp;
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoBox.Location = new System.Drawing.Point(17, 29);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(57, 54);
            this.logoBox.TabIndex = 1;
            this.logoBox.TabStop = false;
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(7, 20);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(307, 173);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // previewBtn
            // 
            this.previewBtn.Location = new System.Drawing.Point(140, 413);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(114, 60);
            this.previewBtn.TabIndex = 1;
            this.previewBtn.Text = "Preview Armor";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // hotfixBtn
            // 
            this.hotfixBtn.Location = new System.Drawing.Point(140, 508);
            this.hotfixBtn.Name = "hotfixBtn";
            this.hotfixBtn.Size = new System.Drawing.Size(114, 60);
            this.hotfixBtn.TabIndex = 2;
            this.hotfixBtn.Text = "Hotfix";
            this.hotfixBtn.UseVisualStyleBackColor = true;
            this.hotfixBtn.Click += new System.EventHandler(this.hotfixBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "item :";
            // 
            // itemIDTxt
            // 
            this.itemIDTxt.Location = new System.Drawing.Point(43, 102);
            this.itemIDTxt.Name = "itemIDTxt";
            this.itemIDTxt.Size = new System.Drawing.Size(100, 20);
            this.itemIDTxt.TabIndex = 4;
            // 
            // iconFileDataIDTxt
            // 
            this.iconFileDataIDTxt.Enabled = false;
            this.iconFileDataIDTxt.Location = new System.Drawing.Point(43, 151);
            this.iconFileDataIDTxt.Name = "iconFileDataIDTxt";
            this.iconFileDataIDTxt.Size = new System.Drawing.Size(100, 20);
            this.iconFileDataIDTxt.TabIndex = 5;
            // 
            // materialBox
            // 
            this.materialBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialBox.FormattingEnabled = true;
            this.materialBox.Location = new System.Drawing.Point(33, 202);
            this.materialBox.Name = "materialBox";
            this.materialBox.Size = new System.Drawing.Size(121, 21);
            this.materialBox.TabIndex = 6;
            // 
            // inventoryTypeBox
            // 
            this.inventoryTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inventoryTypeBox.FormattingEnabled = true;
            this.inventoryTypeBox.Location = new System.Drawing.Point(33, 255);
            this.inventoryTypeBox.Name = "inventoryTypeBox";
            this.inventoryTypeBox.Size = new System.Drawing.Size(121, 21);
            this.inventoryTypeBox.TabIndex = 7;
            // 
            // maxIDBtn
            // 
            this.maxIDBtn.Location = new System.Drawing.Point(43, 52);
            this.maxIDBtn.Name = "maxIDBtn";
            this.maxIDBtn.Size = new System.Drawing.Size(100, 23);
            this.maxIDBtn.TabIndex = 9;
            this.maxIDBtn.Text = "max ID";
            this.maxIDBtn.UseVisualStyleBackColor = true;
            this.maxIDBtn.Click += new System.EventHandler(this.maxIDBtn_Click);
            // 
            // itemAppMaxIDBtn
            // 
            this.itemAppMaxIDBtn.Location = new System.Drawing.Point(196, 52);
            this.itemAppMaxIDBtn.Name = "itemAppMaxIDBtn";
            this.itemAppMaxIDBtn.Size = new System.Drawing.Size(100, 23);
            this.itemAppMaxIDBtn.TabIndex = 15;
            this.itemAppMaxIDBtn.Text = "max ID";
            this.itemAppMaxIDBtn.UseVisualStyleBackColor = true;
            this.itemAppMaxIDBtn.Click += new System.EventHandler(this.itemAppMaxIDBtn_Click);
            // 
            // objectSlotBox
            // 
            this.objectSlotBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objectSlotBox.FormattingEnabled = true;
            this.objectSlotBox.Location = new System.Drawing.Point(186, 202);
            this.objectSlotBox.Name = "objectSlotBox";
            this.objectSlotBox.Size = new System.Drawing.Size(121, 21);
            this.objectSlotBox.TabIndex = 13;
            // 
            // displayIDTxt
            // 
            this.displayIDTxt.Location = new System.Drawing.Point(196, 151);
            this.displayIDTxt.Name = "displayIDTxt";
            this.displayIDTxt.Size = new System.Drawing.Size(100, 20);
            this.displayIDTxt.TabIndex = 12;
            // 
            // itemID2Txt
            // 
            this.itemID2Txt.Location = new System.Drawing.Point(196, 102);
            this.itemID2Txt.Name = "itemID2Txt";
            this.itemID2Txt.Size = new System.Drawing.Size(100, 20);
            this.itemID2Txt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "item_app :";
            // 
            // itemModAppMaxIDBtn
            // 
            this.itemModAppMaxIDBtn.Location = new System.Drawing.Point(361, 52);
            this.itemModAppMaxIDBtn.Name = "itemModAppMaxIDBtn";
            this.itemModAppMaxIDBtn.Size = new System.Drawing.Size(100, 23);
            this.itemModAppMaxIDBtn.TabIndex = 20;
            this.itemModAppMaxIDBtn.Text = "max ID";
            this.itemModAppMaxIDBtn.UseVisualStyleBackColor = true;
            this.itemModAppMaxIDBtn.Click += new System.EventHandler(this.itemModAppMaxIDBtn_Click);
            // 
            // itemID3Txt
            // 
            this.itemID3Txt.Location = new System.Drawing.Point(361, 102);
            this.itemID3Txt.Name = "itemID3Txt";
            this.itemID3Txt.Size = new System.Drawing.Size(100, 20);
            this.itemID3Txt.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "item_mod_app :";
            // 
            // itemDescTxt
            // 
            this.itemDescTxt.Location = new System.Drawing.Point(553, 151);
            this.itemDescTxt.Name = "itemDescTxt";
            this.itemDescTxt.Size = new System.Drawing.Size(100, 20);
            this.itemDescTxt.TabIndex = 23;
            // 
            // itemNameTxt
            // 
            this.itemNameTxt.Location = new System.Drawing.Point(553, 102);
            this.itemNameTxt.Name = "itemNameTxt";
            this.itemNameTxt.Size = new System.Drawing.Size(100, 20);
            this.itemNameTxt.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(549, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "item_sparse :";
            // 
            // qualityBox
            // 
            this.qualityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityBox.FormattingEnabled = true;
            this.qualityBox.Location = new System.Drawing.Point(542, 202);
            this.qualityBox.Name = "qualityBox";
            this.qualityBox.Size = new System.Drawing.Size(121, 21);
            this.qualityBox.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Icon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Material";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(236, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "DisplayID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(236, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Slot";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(397, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "ID";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(581, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(571, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Description";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(581, 186);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Quality";
            // 
            // frmArmorSmith
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 624);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.qualityBox);
            this.Controls.Add(this.itemDescTxt);
            this.Controls.Add(this.itemNameTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.itemModAppMaxIDBtn);
            this.Controls.Add(this.itemID3Txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemAppMaxIDBtn);
            this.Controls.Add(this.objectSlotBox);
            this.Controls.Add(this.displayIDTxt);
            this.Controls.Add(this.itemID2Txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxIDBtn);
            this.Controls.Add(this.inventoryTypeBox);
            this.Controls.Add(this.materialBox);
            this.Controls.Add(this.iconFileDataIDTxt);
            this.Controls.Add(this.itemIDTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hotfixBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmArmorSmith";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmArmorSmith";
            this.Load += new System.EventHandler(this.frmArmorSmith_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Button previewBtn;
        private System.Windows.Forms.Button hotfixBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemIDTxt;
        private System.Windows.Forms.TextBox iconFileDataIDTxt;
        private System.Windows.Forms.ComboBox materialBox;
        private System.Windows.Forms.ComboBox inventoryTypeBox;
        private System.Windows.Forms.Button maxIDBtn;
        private System.Windows.Forms.Button itemAppMaxIDBtn;
        private System.Windows.Forms.ComboBox objectSlotBox;
        private System.Windows.Forms.TextBox displayIDTxt;
        private System.Windows.Forms.TextBox itemID2Txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button itemModAppMaxIDBtn;
        private System.Windows.Forms.TextBox itemID3Txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemDescTxt;
        private System.Windows.Forms.TextBox itemNameTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox qualityBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}