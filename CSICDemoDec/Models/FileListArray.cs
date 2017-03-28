using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace CSICDemoDec.Models
{ 

    public class FileListArray : ICollection
    {
        public string CollectionName;
        private ArrayList itemArray = new ArrayList();

        public FileItem this[int index]
        {
            get { return (FileItem)itemArray[index]; }
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

        public void Add(FileItem newItem)
        {
            itemArray.Add(newItem);
        }
    }

    public class FileItem
    {

        public FileItem(DateTime st, DateTime end, DateTime cr, DateTime Mod, string title, string txt, List<FileItem> RelatedDoc, List<string> tags,bool Superceed)
        {
            FileItemBegintime = st;
            FileItemEndtime = end;
            FileItemCreateTime = cr;
            FileItemModifiedTime = Mod;
            FileItemTitle = title;
            FileItemDesc = txt;
            FileItemRelatedDocLinks = RelatedDoc;
            FileItemTags = tags;
            FileItemSuperceded = Superceed;
        }

        public DateTime FileItemBegintime { get; set; }
        public DateTime FileItemEndtime { get; set; }
        public DateTime FileItemCreateTime { get; set; }
        public DateTime FileItemModifiedTime { get; set; }
        public string FileItemTitle { get; set; }
        public string FileItemDesc { get; set; }
        public List<FileItem> FileItemRelatedDocLinks { get; set; }
        public List<string> FileItemTags { get; set; }
        public bool FileItemSuperceded { get; set; }

    }
}
