using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roccus___Item_Adder
{
    public partial class frmDB2Item : Form
    {

        public string SQLFilter { get; set; }
        private DBInstance con;
        private DB2 db2;
        public string server { get; set; }
        public string database { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        private DataTable dt;
        private StringBuilder sb;
        private string tableColumn;

        public frmDB2Item()
        {
            InitializeComponent();
        }

        private void frmDB2Item_Load(object sender, EventArgs e)
        {
            con = new DBInstance(server, database, username, password);
            db2 = new DB2();
            sb = new StringBuilder();
        }

        private void CascReadBtn_Click(object sender, EventArgs e)
        {
            frmSQLFilter frm = new frmSQLFilter();
            frm.ShowDialog(this);

            if (!con.Connected())
                con.Connection();

            if (con.Connected())
            {
                tableColumn = getTableColumns(ConfigurationManager.AppSettings["Table"]);
                MySqlCommand query = new MySqlCommand(@"SELECT " + ConfigurationManager.AppSettings["Path"] + "," + ConfigurationManager.AppSettings["FileDataID"] + " FROM " +
                                      ConfigurationManager.AppSettings["Table"] + " WHERE " + ConfigurationManager.AppSettings["Path"] + " LIKE '%" + SQLFilter + "%'", con.TheConnection);
                MySqlDataReader reader = query.ExecuteReader();
                dt = new DataTable();
                dt.Columns.Add(ConfigurationManager.AppSettings["Path"]);
                dt.Columns.Add(ConfigurationManager.AppSettings["FileDataID"]);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       dt.Rows.Add(new Object[] { reader.GetString(0), reader.GetString(1)});
                    }
                }
                reader.Close();
                dataGridView1.DataSource = dt;

            }
        }

        private void textureFiledata()
        {

            sb.Clear();
            sb.AppendLine("\"FileDataID\",\"MaterialResourcesID\",\"UsageType\",\"RelationshipData\"");

            string header = sb.ToString();
            sb.Clear();

            string pathCSVGen = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledata.csv");

            if (File.Exists(pathCSVGen))
            {
                File.Delete(pathCSVGen);
            }
            File.AppendAllText(pathCSVGen, header);

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataGen.csv")))
            {
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataGen.csv"));
            }

            db2.ListeTextureFileData(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataGen.csv");

            int maxMaterialID = 0;

            string pathDB2Read = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataGen.csv");

            if (File.Exists(pathDB2Read))
            {
                string[] temp = File.ReadAllLines(pathDB2Read);
                sb.Clear();
                for (int i = 0; i < temp.Length; i++)
                {
                    sb.AppendLine(temp[i].Split(',')[1]);
                }
                File.WriteAllText(pathDB2Read, sb.ToString());
                sb.Clear();
                maxMaterialID = File.ReadAllLines(pathDB2Read).Select(int.Parse).Max() + 1;
                string file1 = File.ReadAllText(pathDB2Read);
                if (dataGridView1.DataSource != null)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (!file1.Contains(dataGridView1.Rows[i].Cells[1].Value.ToString()) && dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(".blp"))
                        {
                            sb.AppendLine("\"" + dataGridView1.Rows[i].Cells[1].Value + "\",\"" + maxMaterialID + "\",\"" + 0 + "\",\"" + maxMaterialID + "\"");
                            maxMaterialID++;
                        }
                    }
                }
                File.AppendAllText(pathCSVGen, sb.ToString());
                sb.Clear();
            }
            else
            {
                db2.ListeTextureFileDataLastOffi(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataLastOffi.csv");
                string PathCSV = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataLastOffi.csv");
                string temp = File.ReadAllText(PathCSV);
                maxMaterialID = int.Parse(temp.Split(',')[1]) + 1;
                if (dataGridView1.DataSource != null)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(".blp"))
                        {
                            sb.AppendLine("\"" + dataGridView1.Rows[i].Cells[1].Value + "\",\"" + maxMaterialID + "\",\"" + 0 + "\",\"" + maxMaterialID + "\"");
                            maxMaterialID++;
                        }
                    }
                }
                File.AppendAllText(pathCSVGen, sb.ToString());
                sb.Clear();
            }
        }

        private void modelFiledata()
        {

            sb.Clear();
            sb.AppendLine("\"LodCount\",\"FileDataID\",\"ModelResourcesID\",\"RelationshipData\"");

            string header = sb.ToString();
            sb.Clear();

            string pathCSVGen = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledata.csv");

            if (File.Exists(pathCSVGen))
            {
                File.Delete(pathCSVGen);
            }
            File.AppendAllText(pathCSVGen, header);

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataGen.csv")))
            {
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataGen.csv"));
            }

            db2.ListeModelFileData(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataGen.csv");

            int maxMaterialID = 0;

            string pathDB2Read = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataGen.csv");

            if (File.Exists(pathDB2Read))
            {
                string[] temp = File.ReadAllLines(pathDB2Read);
                sb.Clear();
                for (int i = 0; i < temp.Length; i++)
                {
                    sb.AppendLine(temp[i].Split(',')[2]);
                }
                File.WriteAllText(pathDB2Read, sb.ToString());
                sb.Clear();
                maxMaterialID = File.ReadAllLines(pathDB2Read).Select(int.Parse).Max() + 1;
                string file1 = File.ReadAllText(pathDB2Read);
                if (dataGridView1.DataSource != null)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (!file1.Contains(dataGridView1.Rows[i].Cells[1].Value.ToString()) && dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(".m2"))
                        {
                            sb.AppendLine("\"0\",\"" + dataGridView1.Rows[i].Cells[1].Value + "\",\"" + maxMaterialID + "\",\"" + maxMaterialID + "\"");
                            maxMaterialID++;
                        }
                    }
                }
                File.AppendAllText(pathCSVGen, sb.ToString());
                sb.Clear();
            }
            else
            {
                db2.ListeModelFileDataLastOffi(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataLastOffi.csv");
                string PathCSV = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataLastOffi.csv");
                string temp = File.ReadAllText(PathCSV);
                maxMaterialID = int.Parse(temp.Split(',')[2]) + 1;

                if (maxMaterialID < 50000)
                    maxMaterialID = 50000;

                if (dataGridView1.DataSource != null)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(".m2"))
                        {
                            sb.AppendLine("\"0\",\"" + dataGridView1.Rows[i].Cells[1].Value + "\",\"" + maxMaterialID + "\",\"" + maxMaterialID + "\"");
                            maxMaterialID++;
                        }
                    }
                }
                File.AppendAllText(pathCSVGen, sb.ToString());
                sb.Clear();
            }
        }

        private void CSVGenBtn_Click(object sender, EventArgs e)
        {
            textureFiledata();
            modelFiledata();

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataLastOffi.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataLastOffi.csv"));

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataGen.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataGen.csv"));

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataLastOffi.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataLastOffi.csv"));

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataGen.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataGen.csv"));
        }

        private string getTableColumns(string tableName)
        {
            if (con.Connected())
            {
                sb = new StringBuilder();

                MySqlCommand cmd = new MySqlCommand(@"SELECT column_name as 'Column Name'
                                                      FROM information_schema.columns
                                                      WHERE table_name = '" + tableName + "'", con.TheConnection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sb.Append(reader["Column Name"].ToString());
                    sb.Append(',');
                }
                reader.Close();
                tableColumn = sb.ToString().Substring(0, sb.ToString().LastIndexOf(','));

                return tableColumn;
            }
            else
            {
                MessageBox.Show("No Active Connection");
                con.Disconnect();
                return null;
            }
        }

    }
}
