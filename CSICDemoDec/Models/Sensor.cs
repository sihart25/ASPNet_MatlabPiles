using System;
using System.IO;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using CSICDemoDec.Utils; 

namespace CSICDemoDec.Models
{

    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.ProjectSensorItemArray))]
    public class ProjectSensorItemArray : ICollection
    {

        #region StaticDefaultValues
        static public string _SENSOR_ITEM_ARRAY_HEADLINE = "_SENSOR_ITEM_ARRAY_HEADLINE"; 
        static public string _SENSOR_MAIN = "_SENSOR_MAIN";
        #endregion

        public Project _myProject;
        [DataMember]  
        public string ProjectSensorItemArrayCollectionName =_SENSOR_ITEM_ARRAY_HEADLINE;
        [DataMember] 
        private ArrayList ProjectSensorItemArrayList = new ArrayList();

        public ProjectSensorItem this[int index]
        {
            get { return (ProjectSensorItem)ProjectSensorItemArrayList[index]; }
        }
        
        public void Initialize(Project p)
        { 
            ///TODO::SIMON INITIALISE
            if(p!=null)
            {
                _myProject = p; 
                ProjectSensorItemArrayCollectionName = _SENSOR_MAIN + p.ProjectID;
            } 
        }
        public void CopyTo(Array a, int index)
        {
            ProjectSensorItemArrayList.CopyTo(a, index);
        }
        public int Count
        {
            get { return ProjectSensorItemArrayList.Count; }
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
            return ProjectSensorItemArrayList.GetEnumerator();
        }

        public void Add(ProjectSensorItem newItem)
        {
            ProjectSensorItemArrayList.Add(newItem);
        }
    }
    
    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.ProjectSensorItem))]
    public class ProjectSensorItem
    {


        #region StaticDefaultValues

        static public string _SENSOR_ITEM_TAGID = "_SENSOR_ITEM_TAGID"; 
        #endregion
        public ProjectSensorItem()
            : this(DateTime.MinValue, DateTime.MinValue, -1, _SENSOR_ITEM_TAGID, double.NaN, double.NaN, double.NaN, null)
        {

        }

        public ProjectSensorItem(DateTime tbegintime, DateTime tendtime, long tSensorID, string tSensorTagID, double tPosX, double tPosY, double tPosZ,ProjectSensorItemReadingsItem tReadings )
        {
             ProjectSensorItembegintime= tbegintime ;
             if (tendtime == DateTime.MinValue)
             {
                 ProjectSensorItemendtime = tendtime;
                 ProjectSensorItemisActive = false;
             }else
             {

                 ProjectSensorItemendtime = DateTime.MinValue;
                 ProjectSensorItemisActive = false;
             }

             ProjectSensorItemSensorID= tSensorID ; 
             ProjectSensorItemSensorTagID= tSensorTagID ; 
             ProjectSensorItemPosX = tPosX ; 
             ProjectSensorItemPosY = tPosY ;  
             ProjectSensorItemPosZ = tPosZ ;
             if (tReadings!=null)
            {
             ProjectSensorItemReadings = tReadings ;
            }
             else
             {
                 ProjectSensorItemReadings = new ProjectSensorItemReadingsItem();
             }
        }

        [DataMember]
        public bool ProjectSensorItemisActive { get; set; } 
        [DataMember]
        [DataType(DataType.Date)]
        [UIHint("DateTime2")]
        public DateTime ProjectSensorItembegintime { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        [UIHint("DateTime2")]
        public DateTime ProjectSensorItemendtime { get; set; }
        public TimeSpan ProjectSensorItemspan { get; set; }
        [DataMember]
        public long ProjectSensorItemSensorID { get; set; }
        [DataMember]
        public string ProjectSensorItemSensorTagID { get; set; }
        [DataMember]
        public double ProjectSensorItemPosX { get; set; }
        [DataMember]
        public double ProjectSensorItemPosY { get; set; }
        [DataMember]
        public double ProjectSensorItemPosZ { get; set; }
        public double ProjectSensorItemLastReading { get { return ProjectSensorItemReadings.ProjectSensorItemLastReading; } }
        [DataMember]
        public ProjectSensorItemReadingsItem ProjectSensorItemReadings { get; set; }
        public double ProjectSensorItemCurrentUpperLimit { get { return ProjectSensorItemReadings.ProjectSensorItemCurrentUpperLimit; } }
        public double ProjectSensorItemCurrentLowerLimit { get { return ProjectSensorItemReadings.ProjectSensorItemCurrentLowerLimit; } }
        public List<double> ProjectSensorItemGetAllLimit { get { return ProjectSensorItemReadings.ProjectSensorItemLimitValues; } }

    }
}
