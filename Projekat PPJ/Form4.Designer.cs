namespace Projekat_PPJ
{
    partial class Form4
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
            this.buttonBrisanjeNarudzbe = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.buttonBrisanjeNarudzbe);
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("HP Simplified", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(911, 480);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonBrisanjeNarudzbe
            // 
            this.buttonBrisanjeNarudzbe.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonBrisanjeNarudzbe.Location = new System.Drawing.Point(403, 399);
            this.buttonBrisanjeNarudzbe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBrisanjeNarudzbe.Name = "buttonBrisanjeNarudzbe";
            this.buttonBrisanjeNarudzbe.Size = new System.Drawing.Size(149, 34);
            this.buttonBrisanjeNarudzbe.TabIndex = 3;
            this.buttonBrisanjeNarudzbe.Text = "Brisanje narudžbe";
            this.buttonBrisanjeNarudzbe.UseVisualStyleBackColor = false;
            this.buttonBrisanjeNarudzbe.Click += new System.EventHandler(this.buttonBrisanjeNarudzbe_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(239, 402);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(132, 28);
            this.textBoxId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 406);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID narudžbe:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(97, 63);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(729, 259);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(944, 32);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dodavanjeAžuriranjeArtiklaToolStripMenuItem
            // 
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem,
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem1,
            this.loginToolStripMenuItem});
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem.Name = "dodavanjeAžuriranjeArtiklaToolStripMenuItem";
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem.Text = "Meni";
            // 
            // kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem
            // 
            this.kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem.Name = "kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem";
            this.kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem.Size = new System.Drawing.Size(508, 28);
            this.kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem.Text = "Kreiranje novog kupca / Ažuriranje postojećeg kupca";
            this.kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem.Click += new System.EventHandler(this.kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem_Click);
            // 
            // dodavanjeAžuriranjeArtiklaToolStripMenuItem1
            // 
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem1.Name = "dodavanjeAžuriranjeArtiklaToolStripMenuItem1";
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem1.Size = new System.Drawing.Size(508, 28);
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem1.Text = "Dodavanje / Ažuriranje artikla";
            this.dodavanjeAžuriranjeArtiklaToolStripMenuItem1.Click += new System.EventHandler(this.dodavanjeAžuriranjeArtiklaToolStripMenuItem1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HP Simplified", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prikaz / Brisanje narudžbe";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label10.Font = new System.Drawing.Font("HP Simplified", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(916, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 32);
            this.label10.TabIndex = 22;
            this.label10.Text = "x";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(508, 28);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(944, 534);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prikaz / Brisanje narudžbe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBrisanjeNarudzbe;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodavanjeAžuriranjeArtiklaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreiranjeNovogKupcaAžuriranjePostojećegKupcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodavanjeAžuriranjeArtiklaToolStripMenuItem1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
    }
}