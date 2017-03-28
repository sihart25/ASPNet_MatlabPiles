using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace CSICDemoDec.Models
{
    [DataContract]
    [KnownType(typeof(object[]))]
    public class OpenProjectArray : ICollection
    {
        public Project HotSpotArrayProjectRef{get; set;}
        [DataMember]
        public string OpenProjectCollectionName{get; set;}
        [DataMember] 
        private ArrayList OpenProjectItemArray = new ArrayList();

        public OpenProjectArray()
        {

            OpenProjectItemArray = new ArrayList();
        }

        public void Initialize(ref Project projref)
        {
            ///TODO::SIMON INITIALISE
            HotSpotArrayProjectRef = projref;
        }
        public OpenProjectItem this[int index]
        {
            get { return (OpenProjectItem)OpenProjectItemArray[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            OpenProjectItemArray.CopyTo(a, index);
        }
        public int Count
        {
            get { return OpenProjectItemArray.Count; }
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
            return OpenProjectItemArray.GetEnumerator();
        }

        public void Add(OpenProjectItem newItem)
        {
            OpenProjectItemArray.Add(newItem);
        }
    }

    public class OpenProjectItem
    {
        public OpenProjectItem(string name, string title, Uri u)
        {
            this.Name = name;
            this.URI = u;
            this.Title = title;
        }
        public Uri URI { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

    }
}