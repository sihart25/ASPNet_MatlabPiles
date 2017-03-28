using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using CSICDemoDec.Utils; 

namespace CSICDemoDec.Models
{

    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.TimeLineItemArray))]
    public class TimeLineItemArray: ICollection
    {

        #region StaticDefaultValues
        static public string _TIMELINE_ITEM_ARRAY_HEADLINE = "_TIMELINE_ITEM_ARRAY_HEADLINE";
        static public string _TIMELINE_MAIN = "_TIMELINE_MAIN";
        #endregion

        public Project _myProject;
        [DataMember]
        public string TimeLineItemArrayCollectionName = _TIMELINE_ITEM_ARRAY_HEADLINE;
        [DataMember] 
        private ArrayList TimeLineItemArrayList = new ArrayList();

        [DataMember]
        [DataType(DataType.Date)]
        [UIHint("DateTime2")]
        public DateTime TimeLineItemArrayBeginTime { get; set; }

        public TimeLineItemArray()
            : this(_TIMELINE_ITEM_ARRAY_HEADLINE, DateTime.MinValue)
        {

        }

        public TimeLineItemArray(string CollectionName,DateTime dt)
        {
            TimeLineItemArrayCollectionName = CollectionName;
            TimeLineItemArrayBeginTime = dt;
        }

        public void Initialize(Project p)
        { 
            ///TODO::SIMON INITIALISE
            if(p!=null)
            {
                _myProject = p;
                TimeLineItemArrayBeginTime=p.ProjectStartDate;
                TimeLineItemArrayCollectionName = _TIMELINE_MAIN + p.ProjectID;
                int j = this.Count;
                for(int i=0;i<j;i++)
                {
                    this[i].Initialize(p);
                }
            } 
        }

        public TimeLineItem this[int index]
        {
            get { return (TimeLineItem)TimeLineItemArrayList[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            TimeLineItemArrayList.CopyTo(a, index);
        }
        public int Count
        {
            get { return TimeLineItemArrayList.Count; }
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
            return TimeLineItemArrayList.GetEnumerator();
        }

        public void Add(TimeLineItem newItem)
        {
            TimeLineItemArrayList.Add(newItem);
        }
    }

    [DataContract]
     public class TimeLineItem
     {
         #region StaticDefaultValues
         static public string _TIMELINE_HEADLINE = "_TIMELINE_HEADLINE";
         static public string _TIMELINE_TEXT = "_TIMELINE_TEXT";
         static public string _TIMELINE_MEDIA = "_TIMELINE_MEDIA";
         static public string _TIMELINE_MEDIACREDIT = "_TIMELINE_MEDIA";
         static public string _TIMELINE_MEDIACAPTION = "_TIMELINE_MEDIACAPTION";
         static public string _TIMELINE_MEDIATHUMBNAIL = "_TIMELINE_MEDIATHUMBNAIL";
         static public string _TIMELINE_MEDIATYPE = "_TIMELINE_MEDIATYPE";
         static public string _TIMELINE_MEDIATAG = "_TIMELINE_MEDIATAG";
         #endregion

         public TimeLineItem()  : this(DateTime.Now.AddSeconds(-10), DateTime.Now,"-1" ,_TIMELINE_HEADLINE, _TIMELINE_TEXT, _TIMELINE_MEDIA, _TIMELINE_MEDIACREDIT, _TIMELINE_MEDIACAPTION, _TIMELINE_MEDIATHUMBNAIL, _TIMELINE_MEDIATYPE, _TIMELINE_MEDIATAG)
         { 
         }

         public TimeLineItem(string projectid)
             : this(DateTime.Now.AddSeconds(-10), DateTime.Now, projectid, _TIMELINE_HEADLINE, _TIMELINE_TEXT, _TIMELINE_MEDIA, _TIMELINE_MEDIACREDIT, _TIMELINE_MEDIACAPTION, _TIMELINE_MEDIATHUMBNAIL, _TIMELINE_MEDIATYPE, _TIMELINE_MEDIATAG)
         {
         }

         public TimeLineItem(DateTime a1, DateTime b2,string projectid, string headline3, string text4, string Media5, string MediaCredit6, string MediaCaption7, string MediaThumbnail8, string Type9, string Tag10)         
         { 
              TimeLineItemBeginTime = a1; //Start Date [1]
              TimeLineItemEndTime = b2; //End Date [2]
              TimeLineItemSpan = TimeLineItemBeginTime - TimeLineItemEndTime;

              TimeLineItemHeadline = headline3;//Headline [3]
              TimeLineItemText = text4;//Text [3]
              TimeLineItemMedia = Media5;//Media [3]
              TimeLineItemMediaCredit = MediaCredit6;//Media Credit  [3]
              TimeLineItemMediaCaption = MediaCaption7;//Media Caption  [3]
              TimeLineItemMediaThumbnail = MediaThumbnail8;//Media Thumbnail  [5]
              TimeLineItemType = Type9;//Type  [5]
              TimeLineItemTag = Tag10;//Tag [5]
         }

        
         public void Initialize(Project p)
         {
             TimeLineItemProjectID = TimeLineItemArray._TIMELINE_MAIN + p.ProjectID;
         }

         [DataMember]
         [DataType(DataType.Date)]
         [UIHint("DateTime2")]
         public DateTime TimeLineItemBeginTime { get; set; } //Start Date [1]
         [DataMember]
         [DataType(DataType.Date)]
         [UIHint("DateTime2")]
         public DateTime TimeLineItemEndTime { get; set; }  //End Date [2]
         public TimeSpan TimeLineItemSpan { get; set; }
         public string TimeLineItemProjectID { get; set; }

         [DataMember]
         public string TimeLineItemHeadline { get; set; }//Headline [3]
         [DataMember]
         public string TimeLineItemText { get; set; }//Text [3]
         [DataMember]
         public string TimeLineItemMedia { get; set; }//Media [3]
         [DataMember]
         public string TimeLineItemMediaCredit { get; set; }//Media Credit  [3]
         [DataMember]
         public string TimeLineItemMediaCaption { get; set; }//Media Caption  [3]
         [DataMember]
         public string TimeLineItemMediaThumbnail { get; set; }//Media Thumbnail  [5]
         [DataMember]
         public string TimeLineItemType { get; set; }//Type  [5]
         [DataMember]
         public string TimeLineItemTag { get; set; }//Tag [5]
          

    }
}
