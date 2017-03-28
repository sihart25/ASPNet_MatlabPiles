using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSICDemoDec.App_Start
{
    static public class TestConfig
    {
        static public CSICDemoDec.Models.ProjectUser TEST_PROJECTUSER = new Models.ProjectUser("Simon", 0, DateTime.Now, DateTime.Now);
        static public Dictionary<string, CSICDemoDec.Models.Project> TEST_PROJECTLIST = new Dictionary<string , CSICDemoDec.Models.Project>();
        public static void RegisterData(String testConfigXMLFile)
        {
            TEST_PROJECTLIST.Add("-1", new CSICDemoDec.Models.Project(TEST_PROJECTUSER, "TESTREF_V1"));

            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(HttpRuntime.BinDirectory + "\\Content\\Projects");
            Node dir = new Node();
            dir.Name = root + "\\NewProjV1";
            //Node.WalkDirectoryTree(root, dir);
            //dir.PrintPretty("\t", true);
            //System.Diagnostics.Debug.WriteLine("End- Part1");
            //System.Diagnostics.Debug.Flush();
            //TestMethod1();
            //System.Diagnostics.Debug.WriteLine("End-Part2");
            //System.Diagnostics.Debug.Flush(); 


            //     CSICDemoDec.Models.Testing.DataSheetDocModelTester.MainTest(HttpRuntime.BinDirectory + "/Content/Test/DataSheetDocModel.JSON");
        }
 
    }// Class test Config




    class Node
    {

        public string Name;
        public decimal Time=0;
        public List<Node> Children = new List<Node>();

        public void PrintPretty(string indent, bool last)
        {
            if (last)
            {
                System.Diagnostics.Debug.WriteLine(indent + "\\-");
                indent += "\t";
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(indent + "|-");
                indent += "| ";
            }
            System.Diagnostics.Debug.WriteLine(indent + Name);

            for (int i = 0; i < Children.Count; i++)
                Children[i].PrintPretty(indent, i == Children.Count - 1);
        }//End PrintPretty


        static public void WalkDirectoryTree(System.IO.DirectoryInfo root, Node n)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater 
            // than the application provides. 
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse. 
                // You may decide to do something different here. For example, you 
                // can try to elevate your privileges and access the file again.
                //log.Add(e.Message);
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we 
                    // want to open, delete or modify the file, then 
                    // a try-catch block is required here to handle the case 
                    // where the file has been deleted since the call to TraverseTree().
                    System.Diagnostics.Debug.WriteLine(fi.FullName);
                    Node file = new Node();
                    file.Name = fi.Name;
                    n.Children.Add(file);
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    Node subdir = new Node();
                    subdir.Name = dirInfo.Name;
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo, subdir);
                    n.Children.Add(subdir);
                }
            }
        }// WalkDirectoryTree
    }// end of class node



}// CSIC_DASHV1.App_Start
 