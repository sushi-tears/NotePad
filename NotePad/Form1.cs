using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotePad {
    public partial class NotePad : Form {
        public NotePad() {
            InitializeComponent();

        }

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;


        private void NotePad_Load(object sender, EventArgs e) {

            fontDialog = new FontDialog();

        }

        // Create a new file 
        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileAs();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {

        }

        // Method to Create a new file 
        private void NewFile() {
            if (!string.IsNullOrEmpty(this.richTextBox1.Text)) {
                MessageBox.Show("Do you want to save?");
            }

            else {
                this.richTextBox1.Text = string.Empty;
                this.Text = "Untitled";
            }
        }

        //Method to Save file 
        private void SaveFile() {
            if (!string.IsNullOrEmpty(this.richTextBox1.Text)) {

                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File (*.txt) | *.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                }
            }

            else {
                MessageBox.Show("The file is empty!");
            }
        }

        //Method to Save File As
        private void SaveFileAs() {
            if (!string.IsNullOrEmpty(this.richTextBox1.Text)) {

                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File (*.txt) | *.txt ! All Files (*.*) | *.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                }
            }

            else {
                MessageBox.Show("The file is empty!");
            }
        }
         
        //Method to Open File 
        public void OpenFile() {
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                this.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                this.Text = openFileDialog.FileName;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e) {
            

            if (fontDialog.ShowDialog() == DialogResult.OK) {
                this.richTextBox1.Font = fontDialog.Font;
            }


        }
    }
}