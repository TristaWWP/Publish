using PublishHomework.Models;
using System;
using System.IO;

namespace PublishHomework.Utilities
{
    public class DefaultInfo
    {
        private static string _configFilePath;

        static DefaultInfo()
        {
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var directory = Path.Combine(appdata, "Seewo", "EasiNote5", "Extensions", "PublishHomework");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            _configFilePath = Path.Combine(directory, "Config.txt");
        }

        public static void WriteDefaultInfo(PublishInfo info)
        {
            TryToExecute(() =>
            {
                using (StreamWriter sw = File.CreateText(_configFilePath))
                {
                    sw.WriteLine(info.ServerAddress);
                    sw.WriteLine(info.Categ.SchoolId);
                    sw.WriteLine(info.Categ.ClassId);
                }
            });
        }

        public static void ReadDefaultInfo(PublishInfo info)
        {
            TryToExecute(() =>
            {
                using (StreamReader sw = File.OpenText(_configFilePath))
                {
                    info.ServerAddress = sw.ReadLine();
                    info.Categ.SchoolId = sw.ReadLine();
                    info.Categ.ClassId = sw.ReadLine();
                }
            });
        }

        private static void TryToExecute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                // log exception
            }
        }
    }
}