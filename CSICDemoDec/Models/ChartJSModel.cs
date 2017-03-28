using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CSICDemoDec.Models
{

    public class ChartItem
    {
        public string label {get;set;}

        public string fillColor {get;set;}

        public string strokeColor {get;set;}

        public string pointColor {get;set;}

        public string pointStrokeColor {get;set;}
        public string pointHighlightFill {get;set;}
        public string pointHighlightStroke {get;set;}
    
        public double [] data{get;set;} 
        public string title {get;set;}
    }
    public class ChartJSModel
    {
        static Random Rnd = new Random(10);  
      static public double randomScalingFactor () { return Math.Round(Rnd.NextDouble() * 100) ;}

     static public string ConvertToJson(string data1Label,string title1,List<double> data1, string data2Label,string title2,List<double> data2)
     {
         List<ChartItem> chartItems = new List<ChartItem>();
         // add as many item as you wish to this list
        chartItems.Add(new ChartItem(){ 
                    label= "My First dataset",
                    fillColor = "rgba(220,220,220,0.2)",
                    strokeColor = "rgba(220,220,220,1)",
                    pointColor = "rgba(220,220,220,1)",
                    pointStrokeColor= "#fff",
                    pointHighlightFill= "#fff",
                    pointHighlightStroke= "rgba(220,220,220,1)",
                    data= data1.ToArray(),
                    title =title1 ,
        });
  
        string result = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(chartItems);
        return result;

     }


        //var lineChartData = {
        //    labels: ["January", "February", "March", "April", "May", "June", "July"],
        //    datasets: [
        //        {
        //            label: "My First dataset",
        //            fillColor: "rgba(220,220,220,0.2)",
        //            strokeColor: "rgba(220,220,220,1)",
        //            pointColor: "rgba(220,220,220,1)",
        //            pointStrokeColor: "#fff",
        //            pointHighlightFill: "#fff",
        //            pointHighlightStroke: "rgba(220,220,220,1)",
        //            data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()],
        //            title : 'Readings'
        //        },
        //        {
        //            label: "My Second dataset",
        //            fillColor: "rgba(151,187,205,0.2)",
        //            strokeColor: "rgba(151,187,205,1)",
        //            pointColor: "rgba(151,187,205,1)",
        //            pointStrokeColor: "#fff",
        //            pointHighlightFill: "#fff",
        //            pointHighlightStroke: "rgba(151,187,205,1)",
        //            data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()],
        //            title : 'BaseLine'
        //       }
        //    ]
        //};  
    }
}