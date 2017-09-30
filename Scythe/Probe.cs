using System;
using System.Configuration;
using System.IO;

namespace Scythe
{
    public static class Probe
    {
        private static String path;

        public static void Initialize(string logDirectory)
        {
            CreateScytheDirectory(logDirectory);
        }

        public static void Initialize()
        {
            String logDirectory = ConfigurationManager.AppSettings["path"].ToString();
            CreateScytheDirectory(logDirectory);
        }

        private static void CreateScytheDirectory(string logDirectory)
        {
            if (logDirectory.EndsWith("\\", StringComparison.Ordinal))
                path = logDirectory.Remove(logDirectory.Length - 1);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void ScytheProbe(String marker)
        {
            try
            {
                TouchMarker(marker, System.DateTime.Now);
            }
            catch
            {
                throw;
            }
        }

        public static void TouchMarker(string marker, DateTime lastWriteTime)
        {
            File.SetLastWriteTime(FormulateMarkerPath(marker), lastWriteTime);
        }


        #region private
        public static string FormulateMarkerPath(string marker)
        {
            try
            {
                var markerPath = string.Format("{0}\\{1}.scythe_probe", path, marker);


                if (!File.Exists(markerPath))
                {
                    FileStream streame = File.Create(markerPath);
                    streame.Close();
                }
                return markerPath;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
