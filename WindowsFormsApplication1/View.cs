using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class View : Form
    {
        public View()
        {
            Thread t = new Thread(new ThreadStart(formRun));
            t.Start();
            Thread.Sleep(2000);
            InitializeComponent();
            t.Abort();

            string filepath = @"C:\Diary\Notes.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();

            foreach (String line in lines)
            {
                listView1.Items.Add(line);
               
            }
        }

        private void formRun()
        {
            Application.Run(new splash());

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
  

        private void Delete_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Diary\Notes.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();

            int index = lines.FindIndex(a => a.Contains(listView1.SelectedItems[0].Text));
            lines.RemoveAt(index);
            File.WriteAllLines(filepath, lines);

            if (MessageBox.Show("Are you sure you want to delete this note?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                textBox1.Text = "";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void edit_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Diary\Notes.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();

            int index = lines.FindIndex(a => a.Contains(listView1.SelectedItems[0].Text));
            lines[index] = textBox1.Text;
            File.WriteAllLines(filepath, lines);

            listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
            textBox1.Text = "";
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text= listView1.SelectedItems[0].SubItems[0].Text ;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add a = new Add();
            a.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker1.Value.ToString("MMMM dd");
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string filepath = @"C:\Diary\Notes.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();
            foreach (String line in lines)
            {
                if (line.ToLower().Contains(textBox2.Text.ToLower()))
                {
                    listView1.Items.Add(new ListViewItem(new[] { line}));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox2.Text = "All Notes"; 
            string filepath = @"C:\Diary\Notes.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();

            foreach (String line in lines)
            {
                listView1.Items.Add(line);


            }
        }
    }
}


