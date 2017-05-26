using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Generator.Parser;
using Generator.Entity;
using Generator.Api;
namespace TestWinForm
{
    public partial class DisplayForm : Form
    {
        private IEnumerable<DocTypeModel> _parsedCode;
        private string _connection;


        public DisplayForm(IEnumerable<DocTypeModel> parsedCode, string connection)
        {
            InitializeComponent();
            _parsedCode = parsedCode;
            _connection = connection;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = CodeApi.GetApiCode(_parsedCode, _connection);
        }
    }
}
