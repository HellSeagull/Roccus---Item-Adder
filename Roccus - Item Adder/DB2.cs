using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascStorageLib;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Drawing;

namespace Roccus___Item_Adder
{
    public class DB2
    {

        public static Storage<Definitions.LEGION.itemdisplayinfo> itemdisplayinfo = new Storage<Definitions.LEGION.itemdisplayinfo>(@"D:\LOCAL 7.3.5\caschost\wwwroot\data\DBFilesClient\itemdisplayinfo.db2");
        public static Storage<Definitions.LEGION.itemdisplayinfomaterialres> itemdisplayinfomaterialres = new Storage<Definitions.LEGION.itemdisplayinfomaterialres>(@"D:\LOCAL 7.3.5\caschost\wwwroot\data\DBFilesClient\itemdisplayinfomaterialres.db2");
        public static Storage<Definitions.LEGION.modelfiledata> modelfiledata = new Storage<Definitions.LEGION.modelfiledata>(@"D:\LOCAL 7.3.5\caschost\wwwroot\data\DBFilesClient\modelfiledata.db2");
        public static Storage<Definitions.LEGION.texturefiledata> texturefiledata = new Storage<Definitions.LEGION.texturefiledata>(@"D:\LOCAL 7.3.5\caschost\wwwroot\data\DBFilesClient\texturefiledata.db2");
        private int minIDCasc = int.Parse(ConfigurationManager.AppSettings["startCaschost"]);

        public void ListeModelFileData(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150,150);
            frm.BringToFront();
            frm.Show();
            var _modelfiledata = modelfiledata.Values;
            foreach(var item in _modelfiledata)
            {
                if(item.FileDataID >= minIDCasc)
                    File.AppendAllText(Path.Combine(filePath, db2Name), item.LodCount +","+item.FileDataID+","+item.ModelResourcesID+"\n");
            }
            frm.Close();
        }

        public void ListeModelFileDataLastOffi(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150, 150);
            frm.BringToFront();
            frm.Show();
            var _modelfiledata = modelfiledata.Values;
            foreach (var item in _modelfiledata)
            {
                if (item.FileDataID == int.Parse(ConfigurationManager.AppSettings["modelFileDataLastOffiId"]))
                    File.AppendAllText(Path.Combine(filePath, db2Name), item.LodCount + "," + item.FileDataID + "," + item.ModelResourcesID + "\n");
            }
            frm.Close();
        }

        public void ListeTextureFileData(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150,150);
            frm.BringToFront();
            frm.Show();
            var _textureFileData = texturefiledata.Values;
            foreach (var item in _textureFileData)
            {
                if (item.FileDataID >= minIDCasc)
                    File.AppendAllText(Path.Combine(filePath, db2Name), item.FileDataID +","+ item.MaterialResourcesID +","+item.UsageType+"\n");
            }
            frm.Close();
        }

        public void ListeTextureFileDataLastOffi(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150, 150);
            frm.BringToFront();
            frm.Show();
            var _textureFileData = texturefiledata.Values;
            foreach (var item in _textureFileData)
            {
                if (item.FileDataID == int.Parse(ConfigurationManager.AppSettings["textureFileDataLastOffiId"]))
                    File.AppendAllText(Path.Combine(filePath, db2Name), item.FileDataID + "," + item.MaterialResourcesID + "," + item.UsageType + "\n");
            }
            frm.Close();
        }

        public void ListeItemDisplayInfo(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150, 150);
            frm.BringToFront();
            frm.Show();
            var _itemDisplayInfo = itemdisplayinfo.Values;
            var _modelFileData = modelfiledata.Values;
            foreach (var item in _itemDisplayInfo)
            {
                File.AppendAllText(Path.Combine(filePath, db2Name), item.ID + "," + item.ModelResourcesID[0] + "," + item.ModelMaterialResourcesID[0] + "\n");
            }
            frm.Close();
        }

        public void ListeItemDisplayInfoLastOffi(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150, 150);
            frm.BringToFront();
            frm.Show();
            var _itemDisplayInfo = itemdisplayinfo.Values;
            var _modelFileData = modelfiledata.Values;
            foreach (var item in _itemDisplayInfo)
            {
                if (item.ID == int.Parse(ConfigurationManager.AppSettings["itemDisplayInfoLastOffiId"]))
                {
                    File.AppendAllText(Path.Combine(filePath, db2Name), item.ID + "," + item.ModelResourcesID[0] + "," + item.ModelMaterialResourcesID[0] + "\n");
                }
            }
            frm.Close();
        }

        public void ListeItemDisplayInfoMaterialRes(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150, 150);
            frm.BringToFront();
            frm.Show();
            var _itemDisplayInfomaterialres = itemdisplayinfomaterialres.Values;
            foreach (var material in _itemDisplayInfomaterialres)
            {
                File.AppendAllText(Path.Combine(filePath, db2Name), material.ID + "," + material.MaterialResourcesID + "," + material.ComponentSection + "\n");
            }
            frm.Close();
        }

        public void ListeItemDisplayInfoMaterialResLastOffi(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150, 150);
            frm.BringToFront();
            frm.Show();
            var _itemDisplayInfomaterialres = itemdisplayinfomaterialres.Values;
            foreach (var material in _itemDisplayInfomaterialres)
            {
                if (material.ID == int.Parse(ConfigurationManager.AppSettings["itemMaterialResLastOffiId"]))
                {
                    File.AppendAllText(Path.Combine(filePath, db2Name), material.ID + "," + material.MaterialResourcesID + "," + material.ComponentSection + "\n");
                }
            }
            frm.Close();
        }

    }
}
