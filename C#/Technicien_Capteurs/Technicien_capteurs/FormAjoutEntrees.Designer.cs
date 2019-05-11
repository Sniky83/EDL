namespace Technicien_capteurs
{
    partial class FormAjoutEntrees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAjoutEntrees));
            this.lbl_input = new System.Windows.Forms.Label();
            this.lbl_capteur = new System.Windows.Forms.Label();
            this.cmbBox_input = new System.Windows.Forms.ComboBox();
            this.cmbBox_capteur = new System.Windows.Forms.ComboBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_aide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_nom_entree = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_input
            // 
            this.lbl_input.AutoSize = true;
            this.lbl_input.Location = new System.Drawing.Point(12, 14);
            this.lbl_input.Name = "lbl_input";
            this.lbl_input.Size = new System.Drawing.Size(38, 13);
            this.lbl_input.TabIndex = 0;
            this.lbl_input.Text = "Entrée";
            // 
            // lbl_capteur
            // 
            this.lbl_capteur.AutoSize = true;
            this.lbl_capteur.Location = new System.Drawing.Point(6, 53);
            this.lbl_capteur.Name = "lbl_capteur";
            this.lbl_capteur.Size = new System.Drawing.Size(44, 13);
            this.lbl_capteur.TabIndex = 1;
            this.lbl_capteur.Text = "Capteur";
            // 
            // cmbBox_input
            // 
            this.cmbBox_input.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_input.FormattingEnabled = true;
            this.cmbBox_input.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbBox_input.Location = new System.Drawing.Point(56, 11);
            this.cmbBox_input.Name = "cmbBox_input";
            this.cmbBox_input.Size = new System.Drawing.Size(187, 21);
            this.cmbBox_input.TabIndex = 2;
            // 
            // cmbBox_capteur
            // 
            this.cmbBox_capteur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_capteur.FormattingEnabled = true;
            this.cmbBox_capteur.Location = new System.Drawing.Point(56, 50);
            this.cmbBox_capteur.Name = "cmbBox_capteur";
            this.cmbBox_capteur.Size = new System.Drawing.Size(187, 21);
            this.cmbBox_capteur.TabIndex = 3;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(9, 127);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "Valider";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(168, 127);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Annuler";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_aide
            // 
            this.btn_aide.Location = new System.Drawing.Point(88, 127);
            this.btn_aide.Name = "btn_aide";
            this.btn_aide.Size = new System.Drawing.Size(75, 23);
            this.btn_aide.TabIndex = 6;
            this.btn_aide.Text = "Aide ?";
            this.btn_aide.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nom entrée mesurée";
            // 
            // txtBox_nom_entree
            // 
            this.txtBox_nom_entree.Location = new System.Drawing.Point(117, 90);
            this.txtBox_nom_entree.Name = "txtBox_nom_entree";
            this.txtBox_nom_entree.Size = new System.Drawing.Size(126, 20);
            this.txtBox_nom_entree.TabIndex = 8;
            // 
            // FormAjoutEntrees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 158);
            this.Controls.Add(this.txtBox_nom_entree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_aide);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.cmbBox_capteur);
            this.Controls.Add(this.cmbBox_input);
            this.Controls.Add(this.lbl_capteur);
            this.Controls.Add(this.lbl_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAjoutEntrees";
            this.Text = "Ajout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_input;
        private System.Windows.Forms.Label lbl_capteur;
        private System.Windows.Forms.ComboBox cmbBox_input;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_aide;
        private System.Windows.Forms.ComboBox cmbBox_capteur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_nom_entree;
    }
}