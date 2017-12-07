using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
 
namespace CapgVSACAppUITest
{
    [TestFixture(Platform.Android)]
   // [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        
        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

             

        }

        [Test]
        public void AppLaunches()
        {
             app.Screenshot("First screen.");
 

        }

        [Test]
        public void Test_Add()
        {
            //Arrange
            int val1 = 5;
            int val2 = 7;
            int result = val1 + val2;
            app.EnterText("val1", val1.ToString());
            app.EnterText("val2", val2.ToString());

            //Act
            app.Tap("btnAdd");


            //Assert
         var appresult=   app.Query("labelResult").First(x => x.Text == result.ToString());
            Assert.IsTrue(appresult!=null,"Label is not showing right result");
        }
    }
}

