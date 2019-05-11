namespace Technicien_capteurs
{
    partial class FormGestionCapteurs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionCapteurs));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_modifier = new System.Windows.Forms.Button();
            this.btn_aide = new System.Windows.Forms.Button();
            this.tab_listeCapteurs = new System.Windows.Forms.DataGridView();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modele = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calibre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tab_listeCapteurs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 47.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liste des capteurs";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(15, 270);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(167, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "Ajouter";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Enabled = false;
            this.btn_delete.Location = new System.Drawing.Point(361, 270);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(167, 23);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "Supprimer";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(15, 299);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(254, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "Valider";
            this.btn_ok.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_modifier
            // 
            this.btn_modifier.Enabled = false;
            this.btn_modifier.Location = new System.Drawing.Point(188, 270);
            this.btn_modifier.Name = "btn_modifier";
            this.btn_modifier.Size = new System.Drawing.Size(167, 23);
            this.btn_modifier.TabIndex = 5;
            this.btn_modifier.Text = "Modifier";
            this.btn_modifier.UseVisualStyleBackColor = true;
            this.btn_modifier.Click += new System.EventHandler(this.btn_modifier_Click);
            // 
            // btn_aide
            // 
            this.btn_aide.Location = new System.Drawing.Point(275, 299);
            this.btn_aide.Name = "btn_aide";
            this.btn_aide.Size = new System.Drawing.Size(253, 23);
            this.btn_aide.TabIndex = 7;
            this.btn_aide.Text = "Aide ?";
            this.btn_aide.UseVisualStyleBackColor = true;
            // 
            // tab_listeCapteurs
            // 
            this.tab_listeCapteurs.AllowUserToDeleteRows = false;
            this.tab_listeCapteurs.AllowUserToResizeColumns = false;
            this.tab_listeCapteurs.AllowUserToResizeRows = false;
            this.tab_listeCapteurs.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tab_listeCapteurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tab_listeCapteurs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nom,
            this.Marque,
            this.modele,
            this.Calibre,
            this.A,
            this.B});
            this.tab_listeCapteurs.Location = new System.Drawing.Point(15, 73);
            this.tab_listeCapteurs.MultiSelect = false;
            this.tab_listeCapteurs.Name = "tab_listeCapteurs";
            this.tab_listeCapteurs.ReadOnly = true;
            this.tab_listeCapteurs.RowHeadersVisible = false;
            this.tab_listeCapteurs.RowHeadersWidth = 30;
            this.tab_listeCapteurs.Size = new System.Drawing.Size(513, 191);
            this.tab_listeCapteurs.TabIndex = 8;
            this.tab_listeCapteurs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tab_listeCapteurs_CellClick);
            this.tab_listeCapteurs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tab_listeCapteurs_CellDoubleClick);
            // 
            // Timer
            // 
            this.Timer.Interval = 3000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            this.Nom.Width = 160;
            // 
            // Marque
            // 
            this.Marque.HeaderText = "Marque";
            this.Marque.Name = "Marque";
            this.Marque.ReadOnly = true;
            // 
            // modele
            // 
            this.modele.HeaderText = "Modèle";
            this.modele.Name = "modele";
            this.modele.ReadOnly = true;
            // 
            // Calibre
            // 
            this.Calibre.HeaderText = "Calibre";
            this.Calibre.Name = "Calibre";
            this.Calibre.ReadOnly = true;
            this.Calibre.Width = 50;
            // 
            // A
            // 
            this.A.HeaderText = "A";
            this.A.Name = "A";
            this.A.ReadOnly = true;
            this.A.Width = 50;
            // 
            // B
            // 
            this.B.HeaderText = "B";
            this.B.Name = "B";
            this.B.ReadOnly = true;
            this.B.Width = 50;
            // 
            // FormGestionCapteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 333);
            this.Controls.Add(this.tab_listeCapteurs);
            this.Controls.Add(this.btn_aide);
            this.Controls.Add(this.btn_modifier);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormGestionCapteurs";
            this.Text = "Gestions des Capteurs";
            ((System.ComponentModel.ISupportInitialize)(this.tab_listeCapteurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_modifier;
        private System.Windows.Forms.Button btn_aide;
        public System.Windows.Forms.DataGridView tab_listeCapteurs;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marque;
        private System.Windows.Forms.DataGridViewTextBoxColumn modele;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calibre;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
    }
}