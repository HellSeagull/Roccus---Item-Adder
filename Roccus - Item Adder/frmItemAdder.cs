using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roccus___Item_Adder
{
    public partial class frmItemAdder : Form
    {

        private DBInstance con;
        private DB2 db2;
        public string server { get; set; }
        public string database { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        private string db2CustomPath = System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\'));

        public frmItemAdder()
        {
            InitializeComponent();

            foreach (var item in Enum.GetNames(typeof(EnumDefinition.EnumType.Tables)))
            {
                tableList.Items.Add(item);
            }

            foreach(var item in Enum.GetNames(typeof(EnumDefinition.EnumType.DB2Tables)))
            {
                db2Box.Items.Add(item);
            }
        }

        private void frmItemAdder_Load(object sender, EventArgs e)
        {
            con = new DBInstance(server, database, username, password);
            db2 = new DB2();
            this.Activate();
            this.Select();
        }

        private void DBTableBtn_Click(object sender, EventArgs e)
        {
            frmBackupSQL form = new frmBackupSQL();
            if (tableList.Text == "" || tableList.Text == string.Empty)
            {
                MessageBox.Show("Choose a table to use the backup function", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                form.TableName = tableList.Text;
                form.server = server;
                form.database = database;
                form.username = username;
                form.password = password;
                form.BringToFront();
                form.Show();
            }

        }

        private string getCBoxDB2Text()
        {
            if (db2Box.InvokeRequired)
                return (string)db2Box.Invoke(new Func<string>(getCBoxDB2Text));
            else
                return db2Box.Text;
        }

        private async void delayFunc()
        {
            await Task.Delay(1000);
            switch (getCBoxDB2Text())
            {
                case "itemdisplayinfo":
                    db2.ListeItemDisplayInfo(db2CustomPath, getCBoxDB2Text() + "_custom.csv");
                    break;
                case "itemdisplayinfomaterialres":
                    db2.ListItemDisplayInfoMaterialRes(db2CustomPath, getCBoxDB2Text() + "_custom.csv");
                    break;
                case "modelfiledata":
                    db2.ListeModelFileData(db2CustomPath, getCBoxDB2Text() + "_custom.csv");
                    break;
                case "texturefiledata":
                    db2.ListeTextureFileData(db2CustomPath, getCBoxDB2Text() + "_custom.csv");
                    break;
                default:
                    break;
            }
        }

        private void DB2toCSVBtn_Click(object sender, EventArgs e)
        {
            if (db2Box.Text != "")
            {
                backgroundWorker2.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("You need to choose the custom DB2 to process in the list", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            delayFunc();
        }

        private void armorHotfixBtn_Click(object sender, EventArgs e)
        {
            frmArmorSmith frm = new frmArmorSmith();
            frm.server = server;
            frm.database = database;
            frm.username = username;
            frm.password = password;
            frm.BringToFront();
            frm.ShowDialog();
        }

        private void weaponHotfixBtn_Click(object sender, EventArgs e)
        {
            frmWeaponSmith frm = new frmWeaponSmith();
            frm.server = server;
            frm.database = database;
            frm.username = username;
            frm.password = password;
            frm.BringToFront();
            frm.ShowDialog();
        }

        private void proceduralHotfixBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
