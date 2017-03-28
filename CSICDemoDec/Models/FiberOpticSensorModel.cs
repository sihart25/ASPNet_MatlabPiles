using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace CSICDemoDec.Models
{
    [XmlRoot("FiberOpticSensorModel")]
    public class FiberOpticSensorModel 
    {
        private long _Id=0;
        private string _Title = "No Title";
        private string _Description = "No Desctiption";
        private string _ImageUrl = "www.";
        private string _Manufacturer = "Made by";
        private string _Model = "Unknown";
        private bool _isPointSrc = false;

        [XmlElement]
        public long Id { get { return _Id; } }
        [XmlElement]
        public string Title { get { return _Title; } }
        [XmlElement]
        public string Description { get { return _Description; } }
        [XmlElement]
        public string ImageUrl { get { return _ImageUrl; } set { _ImageUrl = value; } }
        [XmlElement]
        public string Manufacturer { get { return _Manufacturer; } }
        [XmlElement]
        public string Model { get { return _Model; } }
        [XmlElement]
        public bool isPointSrc { get { return _isPointSrc; } }
       
 
    }
}
