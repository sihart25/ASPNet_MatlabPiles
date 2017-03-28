using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using CSICDemoDec.Utils; 

namespace CSICDemoDec.Models
{

    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.ProjectSensorItemReadingsArray))]
    public class ProjectSensorItemReadingsArray : ICollection
    {

        #region StaticDefaultValues
        static public string _SENSOR_READING_ARRAY_HEADLINE = "_SENSOR_READING_ARRAY_HEADLINE";
        static public string _SENSOR_READING_MAIN = "_SENSOR_READING_MAIN";
        #endregion

        public Project _myProject;

        [DataMember]
        public string ProjectSensorItemReadingsArrayCollectionName = _SENSOR_READING_ARRAY_HEADLINE;
        [DataMember] 
        private ArrayList ProjectSensorItemReadingsArrayList = new ArrayList(); 

        public ProjectSensorItemReadingsItem this[int index]
        {
            get { return (ProjectSensorItemReadingsItem)ProjectSensorItemReadingsArrayList[index]; }
        }


        public void Initialize(ref Project p,ref ProjectSensorItem s)
        { 
            ///TODO::SIMON INITIALISE
            if(p!=null)
            {
                _myProject = p; 
                ProjectSensorItemReadingsArrayCollectionName = _SENSOR_READING_MAIN + p.ProjectID+s.ProjectSensorItemSensorTagID;

            } 
        }

        public void CopyTo(Array a, int index)
        {
            ProjectSensorItemReadingsArrayList.CopyTo(a, index);
        }
        public int Count
        {
            get { return ProjectSensorItemReadingsArrayList.Count; }
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
            return ProjectSensorItemReadingsArrayList.GetEnumerator();
        }

        public void Add(ProjectSensorItemReadingsItem newItem)
        {
            ProjectSensorItemReadingsArrayList.Add(newItem);
        }
    }



    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.ProjectSensorItemReadingsItem))]
    public class ProjectSensorItemReadingsItem
    {
        #region StaticDefaultValues
        static public string _SENSOR_READING_ITEM_ARRAY_HEADLINE = "_SENSOR_READING_ITEM_ARRAY_HEADLINE";
        static public string _SENSOR_READING_ITEM_DEFAULT_NONE_ID = "_TIMELINE_MAIN";
        static public string _SENSOR_READING_ITEM_DEFAULT_NONE_KEY = "_TIMELINE_MAIN_KEY";
        #endregion

        private int _upper = -1;
        private int _lower = -1;
        public ProjectSensorItemReadingsItem():this(_SENSOR_READING_ITEM_ARRAY_HEADLINE, DateTime.MinValue,null,null)
        {
        }

        public ProjectSensorItemReadingsItem(string trtitle, DateTime tdate, Dictionary<string, string> tdefaultvals, List<double> tValues)
        {
            _upper = _lower = -1;

            ProjectSensorItemReadingtitle = trtitle;
            ProjectSensorItemReadingTaken = tdate;
            if(tdefaultvals==null) 
            {
                var first = tdefaultvals.First();
                string firstValue = first.Value; 
                if((firstValue!=double.NaN.ToString()))
                {
                 ProjectSensorItemDefaultValues = tdefaultvals;
                 ProjectSensorItemHasDefaultValues= true;

                }
                else
                {
                    ProjectSensorItemDefaultValues =new Dictionary<string,string>();
                    ProjectSensorItemHasDefaultValues=false; 
                }

            }
            else
            {
                ProjectSensorItemDefaultValues =new Dictionary<string,string>();
                ProjectSensorItemHasDefaultValues=false;

            }

            if((tValues==null))
            {
                    if((tValues[0]!=double.NaN))
                    { 
                      ProjectSensorItemValues = tValues;
                    }
                    else
                    {
                        ProjectSensorItemValues= new List<double>();
                        ProjectSensorItemHasItemValues = false;
                    }
            }
            else
            {
                ProjectSensorItemValues= new List<double>(); 
                ProjectSensorItemHasItemValues = false;
            }
        }

        public ProjectSensorItemReadingsItem(string filename)
        {
            ReadCsvFiber(filename);

        }

        
        public void Initialize(Project p, ProjectSensorItem s)
        {
 
        }


        [DataMember]
        public string ProjectSensorItemReadingtitle { get; set; }

        [DataMember]
        [DataType(DataType.Date)]
        [UIHint("DateTime2")]
        public DateTime ProjectSensorItemReadingTaken { get; set; }
        [DataMember]
        public bool ProjectSensorItemHasDefaultValues {get;set;} 
        [DataMember]
        public Dictionary<string, string> ProjectSensorItemDefaultValues { get; set; }
        [DataMember]
        public List<double> ProjectSensorItemValues { get; set; }
        [DataMember]
        public bool ProjectSensorItemHasItemValues {get;set;}
        [DataMember]
        public double ProjectSensorItemLastReading { get; set; }

        public int ProjectSensorItemCurrentUpperLimit { get { if (this.ProjectSensorItemHasItemValues)return _upper; else return -1; } }

        public int ProjectSensorItemCurrentLowerLimit { get { if (this.ProjectSensorItemHasItemValues)return _lower; else return -1; } }
        public double ProjectSensorItemCurrentUpperLimitValue { get { if (this.ProjectSensorItemHasItemValues)return ProjectSensorItemValues[_upper]; else return double.NaN; } }

        public double ProjectSensorItemCurrentLowerLimitValue { get { if (this.ProjectSensorItemHasItemValues)return ProjectSensorItemValues[_lower]; else return double.NaN; } }

        public void between(ref int lower,ref int upper)
        {

            _upper = _lower = -1;
        }
        
        [DataMember]
        public bool ProjectSensorItemHasLimitValues {get;set;}

        [DataMember]
        public List<double> ProjectSensorItemLimitValues { get; set; }

        public static ProjectSensorItemReadingsItem ReadCsvFiber(string str)
        {

            var reader = new StreamReader(File.OpenRead(str));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[0]);
                listB.Add(values[1]);
            }

            //find date DateTime

            // "~/Content/00000635.csv"
          //TODO::SIMON  ReadingsItem ret = new ReadingsItem();


            //TODO::SIMON   return ret;
            return null;
        }

        bool TestLimits(double val)
        {
            bool ret = false;
            if(this.ProjectSensorItemHasLimitValues==true)
            {

            }else
            {

            }
            return ret;
        }
        private void sortLimits()
        {
            var sorted = from dbl in ProjectSensorItemLimitValues
                         orderby dbl descending
                         select dbl;
        }

    }
}
