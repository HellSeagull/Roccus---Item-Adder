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
using System.Text.RegularExpressions;
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
        private Dictionary<string, int> collectionsModels;
        private Dictionary<string, int> collectionsTextures;
        private Dictionary<string, int> armorTextures;
        private List<string> collectionsRootName;

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
                                      ConfigurationManager.AppSettings["Table"] + " WHERE " + ConfigurationManager.AppSettings["Path"] + " LIKE '%" + SQLFilter + "%' ORDER BY " +
                                      ConfigurationManager.AppSettings["FileDataID"], con.TheConnection);
                MySqlDataReader reader = query.ExecuteReader();
                dt = new DataTable();
                dt.Columns.Add(ConfigurationManager.AppSettings["Path"]);
                dt.Columns.Add(ConfigurationManager.AppSettings["FileDataID"]);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(new Object[] { reader.GetString(0), reader.GetString(1) });
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

        private void itemdisplayinfo()
        {
            collectionsModels = new Dictionary<string, int>();
            collectionsTextures = new Dictionary<string, int>();
            armorTextures = new Dictionary<string, int>();
            collectionsRootName = new List<string>();
            int maxDisplayinfo = 0;
            sb.Clear();
            sb.AppendLine("\"ID\",\"Flags\",\"ItemRangedDisplayInfoID\",\"ItemVisual\",\"ParticleColorID\",\"OverrideSwooshSoundKit\",\"SheatheTransformMatrixID\",\"ModelType1\"," +
                           "\"StateSpellVisualKitID\",\"SheathedSpellVisualKitID\",\"UnsheathedSpellVisualKitID\",\"ModelResourcesID_1\",\"ModelResourcesID_1\"," +
                           "\"ModelMaterialResourcesID_1\",\"ModelMaterialResourcesID_2\",\"GeosetGroup_1\",\"GeosetGroup_2\",\"GeosetGroup_3\",\"GeosetGroup_4\"," +
                           "\"AttachmentGeosetGroup_1\",\"AttachmentGeosetGroup_2\",\"AttachmentGeosetGroup_3\",\"AttachmentGeosetGroup_4\",\"HelmetGeosetVis_1\",\"HelmetGeosetVis_2\"");

            string header = sb.ToString();

            sb.Clear();

            string pathCSVGen = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfo.csv");

            if (File.Exists(pathCSVGen))
            {
                File.Delete(pathCSVGen);
            }
            File.AppendAllText(pathCSVGen, header);

            db2.ListeItemDisplayInfoLastOffi(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfoLastOffi.csv");
            string PathCSV = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfoLastOffi.csv");
            string[] file1 = File.ReadAllLines(PathCSV);
            string temp = File.ReadAllText(PathCSV);
            maxDisplayinfo = int.Parse(temp.Split(',')[0]) + 1;
            string[] file2 = File.ReadAllLines(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledata.csv"));
            string[] file3 = File.ReadAllLines(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledata.csv"));
            sb.Clear();

            if (dataGridView1.DataSource != null)
            {
                for (int i = 1; i < file2.Length; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                    {
                        if (file2[i].Split(',')[1].Replace("\"", "") == dataGridView1.Rows[j].Cells[1].Value.ToString())
                        {
                            string collectionModel = dataGridView1.Rows[j].Cells[0].Value.ToString();
                            collectionModel = collectionModel.Substring(SQLFilter.Length + 1, collectionModel.Length - (SQLFilter.Length + 1));
                            Match match = Regex.Match(collectionModel, @"[0-9][0-9]");
                            if (match.Success)
                            {
                                collectionModel = collectionModel.Substring(0, collectionModel.LastIndexOf(match.Groups[0].Value.ToString().ToCharArray()[1]) + 1);
                                bool testContain = false;
                                foreach (string s in collectionsRootName)
                                {
                                    testContain = (s == collectionModel) ? true : false;
                                }
                                if (testContain == false)
                                    collectionsRootName.Add(collectionModel);
                                foreach (string s in collectionsRootName)
                                {
                                    if (dataGridView1.Rows[j].Cells[0].Value.ToString().Contains(s))
                                        collectionsModels.Add(dataGridView1.Rows[j].Cells[0].Value.ToString(), int.Parse(file2[i].Split(',')[3].Replace("\"", "")));
                                }
                            }
                        }
                    }
                }
            }

            if (dataGridView1.DataSource != null)
            {
                for (int i = 1; i < file3.Length; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                    {
                        if (file3[i].Split(',')[0].Replace("\"", "") == dataGridView1.Rows[j].Cells[1].Value.ToString())
                        {
                            string collectionTexture = dataGridView1.Rows[j].Cells[0].Value.ToString();
                            collectionTexture = collectionTexture.Substring(SQLFilter.Length + 1, collectionTexture.Length - (SQLFilter.Length + 1));
                            Match match = Regex.Match(collectionTexture, @"[0-9][0-9]");
                            if (match.Success)
                            {
                                collectionTexture = collectionTexture.Substring(0, collectionTexture.LastIndexOf(match.Groups[0].Value.ToString().ToCharArray()[1]) + 1);
                                bool testContain = false;
                                foreach (string s in collectionsRootName)
                                {
                                    testContain = (s == collectionTexture) ? true : false;
                                }
                                if (testContain == true) collectionsTextures.Add(dataGridView1.Rows[j].Cells[0].Value.ToString(), int.Parse(file3[i].Split(',')[1].Replace("\"", "")));
                            }
                        }
                    }
                }
            }

            if (dataGridView1.DataSource != null)
            {
                for (int i = 1; i < file3.Length; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                    {
                        if (file3[i].Split(',')[0].Replace("\"", "") == dataGridView1.Rows[j].Cells[1].Value.ToString())
                        {
                            string texture = dataGridView1.Rows[j].Cells[0].Value.ToString();
                            texture = texture.Substring(SQLFilter.Length + 1, texture.Length - (SQLFilter.Length + 1));
                            if (texture.ToLowerInvariant().StartsWith("armor")) armorTextures.Add(dataGridView1.Rows[j].Cells[0].Value.ToString(), int.Parse(file3[i].Split(',')[1].Replace("\"", "")));
                        }
                    }
                }
            }

            foreach (string s in collectionsRootName)
            {
                foreach (KeyValuePair<string, int> key in collectionsModels)
                {
                    foreach (KeyValuePair<string, int> tex in collectionsTextures)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (tex.Key.Contains(s))
                            {
                                if (key.Key.Contains(s))
                                {
                                    sb.AppendLine("\"" + maxDisplayinfo + "\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"" + key.Value + "\",\"0\",\"" + tex.Value + "\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\"");
                                    maxDisplayinfo++;
                                }
                            }
                        }
                    }
                }
            }

            File.AppendAllText(pathCSVGen, sb.ToString());
            sb.Clear();
        }

        private void itemdisplayinfomaterialres()
        {
            Dictionary<int, int> sectionComponentChest = new Dictionary<int, int>();
            Dictionary<int, int> sectionComponentGlove = new Dictionary<int, int>();
            Dictionary<int, int> sectionComponentPant = new Dictionary<int, int>();
            Dictionary<int, int> sectionComponentBoot = new Dictionary<int, int>();
            sectionComponentChest.Clear();
            sectionComponentPant.Clear();
            sectionComponentGlove.Clear();
            sectionComponentBoot.Clear();

            int maxMaterialRes = 0;
            sb.Clear();
            sb.AppendLine("\"ID\",\"MaterialResourcesID\",\"ComponentSection\",\"RelationshipData\"");

            string header = sb.ToString();

            sb.Clear();

            string pathCSVGen = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfomaterialres.csv");

            if (File.Exists(pathCSVGen))
            {
                File.Delete(pathCSVGen);
            }
            File.AppendAllText(pathCSVGen, header);

            db2.ListeItemDisplayInfoMaterialResLastOffi(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfomaterialresLastOffi.csv");
            string PathCSV = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfomaterialresLastOffi.csv");
            string[] itemdisplayinfo = File.ReadAllLines(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfo.csv"));
            string[] modelfiledata = File.ReadAllLines(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledata.csv"));
            string[] texturefiledata = File.ReadAllLines(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledata.csv"));
            string[] file1 = File.ReadAllLines(PathCSV);
            maxMaterialRes = int.Parse(file1[0].Split(',')[0]) + 1;
            sb.Clear();

            List<string> displayInfoID = new List<string>();
            for (int i = 1; i < itemdisplayinfo.Length; i++)
            {
                displayInfoID.Add(itemdisplayinfo[i].Replace("\"", ""));
            }

            foreach (KeyValuePair<string, int> key in collectionsTextures)
            {
                foreach (KeyValuePair<string, int> armor in armorTextures)
                {
                    string tempArmor = armor.Key;
                    tempArmor = tempArmor.Substring(SQLFilter.Length + 1, tempArmor.Length - (SQLFilter.Length + 1));
                    Match matchArmor = Regex.Match(tempArmor, @"[0-9][0-9]");
                    if (matchArmor.Success)
                    {
                        tempArmor = tempArmor.Substring(0, tempArmor.LastIndexOf(matchArmor.Groups[0].Value.ToString().ToCharArray()[1]) + 1);
                    }

                    string colorCollec = armor.Key;
                    string armorTexFullname = armor.Key;
                    string collecNumberCode = string.Empty;
                    colorCollec = colorCollec.Substring(SQLFilter.Length + 1, colorCollec.Length - (SQLFilter.Length + 1)).ToLowerInvariant();
                    Match matchColor = Regex.Match(colorCollec, @"[a-z]_[0-9][0-9]_[a-z]*_");
                    if (matchColor.Success)
                    {
                        collecNumberCode = matchColor.Groups[0].Value.ToString();
                        collecNumberCode = collecNumberCode.Substring(0, 4);
                        colorCollec = matchColor.Groups[0].Value.ToString();
                        colorCollec = colorCollec.Substring(5, colorCollec.LastIndexOf("_") - 5);
                    }

                    if (key.Key.ToString().Contains(colorCollec) && key.Key.ToString().Contains(collecNumberCode))
                    {

                        if (armorTexFullname.Contains("chest_tu_") || armorTexFullname.Contains("chest_tl_")
                            || armorTexFullname.Contains("sleeve_au_") || armorTexFullname.Contains("sleeve_al_"))
                        {
                            if (armorTexFullname.Contains("chest_tu_"))
                                sectionComponentChest.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.UpperTorso);
                            if (armorTexFullname.Contains("chest_tl_"))
                                sectionComponentChest.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.LowerTorso);
                            if (armorTexFullname.Contains("sleeve_au_"))
                                sectionComponentChest.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.UpperArm);
                            if (armorTexFullname.Contains("sleeve_al_"))
                                sectionComponentChest.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.LowerArm);
                        }
                        if (armorTexFullname.Contains("pant_lu_") || armorTexFullname.Contains("pant_ll_"))
                        {
                            if (armorTexFullname.Contains("pant_lu_"))
                                sectionComponentPant.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.UpperLeg);
                            if (armorTexFullname.Contains("pant_ll_"))
                                sectionComponentPant.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.LowerLeg);
                        }
                        if (armorTexFullname.Contains("glove_ha_"))
                        {
                            if (armorTexFullname.Contains("glove_ha_"))
                                sectionComponentGlove.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.Hands);
                        }
                        if (armorTexFullname.Contains("boot_fo_") || armorTexFullname.Contains("boot_ll_"))
                        {
                            if (armorTexFullname.Contains("boot_fo_"))
                                sectionComponentBoot.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.Foot);
                            if (armorTexFullname.Contains("boot_ll_"))
                                sectionComponentBoot.Add(armor.Value, (int)EnumDefinition.EnumType.ItemMaterialRes.LowerLeg);
                        }
                    }
                }
            }

            var ListChest = sectionComponentChest.ToList();
            var ListPant = sectionComponentPant.ToList();
            var ListGlove = sectionComponentGlove.ToList();
            var ListBoot = sectionComponentBoot.ToList();
            int counter = -1;

            for (int i = 0; i < displayInfoID.Count; i++)
            {
                foreach (KeyValuePair<string, int> key in collectionsTextures)
                {
                    if(key.Value.ToString() == displayInfoID[i].Split(',')[13])
                    {
                        string materialRef = key.Key;

                        foreach (KeyValuePair<string, int> armor in armorTextures)
                        {

                            string colorCollec = armor.Key;
                            string collecNumberCode = string.Empty;
                            colorCollec = colorCollec.Substring(SQLFilter.Length + 1, colorCollec.Length - (SQLFilter.Length + 1)).ToLowerInvariant();
                            Match matchColor = Regex.Match(colorCollec, @"[a-z]_[0-9][0-9]_[a-z]*_");
                            if (matchColor.Success)
                            {
                                collecNumberCode = matchColor.Groups[0].Value.ToString();
                                collecNumberCode = collecNumberCode.Substring(0, 4);
                                colorCollec = matchColor.Groups[0].Value.ToString();
                                colorCollec = colorCollec.Substring(5, colorCollec.LastIndexOf("_") - 5);
                            }

                            if (key.Key.Contains(collecNumberCode) && key.Key.Contains(colorCollec))
                            {

                                for (int j = 0; j < ListChest.Count; j++)
                                {
                                    if (armor.Value == ListChest[j].Key)
                                    {
                                        sb.AppendLine("\"" + maxMaterialRes + "\",\"" + ListChest[j].Key + "\",\"" + ListChest[j].Value + "\",\"" + displayInfoID[i].Split(',')[0] + "\"");
                                        maxMaterialRes++;
                                    }
                                }

                                for (int j = 0; j < ListPant.Count; j++)
                                {
                                    if (armor.Value == ListPant[j].Key)
                                    {
                                        sb.AppendLine("\"" + maxMaterialRes + "\",\"" + ListPant[j].Key + "\",\"" + ListPant[j].Value + "\",\"" + displayInfoID[i + 1].Split(',')[0] + "\"");
                                        maxMaterialRes++;
                                    }
                                }

                                for (int j = 0; j < ListGlove.Count; j++)
                                {
                                    if (armor.Value == ListGlove[j].Key)
                                    {
                                        sb.AppendLine("\"" + maxMaterialRes + "\",\"" + ListGlove[j].Key + "\",\"" + ListGlove[j].Value + "\",\"" + displayInfoID[i + 2].Split(',')[0] + "\"");
                                        maxMaterialRes++;
                                    }
                                }

                                for (int j = 0; j < ListBoot.Count; j++)
                                {
                                    if (armor.Value == ListBoot[j].Key)
                                    {
                                        sb.AppendLine("\"" + maxMaterialRes + "\",\"" + ListBoot[j].Key + "\",\"" + ListBoot[j].Value + "\",\"" + displayInfoID[i + 3].Split(',')[0] + "\"");
                                        maxMaterialRes++;
                                    }
                                }
                            }
                        }
                    }
                }

                i += 3;
                if (i > displayInfoID.Count)
                    break;
            }

            File.AppendAllText(pathCSVGen, sb.ToString());
            sb.Clear();
            sectionComponentBoot.Clear();
            sectionComponentChest.Clear();
            sectionComponentGlove.Clear();
            sectionComponentPant.Clear();

        }

        private void CSVGenBtn_Click(object sender, EventArgs e)
        {
            textureFiledata();
            modelFiledata();
            itemdisplayinfo();
            itemdisplayinfomaterialres();

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataLastOffi.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataLastOffi.csv"));

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataGen.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "texturefiledataGen.csv"));

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataLastOffi.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataLastOffi.csv"));

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataGen.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "modelfiledataGen.csv"));

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfoLastOffi.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfoLastOffi.csv"));

            if (File.Exists(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfomaterialresLastOffi.csv")))
                File.Delete(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf('\\')), "itemdisplayinfomaterialresLastOffi.csv"));

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
