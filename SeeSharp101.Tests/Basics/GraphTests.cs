using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeSharp101.Basics;





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
            var graph = new Graph(new int[3, 3] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } }, "Master Graph");
            Assert.AreEqual(true, graph.IsConnected);
            Assert.AreEqual(graph.Name, "Master Graph");
            Assert.AreEqual(graph.Description, "One Graph to Rule Them All");
        }
       
        [TestMethod]
        public void Should_Report_StatisticsXml_Is_Not_Empty()
        {
          
        }

        
    }
}
