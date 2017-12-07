using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using CapgVSACApp;
namespace CapgVSACAppUITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        public int VarA;
        public int VarB;
        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

            VarB = VarA = 2;

        }

        [Test]
        public void AppLaunches()
        {
            //app.Screenshot("First screen.");

            //app.Screenshot("MainPage");

            int result = (VarA + VarB);


            int testresult = VarA + VarB;

            Assert.AreEqual(result, testresult);

        }
    }
}

