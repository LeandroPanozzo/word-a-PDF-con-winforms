using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;
using PdfSharp.Pdf.IO;

namespace Word_a_Pdf
{
    public partial class Pasar_Word_a_PDF : Form
    {
        public bool Abierto { get; set; } = false;
        public Pasar_Word_a_PDF()
        {
            InitializeComponent();
        }

        private void AbrirArchivoBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Word Documents (*.docx)|*.docx|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                foreach (string archivoSeleccionado in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(archivoSeleccionado);
                }

                Abierto = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void PasarPdfBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No hay archivos seleccionados para convertir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (string archivoWord in listBox1.Items)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Guardar archivo PDF";
                    saveFileDialog.FileName = Path.GetFileNameWithoutExtension(archivoWord) + ".pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string ruta = saveFileDialog.FileName;
                        ExportarAPDF(ruta, archivoWord);
                    }
                }
            }
        }

        public void ExportarAPDF(string ruta, string archivoWord)
        {
            Microsoft.Office.Interop.Word.Application word = null;
            Microsoft.Office.Interop.Word.Document doc = null;


            // Inicializar Word
            word = new Microsoft.Office.Interop.Word.Application();
            word.Visible = false;

            // Abrir el documento Word
            doc = word.Documents.Open(archivoWord);

            // Crear un nuevo documento PDF
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                for (int i = 1; i <= doc.ComputeStatistics(WdStatistic.wdStatisticPages); i++)
                {
                    // Exportar cada página como imagen
                    string imagePath = Path.GetTempFileName();
                    doc.ExportAsFixedFormat(ruta, WdExportFormat.wdExportFormatPDF);

                    // Convertir XPS a imagen
                    using (var xpsDocument = new System.Windows.Xps.Packaging.XpsDocument(imagePath, FileAccess.Read))
                    {
                        var xpsPage = xpsDocument.GetFixedDocumentSequence().DocumentPaginator.GetPage(0);
                        var bitmap = new System.Windows.Media.Imaging.RenderTargetBitmap((int)xpsPage.Size.Width, (int)xpsPage.Size.Height, 96, 96, System.Windows.Media.PixelFormats.Default);
                        bitmap.Render(xpsPage.Visual);

                        // Guardar la imagen como PNG
                        string pngPath = Path.ChangeExtension(imagePath, ".png");
                        using (FileStream stream = new FileStream(pngPath, FileMode.Create))
                        {
                            var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
                            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bitmap));
                            encoder.Save(stream);
                        }

                        // Agregar la imagen al PDF
                        PdfPage pdfPage = pdfDocument.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(pdfPage);
                        XImage image = XImage.FromFile(pngPath);
                        gfx.DrawImage(image, 0, 0, pdfPage.Width, pdfPage.Height);

                        // Limpiar archivos temporales
                        File.Delete(imagePath);
                        File.Delete(pngPath);
                    }
                }

                // Guardar el documento PDF
                pdfDocument.Save(ruta);
            }

            MessageBox.Show("Exportación a PDF realizada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UnirPdfsBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No hay archivos seleccionados para unir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar archivo PDF combinado";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ruta = saveFileDialog.FileName;
                    UnirArchivosWordAPDF(ruta);
                }
            }
        }

        public void UnirArchivosWordAPDF(string ruta)
        {
            Microsoft.Office.Interop.Word.Application word = null;
            Microsoft.Office.Interop.Word.Document doc = null;

            // Crear un nuevo documento PDF
            using (PdfDocument outputPdfDocument = new PdfDocument())
            {
                foreach (string archivoWord in listBox1.Items)
                {
                    // Inicializar Word
                    word = new Microsoft.Office.Interop.Word.Application();
                    word.Visible = false;

                    // Abrir el documento Word
                    doc = word.Documents.Open(archivoWord);

                    // Exportar el documento Word como PDF temporal
                    string tempPdfPath = Path.GetTempFileName();
                    doc.ExportAsFixedFormat(tempPdfPath, WdExportFormat.wdExportFormatPDF);

                    // Cargar el PDF temporal
                    using (PdfDocument tempPdfDocument = PdfReader.Open(tempPdfPath, PdfDocumentOpenMode.Import))
                    {
                        // Copiar páginas del PDF temporal al PDF de salida
                        foreach (PdfPage page in tempPdfDocument.Pages)
                        {
                            outputPdfDocument.AddPage(page);
                        }
                    }

                    // Cerrar y liberar recursos de Word
                    doc.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                    word.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(word);
                    File.Delete(tempPdfPath);
                }

                // Guardar el documento PDF combinado
                outputPdfDocument.Save(ruta);
            }

            MessageBox.Show("Exportación a PDF combinada realizada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void EliminarBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
