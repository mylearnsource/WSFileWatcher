using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WatchDog
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //if (!Directory.Exists(ConfigurationManager.AppSettings["WatchPath"]))
            //{
            //    Directory.CreateDirectory(ConfigurationManager.AppSettings["WatchPath"]);
            //}

            fileSystemWatcher1.Path = ConfigurationManager.AppSettings["WatchPath"];
        }

        protected override void OnStop()
        {
            try
            {
                Create_ServiceStoptextfile();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            //if(!Directory.Exists(ConfigurationManager.AppSettings["DestinationPath"]))
            //{
            //    Directory.CreateDirectory(ConfigurationManager.AppSettings["DestinationPath"]);
            //}

            try
            {
                Thread.Sleep(5000);
                //Then we need to check file is exist or not which is created.  
                if (CheckFileExistance(ConfigurationManager.AppSettings["WatchPath"], e.Name))
                {
                    //Then write code for log detail of file in text file.  
                    CreateTextFile(ConfigurationManager.AppSettings["WatchPath"], e.Name);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            System.IO.File.Copy(e.FullPath, ConfigurationManager.AppSettings["DestinationPath"] + e.Name);
            System.IO.File.Delete(ConfigurationManager.AppSettings["WatchPath"] + e.Name);

        }

        private bool CheckFileExistance(string FullPath, string FileName)
        {
            // Get the subdirectories for the specified directory.'  
            bool IsFileExist = false;
            DirectoryInfo dir = new DirectoryInfo(FullPath);
            if (!dir.Exists)
                IsFileExist = false;
            else
            {
                string FileFullPath = Path.Combine(FullPath, FileName);
                if (File.Exists(FileFullPath))
                    IsFileExist = true;
            }
            return IsFileExist;


        }

        private void CreateTextFile(string FullPath, string FileName)
        {
            StreamWriter SW;
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "txtStatus_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")))
            {
                SW = File.CreateText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "txtStatus_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"));
                SW.Close();
            }
            using (SW = File.AppendText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "txtStatus_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")))
            {
                SW.WriteLine("File Created with Name: " + FileName + " at this location: " + FullPath);
                SW.Close();
            }
        }

        public static void Create_ServiceStoptextfile()
        {
            string Destination = "c:\\temp\\FileWatcherWinService";
            StreamWriter SW;
            if (Directory.Exists(Destination))
            {
                Destination = System.IO.Path.Combine(Destination, "txtServiceStop_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                if (!File.Exists(Destination))
                {
                    SW = File.CreateText(Destination);
                    SW.Close();
                }
            }
            using (SW = File.AppendText(Destination))
            {
                SW.Write("\r\n\n");
                SW.WriteLine("Service Stopped at: " + DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"));
                SW.Close();
            }
        }
    }
}
