namespace Technicien_capteurs
{
    partial class FormAjoutCapteur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAjoutCapteur));
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_marque = new System.Windows.Forms.Label();
            this.lbl_model = new System.Windows.Forms.Label();
            this.lbl_calibre = new System.Windows.Forms.Label();
            this.btn_aide = new System.Windows.Forms.Button();
            this.txtBox_marque = new System.Windows.Forms.TextBox();
            this.txtBox_name = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txtBox_model = new System.Windows.Forms.TextBox();
            this.numUpDown_calibre = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_a = new System.Windows.Forms.Label();
            this.lbl_b = new System.Windows.Forms.Label();
            this.txtBox_b = new System.Windows.Forms.TextBox();
            this.txtBox_a = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_calibre)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(58, 15);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(29, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Nom";
            // 
            // lbl_marque
            // 
            this.lbl_marque.AutoSize = true;
            this.lbl_marque.Location = new System.Drawing.Point(46, 41);
            this.lbl_marque.Name = "lbl_marque";
            this.lbl_marque.Size = new System.Drawing.Size(43, 13);
            this.lbl_marque.TabIndex = 3;
            this.lbl_marque.Text = "Marque";
            // 
            // lbl_model
            // 
            this.lbl_model.AutoSize = true;
            this.lbl_model.Location = new System.Drawing.Point(45, 67);
            this.lbl_model.Name = "lbl_model";
            this.lbl_model.Size = new System.Drawing.Size(42, 13);
            this.lbl_model.TabIndex = 4;
            this.lbl_model.Text = "Modèle";
            // 
            // lbl_calibre
            // 
            this.lbl_calibre.AutoSize = true;
            this.lbl_calibre.Location = new System.Drawing.Point(48, 92);
            this.lbl_calibre.Name = "lbl_calibre";
            this.lbl_calibre.Size = new System.Drawing.Size(39, 13);
            this.lbl_calibre.TabIndex = 5;
            this.lbl_calibre.Text = "Calibre";
            // 
            // btn_aide
            // 
            this.btn_aide.Location = new System.Drawing.Point(101, 171);
            this.btn_aide.Name = "btn_aide";
            this.btn_aide.Size = new System.Drawing.Size(75, 23);
            this.btn_aide.TabIndex = 8;
            this.btn_aide.Text = "Aide ?";
            this.btn_aide.UseVisualStyleBackColor = true;
            // 
            // txtBox_marque
            // 
            this.txtBox_marque.Location = new System.Drawing.Point(93, 38);
            this.txtBox_marque.Name = "txtBox_marque";
            this.txtBox_marque.Size = new System.Drawing.Size(163, 20);
            this.txtBox_marque.TabIndex = 12;
            // 
            // txtBox_name
            // 
            this.txtBox_name.Location = new System.Drawing.Point(93, 12);
            this.txtBox_name.Name = "txtBox_name";
            this.txtBox_name.Size = new System.Drawing.Size(163, 20);
            this.txtBox_name.TabIndex = 13;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(20, 171);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 20;
            this.btn_ok.Text = "Valider";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(182, 171);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 21;
            this.btn_cancel.Text = "Annuler";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txtBox_model
            // 
            this.txtBox_model.Location = new System.Drawing.Point(93, 64);
            this.txtBox_model.Name = "txtBox_model";
            this.txtBox_model.Size = new System.Drawing.Size(163, 20);
            this.txtBox_model.TabIndex = 22;
            // 
            // numUpDown_calibre
            // 
            this.numUpDown_calibre.Location = new System.Drawing.Point(93, 90);
            this.numUpDown_calibre.Name = "numUpDown_calibre";
            this.numUpDown_calibre.Size = new System.Drawing.Size(143, 20);
            this.numUpDown_calibre.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(241, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "A";
            // 
            // lbl_a
            // 
            this.lbl_a.AutoSize = true;
            this.lbl_a.Location = new System.Drawing.Point(73, 119);
            this.lbl_a.Name = "lbl_a";
            this.lbl_a.Size = new System.Drawing.Size(14, 13);
            this.lbl_a.TabIndex = 25;
            this.lbl_a.Text = "A";
            // 
            // lbl_b
            // 
            this.lbl_b.AutoSize = true;
            this.lbl_b.Location = new System.Drawing.Point(73, 145);
            this.lbl_b.Name = "lbl_b";
            this.lbl_b.Size = new System.Drawing.Size(14, 13);
            this.lbl_b.TabIndex = 26;
            this.lbl_b.Text = "B";
            // 
            // txtBox_b
            // 
            this.txtBox_b.Location = new System.Drawing.Point(93, 142);
            this.txtBox_b.MaxLength = 8;
            this.txtBox_b.Name = "txtBox_b";
            this.txtBox_b.Size = new System.Drawing.Size(163, 20);
            this.txtBox_b.TabIndex = 27;
            this.txtBox_b.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_b_KeyPress);
            // 
            // txtBox_a
            // 
            this.txtBox_a.Location = new System.Drawing.Point(93, 116);
            this.txtBox_a.MaxLength = 8;
            this.txtBox_a.Name = "txtBox_a";
            this.txtBox_a.Size = new System.Drawing.Size(163, 20);
            this.txtBox_a.TabIndex = 28;
            this.txtBox_a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_a_KeyPress);
            // 
            // FormAjoutCapteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 204);
            this.Controls.Add(this.txtBox_a);
            this.Controls.Add(this.txtBox_b);
            this.Controls.Add(this.lbl_b);
            this.Controls.Add(this.lbl_a);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numUpDown_calibre);
            this.Controls.Add(this.txtBox_model);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txtBox_name);
            this.Controls.Add(this.txtBox_marque);
            this.Controls.Add(this.btn_aide);
            this.Controls.Add(this.lbl_calibre);
            this.Controls.Add(this.lbl_model);
            this.Controls.Add(this.lbl_marque);
            this.Controls.Add(this.lbl_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAjoutCapteur";
            this.Text = "Ajout d\'un capteur";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_calibre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_marque;
        private System.Windows.Forms.Label lbl_model;
        private System.Windows.Forms.Label lbl_calibre;
        private System.Windows.Forms.Button btn_aide;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_a;
        private System.Windows.Forms.Label lbl_b;
        public System.Windows.Forms.TextBox txtBox_name;
        public System.Windows.Forms.TextBox txtBox_marque;
        public System.Windows.Forms.TextBox txtBox_model;
        public System.Windows.Forms.NumericUpDown numUpDown_calibre;
        public System.Windows.Forms.TextBox txtBox_b;
        public System.Windows.Forms.TextBox txtBox_a;
    }
}