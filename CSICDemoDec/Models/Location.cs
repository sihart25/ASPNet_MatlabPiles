using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Xml.Serialization; 

namespace CSICDemoDec.Models
{
    public class Location
    {  
          public Location()
          {
               IPAddress ="127.0.0.1";
               CountryName = "UNITED KINGDOM";
               CountryCode ="GB";
               CityName  ="CAMBRIDGE";
               RegionName ="ENGLAND";
               ZipCode ="";
               Latitude  ="51.7333";
               Longitude="-2.36667";
               TimeZone ="+00:00"; 
          }

          public string IPAddress { get; set; }
          public string CountryName { get; set; }
          public string CountryCode { get; set; }
          public string CityName { get; set; }
          public string RegionName { get; set; }
          public string ZipCode { get; set; }
          public string Latitude { get; set; }
          public string Longitude { get; set; }
          public string TimeZone { get; set; } 
    }
}