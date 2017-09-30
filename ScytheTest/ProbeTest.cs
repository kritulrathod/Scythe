using Scythe;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScytheTest
{
    [TestClass]
    public class ProbeTest
    {
        [TestMethod]
        public void GivenProbe_WhenInitialize_ThenCreatesDirectoryForProbeFiles()
        {
            //Arrange
            string path = Helper.Path;
            if (Directory.Exists(path))
                Directory.Delete(path, true);

            //Act
            Probe.Initialize(path);

            //Assert
            Assert.IsTrue(Directory.Exists(path));
        }

        [TestMethod]
        public void GivenProbe_WhenMarkerCalled_ThenProbesMarker()
        {
            //Arrange
            string path = Helper.Path;
            Probe.Initialize(path);

            string marker = "First_Marker";

            //Act
            Probe.TouchMarker(marker, new DateTime(1984, 01, 01));

            //Assert
            Assert.IsTrue(Directory.Exists(path), "Marker File Not Found");
            Assert.AreEqual(File.GetLastWriteTime(Probe.FormulateMarkerPath(marker)).Date, new DateTime(1984, 01, 01), "Marker File Not Found");
        }

    }

    public static class Helper
    {
        public static string Path = @"D:\PlayGround\scythe\scythe\ScytheTest\bin\Debug\Probes\";
    }
}
