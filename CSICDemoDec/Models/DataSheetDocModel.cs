using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using  CSICDemoDec.Utils; 

namespace CSICDemoDec.Models
{


    [DataContract] 
    [KnownType(typeof(CSICDemoDec.Models.DataSheetDocArray))]
    public class DataSheetDocArray : ICollection
    {
        

        #region StaticDefaultValues
        static public string _DATASHEET_ARRAY = "_DATASHEET_ARRAY";
        static public string _DATASHEET_MAIN = "_DATASHEET_MAIN";
        #endregion

        public Project DataSheetDocArrayProjectRef { get; set; }

        [DataMember]
        public string DataSheetDocArrayCollectionName { get; set; }
        [DataMember] 
        private ArrayList DataSheetDocModelArray { get; set; }

        public DataSheetDocArray(string name)
        {

            DataSheetDocModelArray = new ArrayList();
        }
        public DataSheetDocArray(ref Project projref)
        {

            DataSheetDocModelArray = new ArrayList();
            DataSheetDocArrayProjectRef = projref;
        }
        public void Initialize(ref Project projref, string name)
        {
            ///TODO::SIMON INITIALISE
            DataSheetDocArrayProjectRef = projref;
            DataSheetDocArrayCollectionName = _DATASHEET_MAIN+projref.ProjectName;

        }
        public static System.IO.MemoryStream  JSON_Stream(DataSheetDocArray DocArray)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DataSheetDocArray));
            ser.WriteObject(stream1, DocArray);
            stream1.Position = 0;
            return stream1;
        }
        public static string JSON_STRING(DataSheetDocArray DocArray)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DataSheetDocArray));
            ser.WriteObject(stream1, DocArray);
            stream1.Position = 0;
            return stream1.ToString() ;
        }
        public static DataSheetDocArray  FROM_JSON(string json)
        {
            DataSheetDocArray DocArray = null;
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DataSheetDocArray));
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            DataSheetDocArray u = (DataSheetDocArray)js.ReadObject(stream); 
            return DocArray;
        }

        public DataSheetDocModel this[int index]
        {
            get { return (DataSheetDocModel)DataSheetDocModelArray[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            DataSheetDocModelArray.CopyTo(a, index);
        }
        public int Count
        {
            get { return DataSheetDocModelArray.Count; }
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
            return DataSheetDocModelArray.GetEnumerator();
        }

        public void Add(DataSheetDocModel newItem)
        {
            DataSheetDocModelArray.Add(newItem);
        }
    }

    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.DataSheetDocRevsions))]
    public class DataSheetDocRevsions
    {
        public DataSheetDocRevsions( string RevisVersion, string RevisAuthour, List<string> RevisComments, DateTime RevisDate)
        { 
            DataSheetDocRevisVersion  = RevisVersion;
            DataSheetDocRevisAuthour  = RevisAuthour;
            DataSheetDocRevisComments = RevisComments;
            DataSheetDocRevisDate     = RevisDate;
        }

        [DataMember]
        public string DataSheetDocRevisVersion { get; set; }
        [DataMember]
        public string DataSheetDocRevisAuthour { get; set; }
        [DataMember]
        public List<string> DataSheetDocRevisComments { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime DataSheetDocRevisDate { get; set; }

    }
    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.DataSheetDocLinkInternal))]
    public class DataSheetDocLinkInternal
    {
        public DataSheetDocLinkInternal( string LinkInternalID, string LinkInternalAuthour, string LinkInternalVersion, DateTime LinkCreated)
        { 
              DataSheetDocLinkInternalID  =  LinkInternalID;
              DataSheetDocLinkInternalAuthour= LinkInternalAuthour;
              DataSheetDocLinkInternalVersion= LinkInternalVersion;
              DataSheetDocLinkCreated =  LinkCreated; 
        } 

        public DataSheetDocLinkInternal(string JSON)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DataSheetDocLinkInternal));
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(JSON));
            DataSheetDocLinkInternal u = (DataSheetDocLinkInternal)js.ReadObject(stream);

            DataSheetDocLinkInternalID  = u.DataSheetDocLinkInternalID  ;
            DataSheetDocLinkInternalAuthour= u.DataSheetDocLinkInternalAuthour;
            DataSheetDocLinkInternalVersion= u.DataSheetDocLinkInternalVersion;
            DataSheetDocLinkCreated = u.DataSheetDocLinkCreated;

            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkInternalID);
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkInternalAuthour);
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkInternalVersion);
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkCreated.ToShortDateString()); 
        }

        [DataMember]
        public string DataSheetDocLinkInternalID { get; set; }
        [DataMember]
        public string DataSheetDocLinkInternalAuthour { get; set; }
        [DataMember]
        public string DataSheetDocLinkInternalVersion { get; set; }

        [DataMember]
        [DataType(DataType.Date)]
        public DateTime DataSheetDocLinkCreated { get; set; }
      }///DataSheetDocLinkExternal
    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.DataSheetDocLinkExternal))]
    public class DataSheetDocLinkExternal
    {
        public DataSheetDocLinkExternal(string LinkExternalID,string LinkExternalValue, string LinkExternalVersion, string LinkExternalAuthour, List<string> LinkExternalComments, bool LinkExternalLocalCopy, DateTime LinkExternalCreated, DateTime LinkExternalAccessed)
        {
            DataSheetDocLinkExternalID =      LinkExternalID;
            DataSheetDocLinkExternalValue = LinkExternalValue;
            DataSheetDocLinkExternalVersion = LinkExternalVersion;
            DataSheetDocLinkExternalAuthour = LinkExternalAuthour;
            DataSheetDocLinkExternalComments = LinkExternalComments;
            DataSheetDocLinkExternalLocalCopy = LinkExternalLocalCopy;
            DataSheetDocLinkExternalCreated = LinkExternalCreated;
            DataSheetDocLinkExternalAccessed = LinkExternalAccessed;
        }
         
        public DataSheetDocLinkExternal(string JSON)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DataSheetDocLinkExternal));
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(JSON));
            DataSheetDocLinkExternal u = (DataSheetDocLinkExternal)js.ReadObject(stream);

            DataSheetDocLinkExternalID        = u.DataSheetDocLinkExternalID;
            DataSheetDocLinkExternalValue = u.DataSheetDocLinkExternalValue;
            DataSheetDocLinkExternalVersion   = u.DataSheetDocLinkExternalVersion;
            DataSheetDocLinkExternalAuthour   = u.DataSheetDocLinkExternalAuthour;
            DataSheetDocLinkExternalComments  = u.DataSheetDocLinkExternalComments;
            DataSheetDocLinkExternalLocalCopy = u.DataSheetDocLinkExternalLocalCopy;
            DataSheetDocLinkExternalCreated   = u.DataSheetDocLinkExternalCreated;
            DataSheetDocLinkExternalAccessed  = u.DataSheetDocLinkExternalAccessed;
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkExternalID.ToString()      );
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkExternalVersion.ToString() );
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkExternalAuthour.ToString() );
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkExternalComments.ToString() );
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkExternalLocalCopy.ToString());
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkExternalCreated.ToString()  );
            System.Diagnostics.Debug.WriteLine(DataSheetDocLinkExternalAccessed.ToString() );
        }

        [DataMember]
        public string DataSheetDocLinkExternalID { get; set; }
        [DataMember]
        public string DataSheetDocLinkExternalValue { get; set; }

        [DataMember]
        public string DataSheetDocLinkExternalVersion { get; set; }
        [DataMember]
        public string DataSheetDocLinkExternalAuthour { get; set; }
        [DataMember]
        public List<string> DataSheetDocLinkExternalComments { get; set; }
        [DataMember]
        public bool DataSheetDocLinkExternalLocalCopy { get; set; }
        [DataMember]
        public DataSheetDocLinkInternal DataSheetDocLinkExternalLocalLink { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime DataSheetDocLinkExternalCreated { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime DataSheetDocLinkExternalAccessed { get; set; }
      }///DataSheetDocLinkExternal
    [DataContract]
    [KnownType(typeof(CSICDemoDec.Models.DataSheetDocModel))]
    public class DataSheetDocModel
    {
        public static string TYPE = "DATASHEETDOC";
        public string DataSheetDocTypeDocument { get { return TYPE; } }
        
        [DataMember]
        public string DataSheetDocDocumentName { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime DataSheetDocCreateDate { get; set; }
        [DataMember]
        public List<DataSheetDocRevsions> DataSheetDocRevsions { get; set; }
        [DataMember]
        public string DataSheetDocDocumentID { get; set; }
        [DataMember]
        public string DataSheetDocVersion { get; set; }
        [DataMember]
        public string DataSheetDocStatus { get; set; }
        [DataMember]
        public string DataSheetDocPath { get; set; }
        [DataMember]
        public JsonDictionary<string, DataSheetDocLinkInternal> DataSheetDocLinkInternalList { get; set; }
        [DataMember]
        public JsonDictionary<string, DataSheetDocLinkExternal> DataSheetDocLinkExternalList { get; set; }


        public DataSheetDocModel(string name, DateTime DCreateDate, string DocumentID, string Version, string DocStatus, string DocPath, List<Models.DataSheetDocRevsions> Revlist = null, JsonDictionary<string, DataSheetDocLinkInternal> LinkInternalList = null, JsonDictionary<string, DataSheetDocLinkExternal> LinkExternalList = null)
        {
            DataSheetDocDocumentName=name;
            DataSheetDocCreateDate= DCreateDate;
            if(Revlist==null)
            {
                DataSheetDocRevsions= new List<Models.DataSheetDocRevsions>();
            }else{
                 DataSheetDocRevsions=Revlist;
            }
            DataSheetDocDocumentID =DocumentID;
            DataSheetDocVersion= Version;
            DataSheetDocStatus= DocStatus;
            DataSheetDocPath=DocPath;

            if(LinkInternalList==null)
            {
                DataSheetDocLinkInternalList = new JsonDictionary<string, DataSheetDocLinkInternal>();
            }
            else
            {
                DataSheetDocLinkInternalList = LinkInternalList;

            } 
            if(LinkExternalList==null)
            {
                DataSheetDocLinkExternalList = new JsonDictionary<string, DataSheetDocLinkExternal>();

            }
            else
            {
                DataSheetDocLinkExternalList =  LinkExternalList;
            }
        }

        public int PushRevsion(DataSheetDocRevsions r)
        {
            try
            {
                this.DataSheetDocRevsions.Add(r);
            }
            catch (Exception e)
            {
                e.InnerException.ToString();

            }
            return this.DataSheetDocRevsions.Count;
        }


    }
}

namespace CSICDemoDec.Models.Testing
{
    using CSICDemoDec.Models;
    
    using CSICDemoDec.Utils;


    public static class DataSheetDocModelTester
    {
        static Random rnd = new Random(1);
        public static bool MainTest(string fileOut)
        {
    
    
            bool ret= false;
            DataSheetDocArray DocArray= new DataSheetDocArray("PROJFILENAMEDOCSHEET");
            CreateDataSheetDocModels(rnd,ref DocArray);

           MemoryStream ms = DataSheetDocArray.JSON_Stream(DocArray);
           CONST.OUT_memoryStream(fileOut,ref ms);

           return ret; 
        }
        public static void CreateDataSheetDocModels(Random m, ref DataSheetDocArray DocArray)
        {
            int numtocreate= m.Next(3,7);
            for(int i=0; i<numtocreate;i++)
            {
                int VersionRnd = m.Next(0,3);
                //SIMON TODO:: ADD NAMEING CONVENSION
                string  NAME="DataSheet_"+i+"_V"+VersionRnd+".Doc";
                string status=CONST.Detail_DocumentStatusString((CONST.Detail_DocumentStatus)m.Next(0,(int)CONST.Detail_DocumentStatus.NONE));
                //SIMON TODO:: ADD PROJECT CONVENSION
                string URI ="~/Content/Data/Files/";

                DataSheetDocModel DSDocModel = new DataSheetDocModel(NAME, DateTime.Now, System.Guid.NewGuid().ToString(), VersionRnd.ToString(), status, URI, CreateDataSheetDocRevsions(VersionRnd), CreateDataSheetDocLinkInternal((int)m.Next(0, 3)), CreateDataSheetDocLinkExternal((int)m.Next(0, 3),m));
                DocArray.Add(DSDocModel);
            }

        }

         public static  List< DataSheetDocRevsions> CreateDataSheetDocRevsions(int num)
        {
            List<DataSheetDocRevsions> revList = new List<DataSheetDocRevsions>(num);

               List<string> Comments= new List<string>();
             Comments.Add("Details the sensor used");
             Comments.Add("Details the wire used");
             Comments.Add("Details the people enslaved by culthu");
             Comments.Add("Details the analyser used");

            for (int i = 0; i < num;i++)
            {
                DataSheetDocRevsions rev = new DataSheetDocRevsions("V0.1", "Simon", Comments, DateTime.Now);
                revList.Add(rev);
            }
            return revList;
        }

         public static JsonDictionary<string, DataSheetDocLinkInternal> CreateDataSheetDocLinkInternal(int num)
        {
            JsonDictionary<string, DataSheetDocLinkInternal> Intlink = new JsonDictionary<string, DataSheetDocLinkInternal>();
             string Auth="Cedric";
            for(int i=0;i<num;i++)
            {
                string ID =System.Guid.NewGuid().ToString();
                DataSheetDocLinkInternal n = new DataSheetDocLinkInternal(ID,Auth,"V1.0", DateTime.Now);
                Intlink.Add(ID, n);
            }
            return Intlink;
        }

        public static JsonDictionary<string, DataSheetDocLinkExternal> CreateDataSheetDocLinkExternal(int num, Random r)
        {

            string Auth = "Cedric";
            string link ="";
             switch(r.Next(0,3))
             {
                 case 0:
                     link ="http://www.yokogawa.com/an/download/bulletin/Bulletin12J05D02-01E.pdf";
                     break;
                 case 1:
                     link ="http://www.yokogawa.com/an/download/general/GS12J05D04-01E.pdf";
                     break;
                 case 2:
                     link ="http://www.yokogawa.com/an/download/manual/IM12J05D04-01E.pdf";
                     break;
                 case 3:
                     link ="http://www.yokogawa.com/an/download/general/GS12D08E02-01E.pdf";
                     break;
                     
                 default:
                     link ="http://www.yokogawa.com/an/download/bulletin/Bulletin12J05D02-01E.pdf";

                     break;
             }
             List<string> Comments= new List<string>();
             Comments.Add("Details the sensor used");
             Comments.Add("Details the wire used");
             Comments.Add("Details the people enslaved by culthu");
             Comments.Add("Details the analyser used");

             JsonDictionary<string, DataSheetDocLinkExternal> exlink = new JsonDictionary<string, DataSheetDocLinkExternal>();
            for(int i=0;i<num;i++)
            {
                string id = System.Guid.NewGuid().ToString();
                DataSheetDocLinkExternal n = new DataSheetDocLinkExternal(id, link, "V1.0", Auth, Comments,false, DateTime.Now, DateTime.Now);
                exlink.Add(id, n);
            }
            return exlink;
 
        }

    }


}