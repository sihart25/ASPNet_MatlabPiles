using System;
using System.IO;
using System.Collections; 
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CSICDemoDec.Models
{
    [DataContract]
    public class Project
    {
        [DataMember]
        public List<string> ProjectRefNo { get; set; }
        [DataMember]
        public string ProjectName { get; set; }
        [DataMember]
        public string ProjectDescription { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        [UIHint("DateTime2")]
        public DateTime ProjectStartDate { get; set; }

        [DataMember]
        public long ProjectID { get; set; }
        [DataMember]
        public TimeLineItemArray ProjectTimelineList { get; set; }
        [DataMember]
        public ProjectUserArray ProjectUsersList { get; set; }
        [DataMember] 
        public ProjectSensorItemArray ProjectSensorList { get; set; }
        [DataMember]
        public ProjectUser ProjectOwner { get; set; }
        [DataMember] 
        public Location ProjectLocation { get; set; }
        [DataMember]
        public bool ProjectIsBeam { get; set; }
        [DataMember]
        public bool ProjectIsPile { get; set; }
        [DataMember]
        public bool ProjectIsTunnel { get; set; }
        [DataMember]
        public bool ProjectIsDWall { get; set; }
        public Project(ProjectUser U,string autoRef)
        {

            ProjectRefNo = new List<string>();
            ProjectRefNo.Add(autoRef);
            ProjectName = "New projects";
            ProjectDescription = "Change this to a short project summary which is helpful";
            ProjectID = -1;
            ProjectStartDate = new DateTime(1980, 12, 25);
            ProjectTimelineList = new TimeLineItemArray();
            ProjectUsersList =  new ProjectUserArray();
            ProjectUsersList.Add(U);
            ProjectSensorList = new ProjectSensorItemArray();
            ProjectOwner = U;
            ProjectLocation = new Location();
            ProjectIsBeam = false;   
            ProjectIsPile   =true;
            ProjectIsTunnel = false;
            ProjectIsDWall = false;
        } 
        public void Initialize()
        {
            ///TODO::SIMON INITIALISE 
              ProjectTimelineList.Initialize(this);
              ProjectSensorList.Initialize(this);
            
        }


    }

}
