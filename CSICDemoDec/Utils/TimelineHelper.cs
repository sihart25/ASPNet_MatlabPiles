using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSICDemoDec.Models;

namespace CSICDemoDec.Utils
{  
        public static class TimelineHelper
        {
            private const string DATEFORMAT = "yyyy,MM,dd";

            //public static TimelineDetails_Date ConvertEventsToTimelineDetails(BigData.DataContracts.Objects.BigData.Event e)
            //{
            //    TimelineDetails_Date output = new TimelineDetails_Date()
            //    {
            //        headline = e.Headline,
            //        text = e.Text,
            //        endDate = e.EndDate.ToString(DATEFORMAT),
            //        startDate = e.StartDate.ToString(DATEFORMAT),
            //    };

            //    if (e.Media == null)
            //        return output;

            //    output.asset = new TimelineDetails_Date_Asset()
            //    {
            //        media = e.Media.URL ?? string.Empty,
            //        caption = e.Media.Caption ?? string.Empty,
            //        credit = e.Media.Credit ?? string.Empty
            //    };

            //    return output;
            //}

            //public static List<TimelineDetails_Date> ConvertEventsToTimelineDetails(List<BigData.DataContracts.Objects.BigData.Event> es)
            //{
            //    List<TimelineDetails_Date> output = new List<TimelineDetails_Date>();

            //    output = es.Select<BigData.DataContracts.Objects.BigData.Event, TimelineDetails_Date>(
            //            e => ConvertEventsToTimelineDetails(e)
            //        ).ToList<TimelineDetails_Date>();

            //    return output;
            //}
        } 
}