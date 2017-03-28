using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CSICDemoDec.Models
{ 
    public class MessageItemArray : ICollection
    {
        public string CollectionName;
        private ArrayList MessageItemArrayList = new ArrayList();

        public MessageItem this[int index]
        {
            get { return (MessageItem)MessageItemArrayList[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            MessageItemArrayList.CopyTo(a, index);
        }
        public int Count
        {
            get { return MessageItemArrayList.Count; }
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
            return MessageItemArrayList.GetEnumerator();
        }

        public void Add(MessageItem newItem)
        {
            MessageItemArrayList.Add(newItem);
        }
    }

    public class MessageItem
    {
        public MessageItem(DateTime st,DateTime end,string title, string txt,string msglinks,int level, List<string> tags,ProjectUser poster)
        {
            begintime = st;
            endtime = end; ;
            MsgTitle = title;
            MsgTxt = txt;
            MsgLinks = msglinks;
            MsgLevel = level;
            MsgTags = tags;
            MsgCreator = poster;
        }

        public DateTime begintime { get; set; }
        public DateTime endtime { get; set; }
        public TimeSpan span { get; set; }
        public string MsgTitle { get; set; }
        public string MsgTxt { get; set; }
        public string MsgLinks { get; set; }
        public int MsgLevel{ get; set; }
        public List<string> MsgTags { get; set; }
        public ProjectUser MsgCreator { get; set; }
    }
}
