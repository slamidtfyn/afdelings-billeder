namespace AfdelingsBilleder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.PrintButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GemDataDialog = new System.Windows.Forms.SaveFileDialog();
            this.GemPrintDialog = new System.Windows.Forms.SaveFileDialog();
            this.HentButton = new System.Windows.Forms.Button();
            this.HentDataDialog = new System.Windows.Forms.OpenFileDialog();
            this.Billede = new System.Windows.Forms.DataGridViewImageColumn();
            this.Navn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filnavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Billede,
            this.Navn,
            this.Titel,
            this.Filnavn});
            this.dataGridView1.Location = new System.Drawing.Point(24, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 300;
            this.dataGridView1.Size = new System.Drawing.Size(760, 370);
            this.dataGridView1.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.Location = new System.Drawing.Point(672, 404);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(112, 34);
            this.PrintButton.TabIndex = 1;
            this.PrintButton.Text = "Gem &print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(554, 404);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 34);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "&Gem data";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GemDataDialog
            // 
            this.GemDataDialog.DefaultExt = "json";
            this.GemDataDialog.Filter = "Data|*.json";
            // 
            // GemPrintDialog
            // 
            this.GemPrintDialog.DefaultExt = "html";
            // 
            // HentButton
            // 
            this.HentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HentButton.Location = new System.Drawing.Point(436, 404);
            this.HentButton.Name = "HentButton";
            this.HentButton.Size = new System.Drawing.Size(112, 34);
            this.HentButton.TabIndex = 3;
            this.HentButton.Text = "&Hent data";
            this.HentButton.UseVisualStyleBackColor = true;
            this.HentButton.Click += new System.EventHandler(this.HentButton_Click);
            // 
            // HentDataDialog
            // 
            this.HentDataDialog.DefaultExt = "json";
            // 
            // Billede
            // 
            this.Billede.DataPropertyName = "Billede";
            this.Billede.HeaderText = "Billede";
            this.Billede.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Billede.MinimumWidth = 8;
            this.Billede.Name = "Billede";
            this.Billede.ReadOnly = true;
            this.Billede.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Billede.Width = 200;
            // 
            // Navn
            // 
            this.Navn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Navn.DataPropertyName = "Navn";
            this.Navn.HeaderText = "Navn";
            this.Navn.MinimumWidth = 8;
            this.Navn.Name = "Navn";
            this.Navn.Width = 400;
            // 
            // Titel
            // 
            this.Titel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Titel.DataPropertyName = "Titel";
            this.Titel.HeaderText = "Titel";
            this.Titel.MinimumWidth = 8;
            this.Titel.Name = "Titel";
            // 
            // Filnavn
            // 
            this.Filnavn.DataPropertyName = "Filnavn";
            this.Filnavn.HeaderText = "FilNavn";
            this.Filnavn.MinimumWidth = 8;
            this.Filnavn.Name = "Filnavn";
            this.Filnavn.ReadOnly = true;
            this.Filnavn.Visible = false;
            this.Filnavn.Width = 150;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HentButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Afdelingsbilleder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titel;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog GemDataDialog;
        private System.Windows.Forms.SaveFileDialog GemPrintDialog;
        private System.Windows.Forms.Button HentButton;
        private System.Windows.Forms.OpenFileDialog HentDataDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filnavn;
        private System.Windows.Forms.DataGridViewImageColumn Billede;
        private System.Windows.Forms.DataGridViewTextBoxColumn Navn;
    }
}