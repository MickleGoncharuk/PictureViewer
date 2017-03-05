using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PictureViewer
{
    public partial class Form1 : Form
       
    {
        List<string> pathList;
        public Form1()
        {
            InitializeComponent();
            pathList = new List<string>();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);
                FileInfo []arr = di.GetFiles("*.jpg");
                foreach (FileInfo f in arr)
                {
                    listBox1.Items.Add(f.Name);
                    pathList.Add(f.FullName);
                }
                    
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы хотите открыть другую папку?", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);
                FileInfo[] arr = di.GetFiles("*.jpg");
                foreach (FileInfo f in arr)
                {
                    listBox1.Items.Add(f.Name);
                    pathList.Add(f.FullName);
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы хотите покинуть Picture Viewer?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            
            if(dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = listBox1.SelectedIndex;
            string path = pathList[k];
            pictureBox1.Image = new Bitmap(path);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int k = listBox1.SelectedIndex;
            if (k == -1)
            {
                MessageBox.Show("Вы не выбрали картинку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (k == listBox1.Items.Count - 1)
                {
                    k = 0;
                }
                else
                {
                    k++;
                }
               
                    
                    listBox1.SelectedIndex = k;
               
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = listBox1.SelectedIndex;
            if (k == -1)
            {
                MessageBox.Show("Вы не выбрали картинку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (k == 0 )
                {
                    k = listBox1.Items.Count-1;
                }
                else
                {
                    k--;
                }
                
                listBox1.SelectedIndex = k;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int k = listBox1.SelectedIndex;
            if (k == -1)
            {
                listBox1.SelectedIndex = 0;
            }
            else
            {
                if (k == listBox1.Items.Count - 1)
                {
                    k = 0;
                }
                else
                {
                    k++;
                }


                listBox1.SelectedIndex = k;


            }
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value*1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
