using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;

namespace CSICDemoDec.Models
{
    public class OpenModelArray : ICollection
    {
     
        public string CollectionName;
        private ArrayList itemArray = new ArrayList();

        public OpenModelItem this[int index]
        {
            get { return (OpenModelItem)itemArray[index]; }
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

        public void Add(OpenModelItem newItem)
        {
            itemArray.Add(newItem);
        }
    }

    public class OpenModelItem
    {
        public OpenModelItem(string name, string title, Uri u)
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