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

        private List<Dto> Data = new List<Dto>();
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
                Data.Add(new Dto { Billede = new Bitmap(file), Navn = attr.Name.Replace(attr.Extension, ""), Filnavn = file });
            }
            SetData();

            //if (files != null && files.Any())
            //    textBox1.Text = files.First(); //select the first one  
        }

        private void SetData()
        {
            bindingSource1.DataSource = Data;
            bindingSource1.ResetBindings(metadataChanged: false);
            dataGridView1.Refresh();
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
            var result = GemDataDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fi = new FileInfo(GemDataDialog.FileName);

                if (fi.Extension != ".json")
                {
                    MessageBox.Show("Forkert filtype - prøv igen");
                    return;
                }

                if (fi.Exists)
                {
                    var overWrite = MessageBox.Show("Vil du overskrive " + fi.Name + "?", "Overskriv", MessageBoxButtons.YesNo);
                    if (overWrite == DialogResult.No) return;
                }

                var content = JsonConvert.SerializeObject(Data.AsEnumerable<Model>(), Formatting.Indented);
                File.WriteAllText(GemDataDialog.FileName, content);
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {

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
                    var model = JsonConvert.DeserializeObject<List<Model>>(data);
                    Data = new List<Dto>(model.Select(p => new Dto { Filnavn = p.Filnavn, Navn = p.Navn, Titel = p.Titel, Billede = new Bitmap(p.Filnavn) }));
                    SetData();
                }
            }
        }
    }

    public class Dto : Model
    {
        public Image Billede { get; set; }

    }

    public class Model
    {
        public string Filnavn { get; set; }
        public string Navn { get; set; }
        public string Titel { get; set; }
    }
}