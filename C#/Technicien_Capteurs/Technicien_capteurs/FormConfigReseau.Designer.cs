namespace Technicien_capteurs
{
    partial class FormConfigReseau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigReseau));
            this.lbl_ip = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_dbn = new System.Windows.Forms.Label();
            this.txtBox_ip = new System.Windows.Forms.TextBox();
            this.txtBox_username = new System.Windows.Forms.TextBox();
            this.txtBox_password = new System.Windows.Forms.TextBox();
            this.txtBox_dbn = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_aide = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_ipArduino = new System.Windows.Forms.Label();
            this.txtBox_ipArduino = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(91, 29);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(58, 13);
            this.lbl_ip.TabIndex = 0;
            this.lbl_ip.Text = "Adresse IP";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(65, 63);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(84, 13);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "Nom d\'utilisateur";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(77, 97);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(72, 13);
            this.lbl_password.TabIndex = 2;
            this.lbl_password.Text = "Mot de Passe";
            // 
            // lbl_dbn
            // 
            this.lbl_dbn.AutoSize = true;
            this.lbl_dbn.Location = new System.Drawing.Point(1, 123);
            this.lbl_dbn.Name = "lbl_dbn";
            this.lbl_dbn.Size = new System.Drawing.Size(140, 13);
            this.lbl_dbn.TabIndex = 3;
            this.lbl_dbn.Text = "Nom de la base de données";
            // 
            // txtBox_ip
            // 
            this.txtBox_ip.Location = new System.Drawing.Point(155, 26);
            this.txtBox_ip.Name = "txtBox_ip";
            this.txtBox_ip.Size = new System.Drawing.Size(174, 20);
            this.txtBox_ip.TabIndex = 4;
            this.txtBox_ip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_ip_KeyPress);
            // 
            // txtBox_username
            // 
            this.txtBox_username.Location = new System.Drawing.Point(155, 60);
            this.txtBox_username.Name = "txtBox_username";
            this.txtBox_username.Size = new System.Drawing.Size(174, 20);
            this.txtBox_username.TabIndex = 5;
            // 
            // txtBox_password
            // 
            this.txtBox_password.Location = new System.Drawing.Point(155, 94);
            this.txtBox_password.Name = "txtBox_password";
            this.txtBox_password.PasswordChar = '*';
            this.txtBox_password.Size = new System.Drawing.Size(174, 20);
            this.txtBox_password.TabIndex = 6;
            // 
            // txtBox_dbn
            // 
            this.txtBox_dbn.Location = new System.Drawing.Point(155, 127);
            this.txtBox_dbn.Name = "txtBox_dbn";
            this.txtBox_dbn.Size = new System.Drawing.Size(174, 20);
            this.txtBox_dbn.TabIndex = 7;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(9, 285);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(105, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "Valider";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_aide
            // 
            this.btn_aide.Location = new System.Drawing.Point(121, 285);
            this.btn_aide.Name = "btn_aide";
            this.btn_aide.Size = new System.Drawing.Size(105, 23);
            this.btn_aide.TabIndex = 9;
            this.btn_aide.Text = "Aide ?";
            this.btn_aide.UseVisualStyleBackColor = true;
            this.btn_aide.Click += new System.EventHandler(this.Btn_aide_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(233, 285);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(105, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "Annuler";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_dbn);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 180);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base de Données";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_ipArduino);
            this.groupBox2.Controls.Add(this.txtBox_ipArduino);
            this.groupBox2.Location = new System.Drawing.Point(9, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 70);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enregistreur";
            // 
            // lbl_ipArduino
            // 
            this.lbl_ipArduino.AutoSize = true;
            this.lbl_ipArduino.Location = new System.Drawing.Point(82, 27);
            this.lbl_ipArduino.Name = "lbl_ipArduino";
            this.lbl_ipArduino.Size = new System.Drawing.Size(58, 13);
            this.lbl_ipArduino.TabIndex = 1;
            this.lbl_ipArduino.Text = "Adresse IP";
            // 
            // txtBox_ipArduino
            // 
            this.txtBox_ipArduino.Location = new System.Drawing.Point(146, 24);
            this.txtBox_ipArduino.Name = "txtBox_ipArduino";
            this.txtBox_ipArduino.Size = new System.Drawing.Size(174, 20);
            this.txtBox_ipArduino.TabIndex = 0;
            this.txtBox_ipArduino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_ipArduino_KeyPress);
            // 
            // FormConfigReseau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 319);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_aide);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txtBox_dbn);
            this.Controls.Add(this.txtBox_password);
            this.Controls.Add(this.txtBox_username);
            this.Controls.Add(this.txtBox_ip);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormConfigReseau";
            this.Text = "Configuration Réseau";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_aide;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtBox_ip;
        public System.Windows.Forms.TextBox txtBox_username;
        public System.Windows.Forms.TextBox txtBox_password;
        public System.Windows.Forms.TextBox txtBox_dbn;
        public System.Windows.Forms.Label lbl_ip;
        public System.Windows.Forms.Label lbl_username;
        public System.Windows.Forms.Label lbl_password;
        public System.Windows.Forms.Label lbl_dbn;
        public System.Windows.Forms.Label lbl_ipArduino;
        public System.Windows.Forms.TextBox txtBox_ipArduino;
    }
}