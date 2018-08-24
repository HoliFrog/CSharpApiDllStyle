using System;
using TagLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System.Collections.Generic;

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
            string url = "http://data.metromobilite.fr/api/linesNear/json?x=5.728221&y=45.185692&dist=550&details=true";

            DataCallToDll _target = new DataCallToDll(_mockIApiRequest.MockObject);
            //_mockIApiRequest.Expects.One.Method(_ => _.DoRequest(null)).WithAnyArguments().WillReturn(Resource1.JSon);
            _mockIApiRequest.Expects.One.MethodWith(_ => _.DoRequest(url)).WillReturn(Resource1.JSon);
            Dictionary<string,List<string>> result = _target.CallToDll();
            Assert.IsTrue(result.Count == 3);

            Assert.IsTrue(result.ContainsKey("GRENOBLE, CASERNE DE BONNE"));
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"].Count == 3);
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"].Contains("SEM:13"));
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"].Contains("SEM:16"));
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"].Contains("SEM:C4"));

            Assert.IsTrue(result.ContainsKey("GRENOBLE, CHAVANT"));
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Count == 8);
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("SEM:C1"));
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("SEM:C"));
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("SEM:A"));
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("SEM:E"));
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("C38:EXP2"));
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("C38:EXP1"));
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("C38:6200"));
            Assert.IsTrue(result["GRENOBLE, CHAVANT"].Contains("C38:6060"));

             Assert.IsTrue(result.ContainsKey("GRENOBLE, DOCTEUR MARTIN"));
            Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Count == 7);
            Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:C1"));
            Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:57"));
            Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:C4"));
            Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:13"));            
            Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:16"));            
            Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("SEM:12"));            
            Assert.IsTrue(result["GRENOBLE, DOCTEUR MARTIN"].Contains("C38:6020"));
        }
    }
}
