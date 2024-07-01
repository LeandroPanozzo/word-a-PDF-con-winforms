namespace Word_a_Pdf
{
    partial class Pasar_Word_a_PDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pasar_Word_a_PDF));
            AbrirArchivoBtn = new Button();
            PasarPdfBtn = new Button();
            UnirPdfsBtn = new Button();
            listBox1 = new ListBox();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            EliminarBtn = new Button();
            SuspendLayout();
            // 
            // AbrirArchivoBtn
            // 
            AbrirArchivoBtn.Anchor = AnchorStyles.Bottom;
            AbrirArchivoBtn.Location = new Point(12, 112);
            AbrirArchivoBtn.Name = "AbrirArchivoBtn";
            AbrirArchivoBtn.Size = new Size(120, 21);
            AbrirArchivoBtn.TabIndex = 1;
            AbrirArchivoBtn.Text = "Abrir archivo";
            AbrirArchivoBtn.UseVisualStyleBackColor = true;
            AbrirArchivoBtn.Click += AbrirArchivoBtn_Click;
            // 
            // PasarPdfBtn
            // 
            PasarPdfBtn.Anchor = AnchorStyles.Bottom;
            PasarPdfBtn.Location = new Point(277, 112);
            PasarPdfBtn.Name = "PasarPdfBtn";
            PasarPdfBtn.Size = new Size(120, 23);
            PasarPdfBtn.TabIndex = 2;
            PasarPdfBtn.Text = "Pasarlo a Pdf";
            PasarPdfBtn.UseVisualStyleBackColor = true;
            PasarPdfBtn.Click += PasarPdfBtn_Click;
            // 
            // UnirPdfsBtn
            // 
            UnirPdfsBtn.Anchor = AnchorStyles.Bottom;
            UnirPdfsBtn.Location = new Point(12, 157);
            UnirPdfsBtn.Name = "UnirPdfsBtn";
            UnirPdfsBtn.Size = new Size(120, 56);
            UnirPdfsBtn.TabIndex = 3;
            UnirPdfsBtn.Text = "Combinar los words en un solo pdf";
            UnirPdfsBtn.UseVisualStyleBackColor = true;
            UnirPdfsBtn.Click += UnirPdfsBtn_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(386, 94);
            listBox1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // EliminarBtn
            // 
            EliminarBtn.Anchor = AnchorStyles.Bottom;
            EliminarBtn.Location = new Point(277, 174);
            EliminarBtn.Name = "EliminarBtn";
            EliminarBtn.Size = new Size(120, 23);
            EliminarBtn.TabIndex = 5;
            EliminarBtn.Text = "Eliminar de la Lista";
            EliminarBtn.UseVisualStyleBackColor = true;
            EliminarBtn.Click += EliminarBtn_Click;
            // 
            // Pasar_Word_a_PDF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 276);
            Controls.Add(EliminarBtn);
            Controls.Add(listBox1);
            Controls.Add(UnirPdfsBtn);
            Controls.Add(PasarPdfBtn);
            Controls.Add(AbrirArchivoBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(425, 315);
            Name = "Pasar_Word_a_PDF";
            Text = "Word a PDF";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button AbrirArchivoBtn;
        private Button PasarPdfBtn;
        private Button UnirPdfsBtn;
        private ListBox listBox1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private Button EliminarBtn;
    }
}
