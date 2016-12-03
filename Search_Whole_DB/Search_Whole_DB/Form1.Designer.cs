namespace Search_Whole_DB
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_Suchfeld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DropDown_TypAuswahl = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Button_TypenErfassen = new System.Windows.Forms.Button();
            this.ListBox_Ausgabe = new System.Windows.Forms.ListBox();
            this.Button_SucheStarten = new System.Windows.Forms.Button();
            this.StatusBalken = new System.Windows.Forms.ProgressBar();
            this.Button_Verbinden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suche nach:";
            // 
            // TextBox_Suchfeld
            // 
            this.TextBox_Suchfeld.Location = new System.Drawing.Point(87, 33);
            this.TextBox_Suchfeld.Name = "TextBox_Suchfeld";
            this.TextBox_Suchfeld.Size = new System.Drawing.Size(561, 20);
            this.TextBox_Suchfeld.TabIndex = 1;
            this.TextBox_Suchfeld.TextChanged += new System.EventHandler(this.TextBox_Suchfeld_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Typ:";
            // 
            // DropDown_TypAuswahl
            // 
            this.DropDown_TypAuswahl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDown_TypAuswahl.Enabled = false;
            this.DropDown_TypAuswahl.FormattingEnabled = true;
            this.DropDown_TypAuswahl.Location = new System.Drawing.Point(87, 6);
            this.DropDown_TypAuswahl.Name = "DropDown_TypAuswahl";
            this.DropDown_TypAuswahl.Size = new System.Drawing.Size(169, 21);
            this.DropDown_TypAuswahl.Sorted = true;
            this.DropDown_TypAuswahl.TabIndex = 3;
            this.DropDown_TypAuswahl.SelectionChangeCommitted += new System.EventHandler(this.DropDown_TypAuswahl_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ausgabe:";
            // 
            // Button_TypenErfassen
            // 
            this.Button_TypenErfassen.Enabled = false;
            this.Button_TypenErfassen.Location = new System.Drawing.Point(262, 4);
            this.Button_TypenErfassen.Name = "Button_TypenErfassen";
            this.Button_TypenErfassen.Size = new System.Drawing.Size(133, 23);
            this.Button_TypenErfassen.TabIndex = 5;
            this.Button_TypenErfassen.Text = "2. Daten initialisieren";
            this.Button_TypenErfassen.UseVisualStyleBackColor = true;
            this.Button_TypenErfassen.Click += new System.EventHandler(this.Button_TypenErfassen_Click);
            // 
            // ListBox_Ausgabe
            // 
            this.ListBox_Ausgabe.FormattingEnabled = true;
            this.ListBox_Ausgabe.Location = new System.Drawing.Point(16, 80);
            this.ListBox_Ausgabe.Name = "ListBox_Ausgabe";
            this.ListBox_Ausgabe.Size = new System.Drawing.Size(771, 290);
            this.ListBox_Ausgabe.TabIndex = 6;
            // 
            // Button_SucheStarten
            // 
            this.Button_SucheStarten.Enabled = false;
            this.Button_SucheStarten.Location = new System.Drawing.Point(654, 31);
            this.Button_SucheStarten.Name = "Button_SucheStarten";
            this.Button_SucheStarten.Size = new System.Drawing.Size(133, 23);
            this.Button_SucheStarten.TabIndex = 7;
            this.Button_SucheStarten.Text = "3. Suche Starten";
            this.Button_SucheStarten.UseVisualStyleBackColor = true;
            this.Button_SucheStarten.Click += new System.EventHandler(this.Button_SucheStarten_Click);
            // 
            // StatusBalken
            // 
            this.StatusBalken.Location = new System.Drawing.Point(16, 376);
            this.StatusBalken.Name = "StatusBalken";
            this.StatusBalken.Size = new System.Drawing.Size(771, 15);
            this.StatusBalken.TabIndex = 8;
            // 
            // Button_Verbinden
            // 
            this.Button_Verbinden.Location = new System.Drawing.Point(401, 4);
            this.Button_Verbinden.Name = "Button_Verbinden";
            this.Button_Verbinden.Size = new System.Drawing.Size(133, 23);
            this.Button_Verbinden.TabIndex = 9;
            this.Button_Verbinden.Text = "1. Verbindung aufbauen";
            this.Button_Verbinden.UseVisualStyleBackColor = true;
            this.Button_Verbinden.Click += new System.EventHandler(this.Button_Verbinden_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 425);
            this.Controls.Add(this.Button_Verbinden);
            this.Controls.Add(this.StatusBalken);
            this.Controls.Add(this.Button_SucheStarten);
            this.Controls.Add(this.ListBox_Ausgabe);
            this.Controls.Add(this.Button_TypenErfassen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DropDown_TypAuswahl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox_Suchfeld);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_Suchfeld;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DropDown_TypAuswahl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Button_TypenErfassen;
        private System.Windows.Forms.ListBox ListBox_Ausgabe;
        private System.Windows.Forms.Button Button_SucheStarten;
        private System.Windows.Forms.ProgressBar StatusBalken;
        private System.Windows.Forms.Button Button_Verbinden;
    }
}

