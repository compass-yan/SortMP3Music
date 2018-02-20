using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Main
{
    public partial class Form1 : Form
    {
        string  path = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(path, "*.mp3");
            Array.Sort(files);
            var errorCount = 0;
            var sucCount = 0;
            var index = 0;
            foreach (var item in files)
            {
                ++index;
                var ctDate = DateTime.Now.AddSeconds(index);
                var file = new FileInfo(item);
                if (file!=null)
                {
                    file.CreationTime = ctDate;
                    sucCount++;
                    lblSuc.Text = sucCount.ToString();
                }
                else
                {
                    errorCount++;
                    lblfail.Text = errorCount.ToString();

                }
            }
            MessageBox.Show("已完成！");

        }

        private void cmbDisks_SelectedIndexChanged(object sender, EventArgs e)
        {
            path = cmbDisks.SelectedItem.ToString() ;
            var files = Directory.GetFiles(path, "*.mp3");

            lblTotal.Text = files.Length.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var divices=DriveInfo.GetDrives();
            List<string> divicesRemovalbe= new List<string> { };
            foreach (var item in divices)
            {
                if (item.DriveType == DriveType.Removable)
                {
                    divicesRemovalbe.Add(item.Name);
                }
            }
            cmbDisks.DataSource = divicesRemovalbe;
        }
    }
}
