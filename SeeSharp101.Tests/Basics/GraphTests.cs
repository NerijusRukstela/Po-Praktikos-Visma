using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeSharp101.Basics;
using System.Text;
using System.Xml;

namespace SeeSharp101.Tests.Basics
{
    [TestClass]
    public class GraphTests
    {
        

        [TestMethod]
        public void Should_Return_Correct_Identity()
        {
            var graph = new Graph("Master Graph");
            Assert.AreEqual(graph.Name, "Master Graph");
            Assert.AreEqual(graph.Description, "One Graph to Rule Them All");
            
        }
        [TestMethod]
      //  [ExpectedException(typeof(ArgumentException),
      //  "A userId of null was inappropriately allowed.")]
        public void Should_Throw_Argument_Exception_For_Invalid_Adjacency_Matrix()
        {
            //Arrange
            //Act
            var graph = new Graph(new int[3, 3] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } });
            //Assert
            Assert.AreEqual(true, graph.IsConnected);
        }
        
        [TestMethod]
        public void Should_Report_Graph_Is_Connected()
        {
        }
        [TestMethod]
        public void Should_Report_Graph_Is_Not_Connected()
        {
        }
        
       
        [TestMethod]
        public void Should_Report_Statistics_Is_Not_Empty()
        {
            var graph = new Graph( "Master Graph", "One Graph to Rule Them All", new int[3, 3] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } } );
            Assert.AreEqual(true, graph.IsConnected);
            Assert.AreEqual(graph.Name, "Master Graph");
            Assert.AreEqual(graph.Description, "One Graph to Rule Them All");
        }
      
        [TestMethod]
        public void Should_Report_Is_Correct_GetStatistics_Method()
        {
            Graph graph = new Graph("Master Graph", "One Graph to Rule Them All", new int[3, 3] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } });
            
            StringBuilder myStringBuilder = new StringBuilder();
            myStringBuilder.Append(String.Format("{0,6} {1,15}\n\n", "Name", "Master Graph"));
            myStringBuilder.Append(String.Format("{0,6} {1,15:N0}\n", "Description", "One Graph to Rule Them All"));
            myStringBuilder.Append(String.Format("{0,6} {1,15:N0}\n", "IsConnected", true));
            string newString = Convert.ToString(myStringBuilder);


            StringAssert.Contains(newString, GraphExtensions.GetStatistics(graph));
        }
        [TestMethod]
        public void Should_Report_Is_Reverse_Name()
        {
            //Arrange
            Graph name = new Graph("teliukas");
            //Act 
            string result = StringExtensions.Reverse(name);
            //Assert
            StringAssert.Contains("sakuilet", result);
            
        }
        [TestMethod]
        public void Should_Report()
        {
            //Arrange
            Graph graph = new Graph("Master Graph", "One Graph to Rule Them All", new int[3, 3] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } });

            //Act
            string xmlConvertToString = GraphExtensions.GetXMLAsString(GraphExtensions.GetStatisticsXml(graph));
            string expect = "<?xml version=\"1.0\"?><graph connected=\"true\"><name>Master Graph</name><description>One Graph to Rule Them All</description></graph>";


            //Assert
            StringAssert.Contains(expect, xmlConvertToString);
            
        }

    }
}
