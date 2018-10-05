using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roccus___Item_Adder
{
    public partial class frmProceduralSmith : Form
    {

        public string SQLFilter { get; set; }
        private DB2 db2;
        DBInstance con;
        private StringBuilder sb;
        private Dictionary<string, int> caschostRetrieve;
        private Dictionary<string, int> itemMaterialresFilter;
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
            con = new DBInstance(server, database, username, password);
            caschostRetrieve = new Dictionary<string, int>();
            itemMaterialresFilter = new Dictionary<string, int>();
            sb = new StringBuilder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog(this);

            if (!con.Connected())
                con.Connection();

            if (con.Connected())
            {
                MySqlCommand query = new MySqlCommand(@"SELECT " + ConfigurationManager.AppSettings["columnPath"] + ", " + ConfigurationManager.AppSettings["columnFileDataId"] + " FROM " +
                                                        ConfigurationManager.AppSettings["caschostTable"] + " WHERE "+ ConfigurationManager.AppSettings["columnPath"] + 
                                                        " LIKE '%" + SQLFilter + "%'", con.TheConnection);
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    caschostRetrieve.Add(reader.GetString(0), reader.GetInt32(1));
                }
                reader.Close();
                con.Disconnect();
                int counter = 0;

                foreach (KeyValuePair<string, int> key in caschostRetrieve)
                {
                    if (key.Key.Contains("blp"))
                    {
                        string pathValue = key.Key.ToLower();
                        Match match = Regex.Match(pathValue, @"[0-9].*");
                        if (match.Success)
                        {
                            string filterStep1 = match.Groups[0].Value;
                            Match m = Regex.Match(filterStep1, @"_([a-z][a-z])_");
                            if (m.Success)
                            {
                                itemMaterialresFilter.Add(m.Groups[0].Value.Substring(1, m.Groups[0].Value.Length-2) + "_" + counter, key.Value);
                            }
                        }
                    }
                    counter++;
                }

                counter = 0;

                foreach(KeyValuePair<string, int> key in caschostRetrieve)
                {
                    sb.AppendLine(key.Key + ", " + key.Value);
                }

                sb.AppendLine();
                sb.AppendLine();

                foreach(KeyValuePair<string, int> key in itemMaterialresFilter)
                {
                    sb.AppendLine(key.Key + ", " + key.Value);
                }

                MessageBox.Show(sb.ToString());
                sb.Clear();

            }
        }
    }
}
