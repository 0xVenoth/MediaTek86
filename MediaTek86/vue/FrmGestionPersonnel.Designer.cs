namespace MediaTek86.vue
{
    partial class FrmGestionPersonnel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.dgvPersonnel = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnGererAbsences = new System.Windows.Forms.Button();
            this.grpPersonnel = new System.Windows.Forms.GroupBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnulerSaisie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.grpPersonnel.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitre
            //
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location = new System.Drawing.Point(12, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(259, 25);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion du personnel";
            //
            // dgvPersonnel
            //
            this.dgvPersonnel.AllowUserToAddRows = false;
            this.dgvPersonnel.AllowUserToDeleteRows = false;
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Location = new System.Drawing.Point(12, 55);
            this.dgvPersonnel.MultiSelect = false;
            this.dgvPersonnel.Name = "dgvPersonnel";
            this.dgvPersonnel.ReadOnly = true;
            this.dgvPersonnel.RowHeadersVisible = false;
            this.dgvPersonnel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonnel.Size = new System.Drawing.Size(520, 360);
            this.dgvPersonnel.TabIndex = 1;
            //
            // btnAjouter
            //
            this.btnAjouter.Location = new System.Drawing.Point(12, 430);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(110, 32);
            this.btnAjouter.TabIndex = 2;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            //
            // btnModifier
            //
            this.btnModifier.Location = new System.Drawing.Point(135, 430);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(110, 32);
            this.btnModifier.TabIndex = 3;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            //
            // btnSupprimer
            //
            this.btnSupprimer.Location = new System.Drawing.Point(258, 430);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(110, 32);
            this.btnSupprimer.TabIndex = 4;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            //
            // btnGererAbsences
            //
            this.btnGererAbsences.Location = new System.Drawing.Point(381, 430);
            this.btnGererAbsences.Name = "btnGererAbsences";
            this.btnGererAbsences.Size = new System.Drawing.Size(151, 32);
            this.btnGererAbsences.TabIndex = 5;
            this.btnGererAbsences.Text = "Gérer les absences";
            this.btnGererAbsences.UseVisualStyleBackColor = true;
            //
            // grpPersonnel
            //
            this.grpPersonnel.Controls.Add(this.lblNom);
            this.grpPersonnel.Controls.Add(this.txtNom);
            this.grpPersonnel.Controls.Add(this.lblPrenom);
            this.grpPersonnel.Controls.Add(this.txtPrenom);
            this.grpPersonnel.Controls.Add(this.lblTel);
            this.grpPersonnel.Controls.Add(this.txtTel);
            this.grpPersonnel.Controls.Add(this.lblMail);
            this.grpPersonnel.Controls.Add(this.txtMail);
            this.grpPersonnel.Controls.Add(this.lblService);
            this.grpPersonnel.Controls.Add(this.cboService);
            this.grpPersonnel.Controls.Add(this.btnEnregistrer);
            this.grpPersonnel.Controls.Add(this.btnAnnulerSaisie);
            this.grpPersonnel.Location = new System.Drawing.Point(560, 55);
            this.grpPersonnel.Name = "grpPersonnel";
            this.grpPersonnel.Size = new System.Drawing.Size(320, 360);
            this.grpPersonnel.TabIndex = 6;
            this.grpPersonnel.TabStop = false;
            this.grpPersonnel.Text = "Détail du personnel";
            //
            // lblNom
            //
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(20, 40);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(38, 15);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom :";
            //
            // txtNom
            //
            this.txtNom.Location = new System.Drawing.Point(110, 37);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(190, 23);
            this.txtNom.TabIndex = 1;
            //
            // lblPrenom
            //
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(20, 80);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(55, 15);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prénom :";
            //
            // txtPrenom
            //
            this.txtPrenom.Location = new System.Drawing.Point(110, 77);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(190, 23);
            this.txtPrenom.TabIndex = 3;
            //
            // lblTel
            //
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(20, 120);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(72, 15);
            this.lblTel.TabIndex = 4;
            this.lblTel.Text = "Téléphone :";
            //
            // txtTel
            //
            this.txtTel.Location = new System.Drawing.Point(110, 117);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(190, 23);
            this.txtTel.TabIndex = 5;
            //
            // lblMail
            //
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(20, 160);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(38, 15);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "Mail :";
            //
            // txtMail
            //
            this.txtMail.Location = new System.Drawing.Point(110, 157);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(190, 23);
            this.txtMail.TabIndex = 7;
            //
            // lblService
            //
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(20, 200);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(51, 15);
            this.lblService.TabIndex = 8;
            this.lblService.Text = "Service :";
            //
            // cboService
            //
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(110, 197);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(190, 23);
            this.cboService.TabIndex = 9;
            //
            // btnEnregistrer
            //
            this.btnEnregistrer.Location = new System.Drawing.Point(110, 300);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(90, 32);
            this.btnEnregistrer.TabIndex = 10;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            //
            // btnAnnulerSaisie
            //
            this.btnAnnulerSaisie.Location = new System.Drawing.Point(210, 300);
            this.btnAnnulerSaisie.Name = "btnAnnulerSaisie";
            this.btnAnnulerSaisie.Size = new System.Drawing.Size(90, 32);
            this.btnAnnulerSaisie.TabIndex = 11;
            this.btnAnnulerSaisie.Text = "Annuler";
            this.btnAnnulerSaisie.UseVisualStyleBackColor = true;
            //
            // FrmGestionPersonnel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 480);
            this.Controls.Add(this.grpPersonnel);
            this.Controls.Add(this.btnGererAbsences);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.dgvPersonnel);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmGestionPersonnel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaTek86 - Gestion du personnel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.grpPersonnel.ResumeLayout(false);
            this.grpPersonnel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnGererAbsences;
        private System.Windows.Forms.GroupBox grpPersonnel;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnulerSaisie;
    }
}
