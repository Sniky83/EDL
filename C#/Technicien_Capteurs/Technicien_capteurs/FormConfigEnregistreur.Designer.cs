namespace Technicien_capteurs
{
    partial class FormConfigEnregistreur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigEnregistreur));
            this.tab_listeEnr = new System.Windows.Forms.DataGridView();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_aide = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_modifier = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tab_listeEnr)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_listeEnr
            // 
            this.tab_listeEnr.AllowUserToAddRows = false;
            this.tab_listeEnr.AllowUserToDeleteRows = false;
            this.tab_listeEnr.AllowUserToResizeColumns = false;
            this.tab_listeEnr.AllowUserToResizeRows = false;
            this.tab_listeEnr.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tab_listeEnr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tab_listeEnr.Location = new System.Drawing.Point(16, 59);
            this.tab_listeEnr.MultiSelect = false;
            this.tab_listeEnr.Name = "tab_listeEnr";
            this.tab_listeEnr.ReadOnly = true;
            this.tab_listeEnr.RowHeadersVisible = false;
            this.tab_listeEnr.Size = new System.Drawing.Size(353, 150);
            this.tab_listeEnr.TabIndex = 0;
            this.tab_listeEnr.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tab_listeEnr_CellClick);
            this.tab_listeEnr.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tab_listeEnr_CellDoubleClick);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(16, 244);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(174, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "Valider";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_aide
            // 
            this.btn_aide.Location = new System.Drawing.Point(195, 244);
            this.btn_aide.Name = "btn_aide";
            this.btn_aide.Size = new System.Drawing.Size(174, 23);
            this.btn_aide.TabIndex = 2;
            this.btn_aide.Text = "Aide ?";
            this.btn_aide.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(16, 215);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(114, 23);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Ajouter";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_modifier
            // 
            this.btn_modifier.Enabled = false;
            this.btn_modifier.Location = new System.Drawing.Point(135, 215);
            this.btn_modifier.Name = "btn_modifier";
            this.btn_modifier.Size = new System.Drawing.Size(114, 23);
            this.btn_modifier.TabIndex = 5;
            this.btn_modifier.Text = "Modifier";
            this.btn_modifier.UseVisualStyleBackColor = true;
            this.btn_modifier.Click += new System.EventHandler(this.btn_modifier_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Enabled = false;
            this.btn_delete.Location = new System.Drawing.Point(255, 215);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(114, 23);
            this.btn_delete.TabIndex = 6;
            this.btn_delete.Text = "Supprimer";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 33.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 52);
            this.label1.TabIndex = 7;
            this.label1.Text = "Liste des entrées";
            // 
            // FormConfigEnregistreur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 278);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_modifier);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_aide);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tab_listeEnr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormConfigEnregistreur";
            this.Text = "Configuration enregistreur";
            ((System.ComponentModel.ISupportInitialize)(this.tab_listeEnr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tab_listeEnr;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_aide;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_modifier;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label1;
    }
}