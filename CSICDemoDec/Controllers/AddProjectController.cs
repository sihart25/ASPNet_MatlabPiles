using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.IO; 

namespace CSICDemoDec.Controllers
{
    public class AddProjectController : Controller
    {

       
        //
        // GET: /Project/
        public ActionResult Index()
        {
            // create aproject user for this new project;
            CSICDemoDec.Models.ProjectUser u = new Models.ProjectUser(User.Identity.Name, 0, new DateTime(1980,12,25), DateTime.Now);
            ViewBag.Message = " Add a new Project to the system.";
            CSICDemoDec.Models.Project p = new Models.Project(u,u.ToString()+"testProj");
            return View(p);
        }

        public ActionResult Create(CSICDemoDec.Models.Project p)
        { 
            return View();
        }

        #region staticFuntionDirFromXML

        public static XElement GetDirectoryXmlTopLvl(DirectoryInfo dir, string projectname)
        {

            var info = new XElement("dir", new XAttribute("name", dir.Name));
            XElement XElement1 = new XElement("dir", new XAttribute("name", dir.Name), new XAttribute("AccessTime", dir.LastAccessTime), new XAttribute("WriteTime", dir.LastWriteTime));
            foreach (var file in dir.GetFiles())
            {
                XElement xmlelements = new XElement("file", new XAttribute("name", file.Name), new XAttribute("CreationTime", file.CreationTime), new XAttribute("AccessTime", dir.LastAccessTime), new XAttribute("WriteTime", file.LastWriteTime));
                info.Add(xmlelements);
                XElement1.Add(xmlelements);

            }
            XElement xmlele = new XElement("file", new XAttribute("name", (dir.ToString() + "\\" + projectname + "_Dir_Structure.xml")), new XAttribute("AccessTime", dir.LastAccessTime), new XAttribute("WriteTime", dir.LastWriteTime));
            XElement1.Add(xmlele);

            foreach (var subDir in dir.GetDirectories())
            {
                info.Add(GetDirectoryXmlSublvl(subDir));
            }
            return info;
        }
        public static XElement GetDirectoryXmlSublvl(DirectoryInfo dir)
        {

            var info = new XElement("dir", new XAttribute("name", dir.Name));
            XElement XElement1 = new XElement("dir", new XAttribute("name", dir.Name), new XAttribute("AccessTime", dir.LastAccessTime), new XAttribute("WriteTime", dir.LastWriteTime));
            foreach (var file in dir.GetFiles())
            {
                XElement xmlelements = new XElement("file", new XAttribute("name", file.Name), new XAttribute("CreationTime", file.CreationTime), new XAttribute("AccessTime", dir.LastAccessTime), new XAttribute("WriteTime", file.LastWriteTime));
                info.Add(xmlelements);
                XElement1.Add(xmlelements);

            }


            // create a xml file in this folder and add its name to the list
            XElement xmlele = new XElement("file", new XAttribute("name", dir.ToString() + "_files.xml"), new XAttribute("AccessTime", dir.LastAccessTime), new XAttribute("WriteTime", dir.LastWriteTime));
            XElement1.Add(xmlele);
            write_xml(new XDocument(XElement1), Path.Combine(dir.FullName.ToString(), dir.ToString() + "_files.xml"));


            foreach (var subDir in dir.GetDirectories())
            {
                info.Add(GetDirectoryXmlSublvl(subDir));
            }
            return info;
        }

        static private void CreateDirectories(string directory, System.Xml.XmlNodeList nodes)
        {
            foreach (System.Xml.XmlNode node in nodes)
            {
                string directoryName = node.Attributes["name"].Value;
                string fullPath = directory + directoryName + "\\";
                Directory.CreateDirectory(fullPath);
                if (node.HasChildNodes)
                {
                    CreateDirectories(fullPath, node.ChildNodes);
                }

            }
        }

        static private void ReadProjectCreateXML(string root, string project, bool write_topdir)
        {
            var dir = new DirectoryInfo(root + "\\" + project);
            var doc = new XDocument(GetDirectoryXmlTopLvl(dir, project));

            Console.WriteLine(doc.ToString());

            write_xml(doc, Path.Combine(root, project, project + "_Dir_Structure.xml"));

            // save a copy to the  projects folder
            if (write_topdir)
            {
                write_xml(doc, Path.Combine(root, "Dir_Structure.xml"));
            }

        }

        static void CreateFolderFromXML(string rootPath, string projectName)
        {
            System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(rootPath + "\\Dir_Structure.xml");
            System.Xml.XmlDocument doc1 = new System.Xml.XmlDocument();
            doc1.Load(xmlReader);
            System.Xml.XmlNode node = doc1.SelectNodes("dir").Item(0);
            Console.WriteLine("dir structure to create.......");
            Consoleprintxml(node);
            string NewPath = rootPath + "\\" + projectName + "\\";
            Directory.CreateDirectory(NewPath);
            CreateDirectories(NewPath, node.ChildNodes);
            xmlReader.Close();
            xmlReader.Dispose();
        }
        static public void write_xml(System.Xml.Linq.XDocument doc, string destinationFile)
        {
            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";  // Indent \t Spaces

            using (System.Xml.XmlWriter writer = System.Xml.XmlTextWriter.Create(destinationFile, settings))
            {
                doc.Save(writer);
                writer.Close();
                writer.Dispose();
            }
        }


        static private void Consoleprintxml(System.Xml.XmlNode node)
        {
            if (node.HasChildNodes)
            {
                //Console.WriteLine("node:" + node.Attributes["name"].Value + " has children(" + node.ChildNodes.Count + ")");
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    Console.WriteLine(node.ChildNodes[i].Attributes["name"].Value);
                    Consoleprintxml(node.ChildNodes[i]);
                }
            }
            else
            {
                // Console.WriteLine("node has no children:" + node.Attributes["name"].Value);
            }
        }
        #endregion
    }
}