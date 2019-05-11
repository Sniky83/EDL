namespace Technicien_capteurs
{
    partial class FormAccueil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccueil));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_gestCapteur = new System.Windows.Forms.Button();
            this.btn_configRes = new System.Windows.Forms.Button();
            this.btn_aide = new System.Windows.Forms.Button();
            this.lbl_etat = new System.Windows.Forms.Label();
            this.btn_quitter = new System.Windows.Forms.Button();
            this.btn_configEnr = new System.Windows.Forms.Button();
            this.btn_mesurer = new System.Windows.Forms.Button();
            this.btn_connexion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, -54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_gestCapteur
            // 
            this.btn_gestCapteur.Location = new System.Drawing.Point(27, 143);
            this.btn_gestCapteur.Name = "btn_gestCapteur";
            this.btn_gestCapteur.Size = new System.Drawing.Size(150, 41);
            this.btn_gestCapteur.TabIndex = 1;
            this.btn_gestCapteur.Text = "Gestion des Capteurs";
            this.btn_gestCapteur.UseVisualStyleBackColor = true;
            this.btn_gestCapteur.Click += new System.EventHandler(this.btn_gestCapteur_Click);
            // 
            // btn_configRes
            // 
            this.btn_configRes.Location = new System.Drawing.Point(183, 143);
            this.btn_configRes.Name = "btn_configRes";
            this.btn_configRes.Size = new System.Drawing.Size(150, 41);
            this.btn_configRes.TabIndex = 2;
            this.btn_configRes.Text = "Configuration Réseau";
            this.btn_configRes.UseVisualStyleBackColor = true;
            this.btn_configRes.Click += new System.EventHandler(this.btn_configRes_Click);
            // 
            // btn_aide
            // 
            this.btn_aide.Location = new System.Drawing.Point(27, 237);
            this.btn_aide.Name = "btn_aide";
            this.btn_aide.Size = new System.Drawing.Size(150, 23);
            this.btn_aide.TabIndex = 3;
            this.btn_aide.Text = "Aide ?";
            this.btn_aide.UseVisualStyleBackColor = true;
            this.btn_aide.Click += new System.EventHandler(this.btn_aide_Click);
            // 
            // lbl_etat
            // 
            this.lbl_etat.AutoSize = true;
            this.lbl_etat.ForeColor = System.Drawing.Color.Red;
            this.lbl_etat.Location = new System.Drawing.Point(69, 273);
            this.lbl_etat.Name = "lbl_etat";
            this.lbl_etat.Size = new System.Drawing.Size(66, 13);
            this.lbl_etat.TabIndex = 4;
            this.lbl_etat.Text = "Déconnecté";
            // 
            // btn_quitter
            // 
            this.btn_quitter.Location = new System.Drawing.Point(183, 237);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(150, 23);
            this.btn_quitter.TabIndex = 5;
            this.btn_quitter.Text = "Quitter";
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
            // 
            // btn_configEnr
            // 
            this.btn_configEnr.Enabled = false;
            this.btn_configEnr.Location = new System.Drawing.Point(27, 190);
            this.btn_configEnr.Name = "btn_configEnr";
            this.btn_configEnr.Size = new System.Drawing.Size(150, 41);
            this.btn_configEnr.TabIndex = 6;
            this.btn_configEnr.Text = "Configuration de L\'Enregistreur";
            this.btn_configEnr.UseVisualStyleBackColor = true;
            this.btn_configEnr.Click += new System.EventHandler(this.btn_configEnr_Click);
            // 
            // btn_mesurer
            // 
            this.btn_mesurer.Enabled = false;
            this.btn_mesurer.Location = new System.Drawing.Point(183, 190);
            this.btn_mesurer.Name = "btn_mesurer";
            this.btn_mesurer.Size = new System.Drawing.Size(150, 41);
            this.btn_mesurer.TabIndex = 7;
            this.btn_mesurer.Text = "Mesurer";
            this.btn_mesurer.UseVisualStyleBackColor = true;
            this.btn_mesurer.Click += new System.EventHandler(this.btn_mesurer_Click);
            // 
            // btn_connexion
            // 
            this.btn_connexion.Enabled = false;
            this.btn_connexion.Location = new System.Drawing.Point(183, 268);
            this.btn_connexion.Name = "btn_connexion";
            this.btn_connexion.Size = new System.Drawing.Size(150, 23);
            this.btn_connexion.TabIndex = 8;
            this.btn_connexion.Text = "Se Connecter";
            this.btn_connexion.UseVisualStyleBackColor = true;
            this.btn_connexion.Click += new System.EventHandler(this.btn_connexion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "BDD :";
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 295);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connexion);
            this.Controls.Add(this.btn_mesurer);
            this.Controls.Add(this.btn_configEnr);
            this.Controls.Add(this.btn_quitter);
            this.Controls.Add(this.lbl_etat);
            this.Controls.Add(this.btn_aide);
            this.Controls.Add(this.btn_configRes);
            this.Controls.Add(this.btn_gestCapteur);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAccueil";
            this.Text = "Accueil";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_aide;
        private System.Windows.Forms.Button btn_quitter;
        public System.Windows.Forms.Button btn_gestCapteur;
        public System.Windows.Forms.Label lbl_etat;
        public System.Windows.Forms.Button btn_configEnr;
        public System.Windows.Forms.Button btn_mesurer;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btn_connexion;
        public System.Windows.Forms.Button btn_configRes;
    }
}

