using System;
using TagLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System.Collections.Generic;
using System.Diagnostics;

namespace DllTests
{
    [TestClass]
    public class TagApiTests
    {
        private MockFactory _mockFactory;
        private Mock<IApiRequest> _mockIApiRequest;

        [TestInitialize]
        public void Setup()
        {
            _mockFactory = new MockFactory();
            _mockIApiRequest = _mockFactory.CreateMock<IApiRequest>();
        }

        [TestCleanup]
        public void TearDown()
        {
            _mockFactory.VerifyAllExpectationsHaveBeenMet();
            _mockFactory.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string  lonX = "5.728221";
            string latY = "45.185692";
            string distance = "15550";
            string url = UrlBuilder.StopUrlBuilder(lonX, latY, distance);

            DataCallToDll _target = new DataCallToDll(_mockIApiRequest.MockObject);
            RequestStringToDictionnary _detailTarget = new RequestStringToDictionnary(_mockIApiRequest.MockObject);
            _mockIApiRequest.Expects.One.Method(_ => _.DoRequest(url)).WithAnyArguments().WillReturn(Resource1.JSon);

            //_mockIApiRequest.Expects.One.MethodWith(_ => _.DoRequest(url)).WillReturn(Resource1.JSon);
            string detailUrlBonne = UrlBuilder.LinesUrlBuilder("SEM:16,SEM:C4,SEM:13");
            _mockIApiRequest.Expects.One.MethodWith(_ => _.DoRequest(detailUrlBonne)).WillReturn(Resource1.DetailBonne);
            _mockIApiRequest.Expects.One.Method(_ => _.DoRequest(null)).WithAnyArguments().WillReturn(Resource1.DetailChavant);
            _mockIApiRequest.Expects.One.Method(_ => _.DoRequest(null)).WithAnyArguments().WillReturn(Resource1.DetailMartin);
            Dictionary<string,List<TransportLines>> result = _target.CallToDll(lonX, latY, distance);

            Assert.IsTrue(result.Count == 3);

            Assert.AreEqual("16", result["GRENOBLE, CASERNE DE BONNE"]);
            string wow = result["GRENOBLE, CASERNE DE BONNE"][0].longName;
            //Assert.AreEqual("C4", result["GRENOBLE, CASERNE DE BONNE"][1].shortName);
            //Assert.AreEqual("13", result["GRENOBLE, CASERNE DE BONNE"][2].shortName);
           // Assert.AreEqual("", result["GRENOBLE, CASERNE DE BONNE"][0]);
            //Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"].Count == 3);
            //Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"].Contains("SEM:13"));
            //Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"].Contains("SEM:16"));
            //Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"].Contains("SEM:C4"));

            //Assert.IsTrue(result.ContainsKey("GRENOBLE, CHAVANT"));
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Count == 8);
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("SEM:C1"));
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("SEM:C"));
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("SEM:A"));
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("SEM:E"));
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("C38:EXP2"));
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("C38:EXP1"));
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("C38:6200"));
            //Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("C38:6060"));

            // Assert.IsTrue(result.ContainsKey("GRENOBLE, DOCTEUR MARTIN"));
            //Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Count == 7);
            //Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:C1"));
            //Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:57"));
            //Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:C4"));
            //Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:13"));            
            //Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:16"));            
            //Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:12"));            
            //Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("C38:6020"));
        }
    }
}
