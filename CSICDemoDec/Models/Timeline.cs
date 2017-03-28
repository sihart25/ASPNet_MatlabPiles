using System.Collections.Generic;
using System.Runtime.Serialization;
using CSICDemoDec.Utils;

namespace CSICDemoDec.Models
{
    //[DataContract]
    //public class Timeline
    //{
    //    public Timeline() { }

    //    public Timeline(string headline, string type, string text, string startDate, List<Event> events)
    //    {
    //        timeline = new TimelineDetails()
    //        {
    //            headline = headline,
    //            type = type,
    //            text = text,
    //            startDate = startDate,
    //            date = TimelineHelper.ConvertEventsToTimelineDetails(events)
    //        };
    //    }

    //    [DataMember]
    //    public TimelineDetails timeline { get; set; }
    //}

    //[DataContract]
    //public class TimelineDetails
    //{
    //    [DataMember]
    //    public string headline { get; set; }
    //    [DataMember]
    //    public string type { get; set; }
    //    [DataMember]
    //    public string text { get; set; }
    //    [DataMember]
    //    public string startDate { get; set; }
    //    [DataMember]
    //    public List<TimelineDetails_Date> date { get; set; }
    //}

    //[DataContract]
    //public class TimelineDetails_Date
    //{
    //    [DataMember]
    //    public string startDate { get; set; }
    //    [DataMember]
    //    public string endDate { get; set; }
    //    [DataMember]
    //    public string headline { get; set; }
    //    [DataMember]
    //    public string text { get; set; }
    //    [DataMember]
    //    public TimelineDetails_Date_Asset asset { get; set; }
    //}

    //[DataContract]
    //public class TimelineDetails_Date_Asset
    //{
    //    [DataMember]
    //    public string media { get; set; }
    //    [DataMember]
    //    public string credit { get; set; }
    //    [DataMember]
    //    public string caption { get; set; }
    //}
}