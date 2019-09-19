namespace CalendarTest
{
    partial class Form1
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
            this.calendrier = new System.Windows.Forms.MonthCalendar();
            this.buttonEditer = new System.Windows.Forms.Button();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.buttonNouveau = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calendrier
            // 
            this.calendrier.Location = new System.Drawing.Point(13, 57);
            this.calendrier.MaxSelectionCount = 1;
            this.calendrier.Name = "calendrier";
            this.calendrier.TabIndex = 0;
            this.calendrier.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendrier_DateChanged);
            // 
            // buttonEditer
            // 
            this.buttonEditer.Location = new System.Drawing.Point(94, 280);
            this.buttonEditer.Name = "buttonEditer";
            this.buttonEditer.Size = new System.Drawing.Size(75, 23);
            this.buttonEditer.TabIndex = 1;
            this.buttonEditer.Text = "Lire/Editer";
            this.buttonEditer.UseVisualStyleBackColor = true;
            this.buttonEditer.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Location = new System.Drawing.Point(175, 280);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(75, 23);
            this.buttonSupprimer.TabIndex = 2;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = true;
            this.buttonSupprimer.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonNouveau
            // 
            this.buttonNouveau.Location = new System.Drawing.Point(13, 280);
            this.buttonNouveau.Name = "buttonNouveau";
            this.buttonNouveau.Size = new System.Drawing.Size(75, 23);
            this.buttonNouveau.TabIndex = 3;
            this.buttonNouveau.Text = "Nouveau";
            this.buttonNouveau.UseVisualStyleBackColor = true;
            this.buttonNouveau.Click += new System.EventHandler(this.buttonNouveau_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(330, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(472, 246);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(727, 309);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Enregistrer";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(330, 12);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '€';
            this.textPassword.Size = new System.Drawing.Size(224, 20);
            this.textPassword.TabIndex = 6;
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Location = new System.Drawing.Point(560, 12);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlock.TabIndex = 7;
            this.buttonUnlock.Text = "Déverrouiller";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 388);
            this.Controls.Add(this.buttonUnlock);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonNouveau);
            this.Controls.Add(this.buttonSupprimer);
            this.Controls.Add(this.buttonEditer);
            this.Controls.Add(this.calendrier);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendrier;
        private System.Windows.Forms.Button buttonEditer;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.Button buttonNouveau;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Button buttonUnlock;
    }
}

