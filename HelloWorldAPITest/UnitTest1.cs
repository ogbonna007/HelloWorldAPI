using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldAPI.Controllers;
using HelloWorldAPI.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Results;

namespace HelloWorldAPITest
{
    [TestClass]
    public class UnitTest1
    {
        //To test retrieving all languages
        [TestMethod]
        public void GetAllHelloWorld()
        {
            var testHelloWorld = GetAllHelloWorldTest();
            var controller = new HelloWorldController();
            var result = controller.Gethelloworldinvariouslanguages().ToList();
            Assert.AreEqual(testHelloWorld.Count(), result.Count());
        }


        //To test retrieving just 1 language
        [TestMethod]
        public void GetHelloWorld()
        {
            var controller = new HelloWorldController();
            var result = controller.Gethelloworldinvariouslanguage(1) as OkNegotiatedContentResult<helloworldinvariouslanguage>;
            Assert.AreEqual("English".ToUpper(), result.Content.Language.ToUpper());
        }

        private List<helloworldinvariouslanguage> GetAllHelloWorldTest()
        {
            var helloWorld = new List<helloworldinvariouslanguage>()
            {
                new helloworldinvariouslanguage { Interpretation ="Bonjour le monde", Language="French"},
                new helloworldinvariouslanguage { Interpretation ="Salve mundi", Language="Latin"},
                new helloworldinvariouslanguage { Interpretation ="Sawubona Mhlaba", Language="Zulu"},
                new helloworldinvariouslanguage { Interpretation ="Tok fuut", Language="Quan Paan"}
            };

            return helloWorld;
        }

    }
}
