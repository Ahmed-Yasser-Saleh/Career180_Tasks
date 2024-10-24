using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task_10
{
    public partial class Notepad : Form
    {
        private string path { get; set; } = null;
        private string originalText { get; set; }
        public Notepad()
        {
            InitializeComponent();
            this.originalText = richTextBox1.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text != this.originalText)
            {
                var tempText = richTextBox1.Text;
                DialogResult result1 = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result1 == DialogResult.Yes)
                {
                    toolStripMenuItem6_Click(null, null); //Save As
                    richTextBox1.Clear();
                }
                else if (result1 == DialogResult.Cancel)
                {
                    richTextBox1.Text = tempText;
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    e.Cancel = true;
                }
            }
            else {
                DialogResult result = MessageBox.Show("Are you sure you want to close?", "Confirm Close", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
    
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                if (richTextBox1.Text != this.originalText)
                {
                    var tempText = richTextBox1.Text;
                    DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        toolStripMenuItem6_Click(null, null); //Save As
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            path = openFileDialog1.FileName;
                            richTextBox1.LoadFile(path);
                            // Move the cursor to the end of the loaded text
                            richTextBox1.SelectionStart = System.IO.File.ReadAllText(path).Length;
                        }
                        else { }
                        this.originalText = richTextBox1.Text;
                    }
                    else if (result == DialogResult.No)
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            path = openFileDialog1.FileName;
                            richTextBox1.LoadFile(path);
                            // Move the cursor to the end of the loaded text
                            richTextBox1.SelectionStart = System.IO.File.ReadAllText(path).Length;
                        }
                        else { }
                        this.originalText = richTextBox1.Text;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        richTextBox1.Text = tempText;
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    }
                }
                else
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = openFileDialog1.FileName;
                        richTextBox1.LoadFile(path);
                        // Move the cursor to the end of the loaded text
                        richTextBox1.SelectionStart = System.IO.File.ReadAllText(path).Length;
                    }
                    else { }
                    this.originalText = richTextBox1.Text;
                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                    richTextBox1.LoadFile(path);
                    // Move the cursor to the end of the loaded text
                    richTextBox1.SelectionStart = System.IO.File.ReadAllText(path).Length;
                }
                else { }
                this.originalText = richTextBox1.Text;
            }
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != this.originalText)
            {
                var tempText = richTextBox1.Text;
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    toolStripMenuItem6_Click(null, null); //Save As
                    richTextBox1.Clear();
                }
                else if (result == DialogResult.No)
                {
                    richTextBox1.Clear();
                }
                else if (result == DialogResult.Cancel)
                {
                    richTextBox1.Text = tempText;
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                }
            }
            else
            {
                richTextBox1.Clear();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
           var notepad1 = new Notepad();
           notepad1.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                richTextBox1.SaveFile(path);
            }
            else
            {
                saveFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                }
                path = saveFileDialog1.FileName;
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if(richTextBox1.SelectedText != "")
                    richTextBox1.SelectionFont = fontDialog1.Font;
                else
                    richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText != "")
                    richTextBox1.SelectionColor = colorDialog1.Color;
                else
                    richTextBox1.ForeColor = colorDialog1.Color;
            }
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            string helpUrl = "https://www.bing.com/search?q=get+help+with+notepad+in+windows&filters=guid:%224466414-en-dia%22%20lang:%22en%22&form=T00032&ocid=HelpPane-BingIA";
            System.Diagnostics.Process.Start(helpUrl);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
