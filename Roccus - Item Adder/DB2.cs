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

        public void ListeItemDisplayInfo(string filePath, string db2Name)
        {
            Form frm = new Form();
            frm.Text = db2Name;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackColor = Color.Yellow;
            frm.Size = new Size(150,150);
            frm.BringToFront();
            frm.Show();
            var _itemDisplayInfo = itemdisplayinfo.Values;
            var _modelFileData = modelfiledata.Values;
            foreach (var item in _itemDisplayInfo)
            {
                foreach(var data in _modelFileData)
                {
                    if(data.FileDataID >= minIDCasc)
                    {
                        if(data.ModelResourcesID == item.ModelResourcesID[0] || data.ModelResourcesID == item.ModelResourcesID[1]){
                            File.AppendAllText(Path.Combine(filePath, db2Name), item.ID +","+item.ModelResourcesID[0]+","+item.ModelMaterialResourcesID[0]+"\n");
                        }
                        else if(data.ModelResourcesID != item.ModelResourcesID[0] && item.ID > 168092 || data.ModelResourcesID != item.ModelResourcesID[1] && item.ID > 168092)
                        {
                            File.AppendAllText(Path.Combine(filePath, db2Name), item.ID+","+item.ModelResourcesID[0]+","+item.ModelMaterialResourcesID[0]+"\n");
                        }
                    }
                }            
            }
            frm.Close();
        }

        public void ListItemDisplayInfoMaterialRes(string filePath, string db2Name)
        {
            var _modelfiledata = modelfiledata.Values;
            foreach (var item in _modelfiledata)
            {
                if (item.FileDataID >= minIDCasc)
                    File.AppendAllText(Path.Combine(filePath, db2Name), "\"" + item.LodCount + "\",\"" + item.FileDataID + "\",\"" + item.ModelResourcesID + "\"\n");
            }
            MessageBox.Show("Done");
        }

    }
}
