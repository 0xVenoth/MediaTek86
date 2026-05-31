namespace MediaTek86.vue
{
    partial class FrmGestionAbsence
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
            this.dgvAbsences = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            this.grpAbsence = new System.Windows.Forms.GroupBox();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblMotif = new System.Windows.Forms.Label();
            this.cboMotif = new System.Windows.Forms.ComboBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnulerSaisie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).BeginInit();
            this.grpAbsence.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitre
            //
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location = new System.Drawing.Point(12, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(330, 25);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion des absences de ...";
            //
            // dgvAbsences
            //
            this.dgvAbsences.AllowUserToAddRows = false;
            this.dgvAbsences.AllowUserToDeleteRows = false;
            this.dgvAbsences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsences.Location = new System.Drawing.Point(12, 55);
            this.dgvAbsences.MultiSelect = false;
            this.dgvAbsences.Name = "dgvAbsences";
            this.dgvAbsences.ReadOnly = true;
            this.dgvAbsences.RowHeadersVisible = false;
            this.dgvAbsences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsences.Size = new System.Drawing.Size(480, 360);
            this.dgvAbsences.TabIndex = 1;
            //
            // btnAjouter
            //
            this.btnAjouter.Location = new System.Drawing.Point(12, 430);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(110, 32);
            this.btnAjouter.TabIndex = 2;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            //
            // btnModifier
            //
            this.btnModifier.Location = new System.Drawing.Point(135, 430);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(110, 32);
            this.btnModifier.TabIndex = 3;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            //
            // btnSupprimer
            //
            this.btnSupprimer.Location = new System.Drawing.Point(258, 430);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(110, 32);
            this.btnSupprimer.TabIndex = 4;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            //
            // btnFermer
            //
            this.btnFermer.Location = new System.Drawing.Point(382, 430);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(110, 32);
            this.btnFermer.TabIndex = 5;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            //
            // grpAbsence
            //
            this.grpAbsence.Controls.Add(this.lblDateDebut);
            this.grpAbsence.Controls.Add(this.dtpDateDebut);
            this.grpAbsence.Controls.Add(this.lblDateFin);
            this.grpAbsence.Controls.Add(this.dtpDateFin);
            this.grpAbsence.Controls.Add(this.lblMotif);
            this.grpAbsence.Controls.Add(this.cboMotif);
            this.grpAbsence.Controls.Add(this.btnEnregistrer);
            this.grpAbsence.Controls.Add(this.btnAnnulerSaisie);
            this.grpAbsence.Location = new System.Drawing.Point(520, 55);
            this.grpAbsence.Name = "grpAbsence";
            this.grpAbsence.Size = new System.Drawing.Size(340, 300);
            this.grpAbsence.TabIndex = 6;
            this.grpAbsence.TabStop = false;
            this.grpAbsence.Text = "Détail de l'absence";
            //
            // lblDateDebut
            //
            this.lblDateDebut.AutoSize = true;
            this.lblDateDebut.Location = new System.Drawing.Point(20, 45);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(82, 15);
            this.lblDateDebut.TabIndex = 0;
            this.lblDateDebut.Text = "Date de début :";
            //
            // dtpDateDebut
            //
            this.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateDebut.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDateDebut.Location = new System.Drawing.Point(130, 42);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(190, 23);
            this.dtpDateDebut.TabIndex = 1;
            //
            // lblDateFin
            //
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Location = new System.Drawing.Point(20, 95);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(71, 15);
            this.lblDateFin.TabIndex = 2;
            this.lblDateFin.Text = "Date de fin :";
            //
            // dtpDateFin
            //
            this.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDateFin.Location = new System.Drawing.Point(130, 92);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(190, 23);
            this.dtpDateFin.TabIndex = 3;
            //
            // lblMotif
            //
            this.lblMotif.AutoSize = true;
            this.lblMotif.Location = new System.Drawing.Point(20, 145);
            this.lblMotif.Name = "lblMotif";
            this.lblMotif.Size = new System.Drawing.Size(45, 15);
            this.lblMotif.TabIndex = 4;
            this.lblMotif.Text = "Motif :";
            //
            // cboMotif
            //
            this.cboMotif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotif.FormattingEnabled = true;
            this.cboMotif.Location = new System.Drawing.Point(130, 142);
            this.cboMotif.Name = "cboMotif";
            this.cboMotif.Size = new System.Drawing.Size(190, 23);
            this.cboMotif.TabIndex = 5;
            //
            // btnEnregistrer
            //
            this.btnEnregistrer.Location = new System.Drawing.Point(130, 240);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(90, 32);
            this.btnEnregistrer.TabIndex = 6;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            //
            // btnAnnulerSaisie
            //
            this.btnAnnulerSaisie.Location = new System.Drawing.Point(230, 240);
            this.btnAnnulerSaisie.Name = "btnAnnulerSaisie";
            this.btnAnnulerSaisie.Size = new System.Drawing.Size(90, 32);
            this.btnAnnulerSaisie.TabIndex = 7;
            this.btnAnnulerSaisie.Text = "Annuler";
            this.btnAnnulerSaisie.UseVisualStyleBackColor = true;
            this.btnAnnulerSaisie.Click += new System.EventHandler(this.btnAnnulerSaisie_Click);
            //
            // FrmGestionAbsence
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 480);
            this.Controls.Add(this.grpAbsence);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.dgvAbsences);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmGestionAbsence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaTek86 - Gestion des absences";
            this.Load += new System.EventHandler(this.FrmGestionAbsence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).EndInit();
            this.grpAbsence.ResumeLayout(false);
            this.grpAbsence.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.DataGridView dgvAbsences;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.GroupBox grpAbsence;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.Label lblMotif;
        private System.Windows.Forms.ComboBox cboMotif;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnulerSaisie;
    }
}
