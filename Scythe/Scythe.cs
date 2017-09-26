using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scythe
{
    public class Probe
    {
        private static String path;

        /// <summary>
        /// </summary>
        /// <param name="scythePath">Pass valid path where the probe files will be created</param>
        public Probe(String scythePath)
        {
            path = scythePath;
        }

        public static void InitializeScythe()
        {
            var path = ConfigurationManager.AppSettings["path"].ToString();
            if (path.EndsWith("\\"))
            {
                path = path.Remove(path.Length - 1);
            }
            new Probe(path);
        }


        public static void ScytheProbe(String marker)
        {
            try
            {
                SetMarkTime(marker, System.DateTime.Now);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SetMarkTime(string marker, DateTime lastWriteTime)
        {
            File.SetLastWriteTime(getMarkerPath(marker), lastWriteTime);
        }


        #region private
        public static string getMarkerPath(string marker)
        {
            try
            {
                var markerPath = string.Format("{0}\\{1}.scythe_probe", path, marker);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (!File.Exists(markerPath))
                {
                    FileStream streame = File.Create(markerPath);
                    streame.Close();
                }
                return markerPath;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
