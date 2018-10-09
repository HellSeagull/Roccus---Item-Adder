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
    public partial class frmProceduralSmith : Form
    {

        public string server { get; set; }
        public string database { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public frmProceduralSmith()
        {
            InitializeComponent();
        }

        private void frmProceduralSmith_Load(object sender, EventArgs e)
        {

        }

        private void DB2TextureBtn_Click(object sender, EventArgs e)
        {

        }

        private void DB2ItemBtn_Click(object sender, EventArgs e)
        {
            frmDB2Item frm = new frmDB2Item();
            frm.server = server;
            frm.database = database;
            frm.username = username;
            frm.password = password;
            frm.ShowDialog();
            frm.BringToFront();
        }
    }
}
