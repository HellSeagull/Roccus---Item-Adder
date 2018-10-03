using CascStorageLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roccus___Item_Adder.Definitions.LEGION
{
    public class itemdisplayinfo
    {

        [Index]
        public int ID;
        public int Flags;
        public int ItemRangedDisplayInfoID;
        public int ItemVisual;
        public int ParticleColorID;
        public int OverrideSwooshSoundKit;
        public int SheatheTransformMatrixID;
        public int ModelType1;
        public int StateSpellVisualKitID;
        public int SheathedSpellVisualKitID;
        public int UnsheathedSpellVisualKitID;
        public int[] ModelResourcesID = new int[2];
        public int[] ModelMaterialResourcesID = new int[2];
        public int[] GeosetGroup = new int[4];
        public int[] AttachmentGeosetGroup = new int[4];
        public int[] HelmetGeosetVis = new int[2];

    }
}
