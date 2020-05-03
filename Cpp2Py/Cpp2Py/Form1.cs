using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.IO;

namespace Cpp2Py
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        PyConverter conv;
        public Form1()
        {
            InitializeComponent();
            conv = new PyConverter();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            conv = new PyConverter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Python files (*.py)|*.py|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String path = saveFileDialog1.FileName;
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                bw.Write(textBox2.Text);
                bw.Dispose();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conv.a = textBox1.Text;
            if (!conv.LexicalError() || !conv.SyntaxError())
            {
                MessageBox.Show(conv.errorrs,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else {
                textBox2.Text = conv.output;
            }
        }
    }
}
