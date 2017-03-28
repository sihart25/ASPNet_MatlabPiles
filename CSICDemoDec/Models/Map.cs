using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;

namespace CSICDemoDec.Models
{

    public class MapItemArray: ICollection
    {
        public Project _myProject;
        public string CollectionName;
        private ArrayList itemArray = new ArrayList();

        public MapItem this[int index]
        {
            get { return (MapItem)itemArray[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            itemArray.CopyTo(a, index);
        }
        public int Count
        {
            get { return itemArray.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return itemArray.GetEnumerator();
        }

        public void Add(MapItem newItem)
        {
            itemArray.Add(newItem);
        }
    }

    public class MapItem
    {
         public DateTime begintime{get;set;}
         public DateTime endtime{get;set;}
         public TimeSpan span { get; set; }

         public double MapScale{get;set;}

         public long MapID { get; set; }

         public double PosX { get; set; }
         public double PosY { get; set; }
         public double MapWidth { get; set; }
         public double MapHeight { get; set; }

    }

}
