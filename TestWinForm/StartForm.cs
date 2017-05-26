using Generator.Parser;
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
using Generator.Namespace;
using Generator.Model;

namespace TestWinForm
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Xsd file";
            openFileDialog1.DefaultExt = "xsd";
            openFileDialog1.Filter = "xsd files (*.xsd)|*.xsd|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
                var parsedCode = XsdParser.GetDocTypes(openFileDialog1.FileName);
                DisplayForm df = new DisplayForm(parsedCode, connection);
                df.ShowDialog();
            }
        }

        private void btnProject_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                System.Windows.Forms.MessageBox.Show("Project nema is empty!!!");
            }
            else
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        NamespaceSwitcher.SwitchNamespace(fbd.SelectedPath, txtProjectName.Text);
                        System.Windows.Forms.MessageBox.Show("Namespcaes are changed!");
                    }
                }
            }
     
        }
    }
}
