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

namespace WindowsFormsApplication1
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            textBox1.Text = dateTimePicker1.Value.ToString("MMMM dd");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string filepath = @"C:\Diary\Notes.txt";
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filepath).ToList();

                lines.Add(textBox1.Text + "      " + richTextBox1.Text);
                File.WriteAllLines(filepath, lines);
                MessageBox.Show("Note Added!","Success");

            }

            else
            {
                MessageBox.Show("Please select a valid Date!", "Invalid Date",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            View v = new View();
            v.Show();
        }
    }
}
