using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfdelingsBilleder
{
    public partial class Form1 : Form
    {
        private PrintModel PrintModel { get; set; } = new PrintModel();
        
        public Form1()
        {
            InitializeComponent();
            //  new List<Dto>(new[] { new Dto { Navn = "Test", Billede = new Bitmap(@"c:\Source\AfdelingsBilleder\img1.jpg") } });

            this.dataGridView1.DataSource = bindingSource1;
            //bindingSource1.DataSource = Data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  

            foreach (var file in files)
            {

                var attr = new FileInfo(file);
                PrintModel.Personer.Add(new PersonModel { Billede = new Bitmap(file), Navn = attr.Name.Replace(attr.Extension, ""), Filnavn = file });
            }
            SetData();

            //if (files != null && files.Any())
            //    textBox1.Text = files.First(); //select the first one  
        }

        private void SetData()
        {
            bindingSource1.DataSource = PrintModel.Personer;
            bindingSource1.ResetBindings(metadataChanged: false);
            dataGridView1.Refresh();
            bool enabled=(PrintModel.Personer.Any() && !string.IsNullOrWhiteSpace(PrintModel.Titel) && !string.IsNullOrWhiteSpace(PrintModel.Lokation));
            SaveButton.Enabled = enabled;
            PrintButton.Enabled = enabled;

        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {


            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
                foreach (var file in files)
                {
                    var attr = new FileInfo(file);
                    if (!(new string[] { ".jpg", ".png" }).Contains(attr.Extension))
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                }
                e.Effect = DragDropEffects.Link;
            }

            else
                e.Effect = DragDropEffects.None;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            GemDataDialog.FileName = PrintModel.Titel;
            var result = GemDataDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fi = new FileInfo(GemDataDialog.FileName);

                if (fi.Extension != ".json")
                {
                    MessageBox.Show("Forkert filtype - prøv igen");
                    return;
                }

                var content = JsonConvert.SerializeObject(PrintModel, Formatting.Indented);
                File.WriteAllText(GemDataDialog.FileName, content);
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            GemPrintDialog.FileName = PrintModel.Titel;
            var result = GemPrintDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fi = new FileInfo(GemPrintDialog.FileName);

                if (fi.Extension != ".html")
                {
                    MessageBox.Show("Forkert filtype - prøv igen");
                    return;
                }
                string template = Resource1.print;
                string content="const data= " + JsonConvert.SerializeObject(PrintModel, Formatting.None);
                var output= template.Replace("/*###DATA###*/", content);
                File.WriteAllText(GemPrintDialog.FileName,output);

            }

        }

        private void HentButton_Click(object sender, EventArgs e)
        {
            var result = HentDataDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fi = new FileInfo(HentDataDialog.FileName);
                if (fi.Exists && fi.Extension == ".json")
                {
                    var data = File.ReadAllText(HentDataDialog.FileName);
                    PrintModel = JsonConvert.DeserializeObject<PrintModel>(data);
                    PrintModel.Personer.ForEach(p => p.Billede = new Bitmap(p.Filnavn));
                    textBox1.Text = PrintModel.Titel;
                    comboBox1.Text = PrintModel.Lokation;
                    SetData();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PrintModel.Titel = textBox1.Text;
            SetData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintModel.Lokation = comboBox1.Text;
            SetData();
        }
    }

    public class PersonModel
    {
        public string Filnavn { get; set; }
        public string Navn { get; set; }
        public string Titel { get; set; }
        
        [JsonIgnore]
        public Image Billede { get; set; }
    }

    public class PrintModel {
        public string Titel { get; set; }
        public string Lokation { get; set; }

        public List<PersonModel> Personer { get; set; } = new List<PersonModel>();
    }
}