namespace Technicien_capteurs
{
    partial class FormMesures
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMesures));
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_aide = new System.Windows.Forms.Button();
            this.tab_Mesures = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Entrée = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom_entree_mesuree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom_Capteur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intensite_mesuree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tab_Mesures)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(12, 181);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(209, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Valider";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_aide
            // 
            this.btn_aide.Location = new System.Drawing.Point(226, 181);
            this.btn_aide.Name = "btn_aide";
            this.btn_aide.Size = new System.Drawing.Size(209, 23);
            this.btn_aide.TabIndex = 4;
            this.btn_aide.Text = "Aide ?";
            this.btn_aide.UseVisualStyleBackColor = true;
            // 
            // tab_Mesures
            // 
            this.tab_Mesures.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tab_Mesures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tab_Mesures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entrée,
            this.nom_entree_mesuree,
            this.Nom_Capteur,
            this.Intensite_mesuree});
            this.tab_Mesures.Location = new System.Drawing.Point(12, 41);
            this.tab_Mesures.MultiSelect = false;
            this.tab_Mesures.Name = "tab_Mesures";
            this.tab_Mesures.ReadOnly = true;
            this.tab_Mesures.RowHeadersVisible = false;
            this.tab_Mesures.Size = new System.Drawing.Size(423, 134);
            this.tab_Mesures.TabIndex = 6;
            this.tab_Mesures.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_Mesures_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Liste des entrées branchées sur l\'enregistreur";
            // 
            // Entrée
            // 
            dataGridViewCellStyle1.NullValue = "E1";
            this.Entrée.DefaultCellStyle = dataGridViewCellStyle1;
            this.Entrée.HeaderText = "Entrée";
            this.Entrée.Name = "Entrée";
            this.Entrée.ReadOnly = true;
            this.Entrée.Width = 50;
            // 
            // nom_entree_mesuree
            // 
            dataGridViewCellStyle2.NullValue = "Cuisine";
            this.nom_entree_mesuree.DefaultCellStyle = dataGridViewCellStyle2;
            this.nom_entree_mesuree.HeaderText = "Nom Entrée Mesurée";
            this.nom_entree_mesuree.Name = "nom_entree_mesuree";
            this.nom_entree_mesuree.ReadOnly = true;
            this.nom_entree_mesuree.Width = 160;
            // 
            // Nom_Capteur
            // 
            dataGridViewCellStyle3.NullValue = "Capteur Bleu";
            this.Nom_Capteur.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nom_Capteur.HeaderText = "Nom Capteur";
            this.Nom_Capteur.Name = "Nom_Capteur";
            this.Nom_Capteur.ReadOnly = true;
            this.Nom_Capteur.Width = 150;
            // 
            // Intensite_mesuree
            // 
            dataGridViewCellStyle4.NullValue = "1,2 A";
            this.Intensite_mesuree.DefaultCellStyle = dataGridViewCellStyle4;
            this.Intensite_mesuree.HeaderText = "Intensité Mesurée";
            this.Intensite_mesuree.Name = "Intensite_mesuree";
            this.Intensite_mesuree.ReadOnly = true;
            this.Intensite_mesuree.Width = 60;
            // 
            // FormMesures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 213);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tab_Mesures);
            this.Controls.Add(this.btn_aide);
            this.Controls.Add(this.btn_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMesures";
            this.Text = "Mesures en instantané";
            ((System.ComponentModel.ISupportInitialize)(this.tab_Mesures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_aide;
        private System.Windows.Forms.DataGridView tab_Mesures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrée;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom_entree_mesuree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom_Capteur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intensite_mesuree;
    }
}