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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMesures));
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_aide = new System.Windows.Forms.Button();
            this.tab_Mesures = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Timer_Refresh_Tab = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tab_Mesures)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 181);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(209, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "Valider";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_aide
            // 
            this.btn_aide.Location = new System.Drawing.Point(226, 181);
            this.btn_aide.Name = "btn_aide";
            this.btn_aide.Size = new System.Drawing.Size(209, 23);
            this.btn_aide.TabIndex = 4;
            this.btn_aide.Text = "Aide ?";
            this.btn_aide.UseVisualStyleBackColor = true;
            this.btn_aide.Click += new System.EventHandler(this.Btn_aide_Click);
            // 
            // tab_Mesures
            // 
            this.tab_Mesures.AllowUserToAddRows = false;
            this.tab_Mesures.AllowUserToDeleteRows = false;
            this.tab_Mesures.AllowUserToResizeColumns = false;
            this.tab_Mesures.AllowUserToResizeRows = false;
            this.tab_Mesures.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tab_Mesures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tab_Mesures.Location = new System.Drawing.Point(12, 41);
            this.tab_Mesures.MultiSelect = false;
            this.tab_Mesures.Name = "tab_Mesures";
            this.tab_Mesures.ReadOnly = true;
            this.tab_Mesures.RowHeadersVisible = false;
            this.tab_Mesures.Size = new System.Drawing.Size(423, 134);
            this.tab_Mesures.TabIndex = 6;
            this.tab_Mesures.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_Mesures_CellClick);
            this.tab_Mesures.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tab_Mesures_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Liste des capteurs présents sur l\'enregistreur";
            // 
            // Timer_Refresh_Tab
            // 
            this.Timer_Refresh_Tab.Enabled = true;
            this.Timer_Refresh_Tab.Interval = 2000;
            this.Timer_Refresh_Tab.Tick += new System.EventHandler(this.Timer_Refresh_Tab_Tick);
            // 
            // FormMesures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 213);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tab_Mesures);
            this.Controls.Add(this.btn_aide);
            this.Controls.Add(this.btn_ok);
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
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_aide;
        private System.Windows.Forms.DataGridView tab_Mesures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Timer_Refresh_Tab;
    }
}