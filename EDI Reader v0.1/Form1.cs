using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EDI_Reader_v0._1
{
    public partial class Form1 : Form
    {
        Boolean FileText = false;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Kasun Perera\source\repos\EDI Reader v0.1\EDI Reader v0.1\EDI_Reader.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd, cmd2, cmd3 = new SqlCommand();
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            richTextBox1.Enabled = true;
            checkedListBox1.Enabled = false;
            checkedListBox2.Enabled = false;
            checkedListBox3.Enabled = false;
            checkedListBox4.Enabled = false;
            checkedListBox5.Enabled = false;
            checkedListBox6.Enabled = false;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FileText = true;
            richTextBox1.Enabled = false;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "AllFile| *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String fileText;

            if (radioButton2.Checked == true)
            {
                StreamReader streamReader = new StreamReader(textBox1.Text);
                fileText = streamReader.ReadToEnd();
            }
            else
            {
                fileText = richTextBox1.Text;
            }

            if (fileText == "")
            {
                MessageBox.Show("Please Select File or Insert Text");
            }
            else
            {

                // Specify the folder path where you want to create the Excel file
                string folderPath = textBox2.Text;

                conn.Open();

                cmd2 = new SqlCommand("DELETE FROM ISA_Table", conn);

                cmd2.ExecuteNonQuery();

                cmd3 = new SqlCommand("DELETE FROM STSE_Table", conn);

                cmd3.ExecuteNonQuery();

                conn.Close();

                progressBar1.Value = 10;

                new ISA_Loop(fileText, checkBox1, checkedListBox1, folderPath, label2, checkBox2, checkedListBox2);

                progressBar1.Value = 100;

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkedListBox5.Enabled = true;
            }
            else
            {
                checkedListBox5.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FileText = false;
            richTextBox1.Enabled = true;
            button1.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkedListBox1.Enabled = true;
            }
            else
            {
                checkedListBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkedListBox2.Enabled = true;
            }
            else
            {
                checkedListBox2.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkedListBox6.Enabled = true;
            }
            else
            {
                checkedListBox6.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkedListBox3.Enabled = true;
            }
            else
            {
                checkedListBox3.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkedListBox4.Enabled = true;
            }
            else
            {
                checkedListBox4.Enabled = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new instance of FolderBrowserDialog
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the initial selected folder (optional)
            folderBrowserDialog.SelectedPath = "C:\\";

            // Show the folder browser dialog and capture the result
            DialogResult result = folderBrowserDialog.ShowDialog();

            // Check if the user selected a folder and clicked OK
            if (result == DialogResult.OK)
            {
                // Retrieve the selected folder path
                string selectedFolderPath = folderBrowserDialog.SelectedPath;

                // Use the selected folder path as needed
                textBox2.Text = selectedFolderPath;
            }
        }
    }
}
