using Scythe;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScytheTest
{
    [TestClass]
    public class ScytheTest
    {
        [TestMethod]
        public void GivenScythe_WhenReadConfig_ThenReturnPath()
        {
            //Arrange
            string path = Helper.Path;

            var scythe = new Probe(path);
            //Act
            var m = Directory.Exists(path);

            //Assert
            Assert.IsTrue(Directory.Exists(path));
        }

        [TestMethod]
        public void GivenScythe_WhenMarkerCalled_ThenProbesMarker()
        {
            //Arrange
            string path = Helper.Path;
            var scythe = new Probe(path);
            string marker = "First_Marker";

            //Act
            Probe.SetMarkTime(marker, new DateTime(1984, 01, 01));

            //Assert
            Assert.IsTrue(Directory.Exists(path));
        }

    }

    public static class Helper
    {
        public static string Path = @"D:\PlayGround\scythe\scythe\ScytheTest\bin\Debug\Probes\";
    }
}
