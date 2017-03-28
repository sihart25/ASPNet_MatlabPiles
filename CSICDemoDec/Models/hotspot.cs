using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace CSICDemoDec.Models
{

    [DataContract]
    [KnownType(typeof(object[]))]
    public class HotSpotArray : ICollection
    { 
        public Project HotSpotArrayProjectRef{get; set;}
        [DataMember]
        public string HotSpotArrayCollectionName{get; set;}
        [DataMember]
        private ArrayList HotSpotItemArray{get; set;} 

        public HotSpotArray()
        {

            HotSpotItemArray = new ArrayList();
        }
        
        public void Initialize(ref Project projref)
        {
            ///TODO::SIMON INITIALISE
            HotSpotArrayProjectRef = projref;
        }

        public HotSpotItem this[int index]
        {
            get { return (HotSpotItem)HotSpotItemArray[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            HotSpotItemArray.CopyTo(a, index);
        }
        public int Count
        {
            get { return HotSpotItemArray.Count; }
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
            return HotSpotItemArray.GetEnumerator();
        }

        public void Add(HotSpotItem newItem)
        {
            HotSpotItemArray.Add(newItem);
        }
    }

    [DataContract]
    public class HotSpotItem
    {
        public HotSpotItem(long SpotItemMapID, double SpotItemPosX, double SpotItemPosY, double SpotItemRadius, string SpotItemValueDesc)
        { 
             HotSpotItemMapID = SpotItemMapID;
             HotSpotItemPosX =SpotItemPosX; 
             HotSpotItemPosY  =SpotItemPosY;  
             HotSpotItemRadius =SpotItemRadius;  
             HotSpotItemValueDesc =SpotItemValueDesc;
             HotSpotSensorRef = null;
        }

        public void Initialize(ProjectSensorItem sens)
        {
            ///TODO::SIMON INITIALISE
            HotSpotSensorRef = sens; 
        }


        [DataMember]
        public long HotSpotItemMapID { get; set; }
        [DataMember]
        public double HotSpotItemPosX { get; set; }
        [DataMember]
        public double HotSpotItemPosY { get; set; }

        [DataMember]
        public double HotSpotItemRadius { get; set; }
        public double HotSpotItemValue { get { if (HotSpotSensorRef != null)return HotSpotSensorRef.ProjectSensorItemLastReading; else return double.NaN; } }
        [DataMember]
        public string HotSpotItemValueDesc { get; set; }
        public CSICDemoDec.Models.ProjectSensorItem  HotSpotSensorRef { get; set; }

    }
}
