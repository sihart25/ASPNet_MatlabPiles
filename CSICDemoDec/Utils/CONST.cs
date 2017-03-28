using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSICDemoDec.Utils
{
    static public class CONST
    { 
        public static double EPSILON = double.Epsilon*100.0f;// make ours 100 time bigger than double.epsilon 
        private static System.Random rng;
        
        private static short sSCREENX = 1920;   // 1920 x 1080
        private static short sSCREENY = 1080; 
        public static double ANIMATION_BEGIN_TIME = 0.5f;                                                    // used to delay the start of the animation to hide any show-down during loading
        public static System.Drawing.Point OFF_SCREEN_LOCATION = new System.Drawing.Point (5000, 5000);      // used to position the photos off screen before the animation


        public static string DefaultTXTCol= System.Drawing.Color.Black.ToString();
        public static double DefaultTXTSz = 24.0; 

        public static double RAD_TO_DEG = 180.0 / Math.PI;
        public static double DEG_TO_RAD = Math.PI / 180.0;

        //-----------------------------------------------------------------------------
        public enum Detail_DocumentStatus
        { 
            ORIGINAL=0, 
            COPY,
            SUPERCEEDED,
            AWAITPUBLISH,
            PUBLISH,
            UNDERREVIEW,
            DELETE,
            NONE
        }
        //-----------------------------------------------------------------------------
        static public Detail_DocumentStatus Detail_DocumentStatusString(string value)
        {
            Detail_DocumentStatus Doc;
            try
            {
                Doc = (Detail_DocumentStatus)Enum.Parse(typeof(Detail_DocumentStatus),  value);
            }
            catch (Exception ex)
            {
                // The conversion failed.
                System.Diagnostics.Debug.WriteLine("FAILED");
                System.Diagnostics.Debug.WriteLine(ex.Message);

                // Set fallback value.
                Doc = Detail_DocumentStatus.NONE;
            }
            return Doc;
        }

        //-----------------------------------------------------------------------------
        static public string Detail_DocumentStatusString(Detail_DocumentStatus Doc)
        {
            string ret=Doc.ToString();
            return ret;
        }


        //-----------------------------------------------------------------------------
        public static void OUT_memoryStream(string fileOut, ref System.IO.MemoryStream memoryStream)
        {
            if (memoryStream != null)
            {
                using (System.IO.FileStream file = new System.IO.FileStream(fileOut, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    byte[] bytes = new byte[memoryStream.Length];
                    memoryStream.Position = 0;
                    memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                    file.Write(bytes, 0, bytes.Length);
                    memoryStream.Close();
                }
            }

        }
        //-----------------------------------------------------------------------------
        public static void IN_memoryStream(string fileIn, ref  System.IO.MemoryStream memoryStream)
        {
            if (memoryStream != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (System.IO.FileStream file = new System.IO.FileStream(fileIn, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        ms.Position = 0;
                        byte[] bytes = new byte[file.Length];
                        file.Read(bytes, 0, (int)file.Length);
                        ms.Write(bytes, 0, (int)file.Length);
                        ms.Position = 0;
                        memoryStream = ms;
                    }
                }
            }

        }


        //-----------------------------------------------------------------------------
        static CONST()
        {
            DateTime now = new DateTime(); //TODO::SIMON
            int seed = 10; // (int)now.Ticks;
            rng = new System.Random(seed);//  
        }
        

        //-----------------------------------------------------------------------------
        public static bool FloorIndexFor(double searchVal, List<double> limits,ref int floor)
        {
            bool outofrange= false;
            int val = 0;
            if(limits.Count==0)
            {
                outofrange = true;
                return outofrange;    
            }

            // If the lowest value is higher than the search key, then there is no floor value possible.
            if (definitelyGreaterThan(limits[0], searchVal))
            {
                //"No floor value exists. Lowest key value is higher than search key value.");
                outofrange = true;
                return outofrange;            
            }

            // If the search key value is greater than the highest value, then the highest value is the floor value.
            if (definitelyGreaterThan( searchVal, limits[limits.Count-1]))
            {
                floor=(limits.Count - 1);
                 return outofrange;
            }

            // If the search key value exists as an exact match, return its index.
            if (ContainsVal(limits,searchVal,ref val))
            {
                floor= val; 
                return outofrange;
            }


            // There weren't any short-circuit solutions, so do the search.


            floor = FindFloorObjectIndex(searchVal,limits); 
            return outofrange;
        }

        //-----------------------------------------------------------------------------
        public static bool CeilingIndexFor(double searchVal, List<double> limits, ref int ceil)
        {
            bool outofrange = false;
            int val = 0;
            if (limits.Count == 0)
            {
                outofrange = true;
                return outofrange;
            }

            // If the highest value is lower than the search key, then there is no ceiling value possible.
            if (definitelyGreaterThan(limits[limits.Count - 1], searchVal))
            {
                // ArgumentOutOfRangeException("No ceiling value exists. Highest key value is lower than search key value.");
                outofrange = true;
                return outofrange;
            }

            // If the search key value exists as an exact match, return it.
            if (ContainsVal(limits,searchVal,ref val))
            {
                ceil= val; 
                return outofrange;
            }

            // If the search key value is lower than the lowest value, then the lowest value is the ceiling value.
            if (definitelyLessThan(searchVal,limits[0]))
            {
                ceil = 0;
                return outofrange;
            }

            // There weren't any short-circuit solutions, so do the search.
            ceil=(FindFloorObjectIndex(searchVal,limits) + 1);
            return  outofrange;
        }

        //-----------------------------------------------------------------------------
        public static bool ContainsVal(List<double> limits, double searchVal, ref int index)
        {
            for (int i = 0; i < limits.Count;i++)
            {
                if (approximatelyEqual(searchVal,limits[i]))
                {
                    index = i;
                    return true;
                }
                 
            }

            index = -1;
            return false;

        }

        //-----------------------------------------------------------------------------
        private static  int FindFloorObjectIndex(double searchVal, List<double> limits)
        {
            int lowIndex = 0;
            int highIndex = limits.Count;
            int midIndex = lowIndex + ((highIndex - lowIndex) / 2);

            bool continueSearching = true;

            while (continueSearching)
            {
                midIndex = lowIndex + ((highIndex - lowIndex) / 2);

                if ((midIndex == lowIndex) || (midIndex == highIndex))
                {
                    continueSearching = false;
                }
                else if (definitelyGreaterThan(searchVal,limits[midIndex] ))
                {
                    lowIndex = midIndex;
                }
                else
                {
                    highIndex = midIndex;
                }
            }

            return midIndex;
        }

        //-----------------------------------------------------------------------------
        public static double CLAMP(double num, double min, double max)
        {
            double result = num;

            if (definitelyLessThan(num, min))
            {
              //  Console.WriteLine("{0} is less than {1}.", a.ToString(), obj1.ToString());
                result = min;
            }

            if (definitelyGreaterThan(num,max))
            {
               // Console.WriteLine("{0} is greater than {1}.", a.ToString(), obj1.ToString());
                result = max;
            }

            return result;
        }

        //-----------------------------------------------------------------------------
        public static int MAX(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
                if (b > a)
                {
                    return b;
                }

            if (a == b)
            {
                return a;
            }
            return a;
        }

        //-----------------------------------------------------------------------------
        public static int MIN(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else
                if (b < a)
                {
                    return b;
                }

            if (a == b)
            {
                return a;
            }
            return a;
        } 

        //-----------------------------------------------------------------------------
        static public void MinMax(double val, ref double min, ref double max)
        {
              
              if (definitelyGreaterThan(val, max))
              {
                  max = val;
              }
              if (definitelyLessThan(val, min))
              {
                  min = val;
              }
             
        }

        //-----------------------------------------------------------------------------
        public static double MAX(double a, double b)
        {
            if (definitelyGreaterThan(a , b))
            {
                return a;
            }
            else
                if (definitelyGreaterThan(b , a))
                {
                    return b;
                }

            if (approximatelyEqual(a, b))
            {
                return a;
            }
            return a;
        }

        //-----------------------------------------------------------------------------
        public static double MIN(double a, double b)
        {
            if (definitelyLessThan(a , b))
             {
                 return a;
             }
             else
                 if (definitelyLessThan(b,a))
                 {
                     return b;
                 }

            if (approximatelyEqual(a, b))
             {
                 return a;
             }
             return a;
        }
        //-----------------------------------------------------------------------------
        public static double RANDOM(double min, double max)
        {
            return min + (rng.NextDouble() * (max - min));
        }

        //-----------------------------------------------------------------------------
        public static int RANDOM(int min, int max)
        {
            return min + (rng.Next() * (max - min));
        }


        //----------------------------------------------------------------------------- 
        public static int ROUND(double min)
        {
            return (int)min;// Math.Round(min);
        }
        
        //----------------------------------------------------------------------------- 
        public static bool IS_NUM(double d)
        {
            bool result= true;
            if ((double.IsNaN(d)) || (double.IsPositiveInfinity(d)) || (double.IsNegativeInfinity(d)))
            {
                result = false;
            }   
            return result;
        }
 
        //-----------------------------------------------------------------------------
        public static bool WITHIN(double a, double min,double max)
        {
            if(definitelyGreaterThan(a,min)&&definitelyLessThan(a, max))
            {
                return true;
            }
            if (approximatelyEqual(a,min))
            {
                return true;
            }
            if (approximatelyEqual(a, max))
            {
                return true;
            }

            return false;
        }

        //-----------------------------------------------------------------------------
        public static bool approximatelyEqual(double a, double b)
        {
            return Math.Abs(a - b) <= ((Math.Abs(a) < Math.Abs(b) ? Math.Abs(b) : Math.Abs(a)) *  CSICDemoDec.Utils.CONST.EPSILON);
        }

        //-----------------------------------------------------------------------------
        public static bool essentiallyEqual(double a, double b)
        {
            return Math.Abs(a - b) <= ((Math.Abs(a) > Math.Abs(b) ? Math.Abs(b) : Math.Abs(a)) *  CSICDemoDec.Utils.CONST.EPSILON);
        }

        //-----------------------------------------------------------------------------
        public static bool definitelyGreaterThan(double a, double b)
        {
            // do we need to test for NAN?
            // cant be greater than infinity
            if (double.IsPositiveInfinity(b))
                return false;
            //if b == -INF and a!= -INF
            if (double.IsNegativeInfinity(b) && !(double.IsNegativeInfinity(a))) 
                return true;

            return (a - b) > ((Math.Abs(a) < Math.Abs(b) ? Math.Abs(b) : Math.Abs(a)) *  CSICDemoDec.Utils.CONST.EPSILON);
        }

        //-----------------------------------------------------------------------------
        public static bool definitelyLessThan(double a, double b)
        {

            // cant be definitely less than negative infinity
            if (double.IsNegativeInfinity(b))
                return false;
            // if b == INF and a != INF 
            if (double.IsPositiveInfinity(b) && !(double.IsPositiveInfinity(a)))
                return true;

            return (b - a) > ((Math.Abs(a) < Math.Abs(b) ? Math.Abs(b) : Math.Abs(a)) * CSICDemoDec.Utils.CONST.EPSILON);
        }

        //-----------------------------------------------------------------------------
        // SWAP Swap 2 variables  
        public static void SWAP(ref int a, ref int b)
        {
            int c;
            c = a;
            a = b;
            b = c;
        }

        //-----------------------------------------------------------------------------
        public static void SWAP(ref short a, ref short b)
        {
            short c;
            c = a;
            a = b;
            b = c;
        }

        //-----------------------------------------------------------------------------
        public static void SWAP(ref float a, ref float b)
        {
            float c;
            c = a;
            a = b;
            b = c;
        }

        //-----------------------------------------------------------------------------
        public static void SWAP(ref double a, ref double b)
        {
            double c;
            c = a;
            a = b;
            b = c;
        }
        //-----------------------------------------------------------------------------
        public static short SCREENX
        {
            get
            {
                return sSCREENX;
            }
        }

        //-----------------------------------------------------------------------------
        public static short SCREENY
        {
            get
            {
                return sSCREENY;
            }
        }
          
     
    }//CONST
}