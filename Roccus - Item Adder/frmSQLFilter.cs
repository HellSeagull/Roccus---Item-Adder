using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roccus___Item_Adder
{
    public partial class frmSQLFilter : Form
    {
        public frmSQLFilter()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ((frmDB2Item)this.Owner).SQLFilter = textBox1.Text;
                this.Close();
            }
        }

        private void frmSQLFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
