using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _313_in_220
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XDocument text1;
        XDocument text2;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XML-файл |*.xml|All files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lable1.Text = openFileDialog1.FileName;
                text1 = XDocument.Load(lable1.Text);
            }
        }

        private void but2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            //saveFileDialog1.Filter = "XML-файл |*.xml|All files|*.*";
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                int l1 = 1;
             
                foreach (var o1 in text1.Descendants()?.Elements("sscc"))
                {
                    text2 = new XDocument();
                    XElement doc = new XElement("documents");
                    doc.Add(new XAttribute("session_ui", "4cbec96e-67f2-2465-e055-025056ad03aa"));
                    doc.Add(new XAttribute("version", "1.35"));
                    doc.Add(new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"));
                    XElement quer = new XElement("query_hierarchy_info");
                    quer.Add(new XAttribute("action_id", "220"));
                    quer.Add(new XElement("subject_id", "00000000191233"));
                    quer.Add(new XElement("sscc", o1.Value));
                    doc.Add(quer);
                    text2.Add(doc);
                    text2.Save(folderDlg.SelectedPath + "/220_" + l1 + ".xml");
                    l1++;
                }
            }
        }

    }
}
