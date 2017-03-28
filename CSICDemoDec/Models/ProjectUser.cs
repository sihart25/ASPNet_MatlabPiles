using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace CSICDemoDec.Models
{
    [DataContract]
    [KnownType(typeof(object[]))]
    public class ProjectUserArray : ICollection
    {
        [DataMember]
        public string ProjectUserArrayCollectionName {get;set;}
        [DataMember]
        private ArrayList ProjectUseritemArray{get; set;}

        public ProjectUserArray()
        {
            ProjectUserArrayCollectionName="ProjectUserArrayCollectionName";
            ProjectUseritemArray = new ArrayList();
        }

        public ProjectUser this[int index]
        {
            get { return (ProjectUser)ProjectUseritemArray[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            ProjectUseritemArray.CopyTo(a, index);
        }
        public int Count
        {
            get { return ProjectUseritemArray.Count; }
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
            return ProjectUseritemArray.GetEnumerator();
        }

        public void Add(ProjectUser newItem)
        {
            ProjectUseritemArray.Add(newItem);
        } 

    }

    [DataContract]
    public class ProjectUser
    {
        public ProjectUser(string UserName,int ID, DateTime useradded,DateTime LastLogin)
        {
            ProjectUserName = UserName;
            ProjectUserID = ID;
            ProjectUserStartDate = useradded;
            ProjectUserLastLoginDate = LastLogin;
            ProjUserNewMessageArray = new MessageItemArray();
            ProjUserSavedMessageArray = new MessageItemArray();
        }


        public void Initialize(ref MessageItemArray msglst,ref MessageItemArray msgSavedlst)
        { 
            // Query database find the message 
            if (msglst.Count>0)
            {
                foreach(MessageItem m in msglst )
                {
                    ProjUserNewMessageArray.Add(m); 
                }
            }
            if (msgSavedlst.Count>0)
            {

                foreach (MessageItem m in msgSavedlst)
                {
                    ProjUserSavedMessageArray.Add(m); 
                }
            }
        }

        [DataMember]
        public string ProjectUserName { get; set; }
        [DataMember]
        public int ProjectUserID { get; set; } 
        [DataMember]
        public DateTime ProjectUserStartDate { get; set; }
        [DataMember]
        public DateTime ProjectUserLastLoginDate { get; set; } 
        [DataMember]
        public MessageItemArray ProjUserNewMessageArray { get; set; }
        [DataMember]
        public MessageItemArray ProjUserSavedMessageArray { get; set; }
         
    }
}
