using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    class MyGit
    { 
        private static string _mode;
        private static bool _needLoging; 
        public static DirectoryInfo MainFolder = new DirectoryInfo(@"E:\MainFolder");
        private static Logs MyLogs = new Logs(MainFolder);
        static void Main(string[] args)
        {
            SetMode();
            if (_mode == "1")
            {
                if(MyLogs.WriteLogs()) Console.WriteLine("File Logging Completed!");
                Console.ReadLine();
            }
            else if(_mode == "2") // observation mode
            {
                using (FileSystemWatcher FileSW = new FileSystemWatcher())
                {
                    FileSW.Path = @"E:\MainFolder";
                    FileSW.Filter = "*.txt";
                    FileSW.Changed += Edited_Files;
                    FileSW.Created += Edited_Files;
                    FileSW.Deleted += Edited_Files;
                    FileSW.Renamed += Edited_Files;
                    FileSW.EnableRaisingEvents = true;
                    Console.WriteLine("File logging has begun. After closing the program, if the files have been changed, a log will be recorded");
                    Console.WriteLine("Press 'q' to stop file tracking.");
                    while (Console.Read() != 'q') ;
                }
                if (_needLoging) MyLogs.WriteLogs();
            }
            else if(_mode == "3") // change rollback mode
            {
                Logs.GoToSelectLog();
                Console.ReadLine();
            }    
        }
        private static void Edited_Files(object sender, FileSystemEventArgs e)
        {
            _needLoging = true;
        }
        private static void SetMode()
        {
            Console.WriteLine("Please select a mode");
            {
                do
                {
                    Console.WriteLine("1 - Logging all current files. 2 - observation mode. 3 - change rollback mode");
                    _mode = Console.ReadLine();
                    if (_mode != "1" && _mode != "2" && _mode != "3") Console.WriteLine("The input is incorrect");
                } while (_mode != "1" && _mode != "2" && _mode != "3");
            }
        }
    }
    class Logs
    {
        private static DirectoryInfo LogsFolder = new DirectoryInfo(@"E:\Logs");
        private Dictionary<string, string> _logFiles; //Key - File path, Value - File value
        private DirectoryInfo _loggedFolder;
        public Logs(DirectoryInfo MainDirectory)
        {
            _logFiles = new Dictionary<string, string>();
            _loggedFolder = MainDirectory;
        }
        public bool WriteLogs()
        {
            var AllFiles = _loggedFolder.GetFiles();
            foreach (var File in AllFiles)
            {
                _logFiles.Add(File.FullName, File.OpenText().ReadToEnd());
            }
            foreach (var Dir in _loggedFolder.GetDirectories())
            {
                WriteLogs(Dir);
            }
            var NewLogs = LogsFolder.CreateSubdirectory(DateTime.Now.ToString().Replace(':', '-'));
            int i = 0;
            foreach (var element in _logFiles)
            {

                string FileName = NewLogs.FullName + @"\" + element.Key.Replace(":", "#;#").Replace(@"\", "#slash#");
                using (FileStream fstream = new FileStream(FileName, FileMode.OpenOrCreate))
                {
                    var writer = new StreamWriter(fstream);
                    writer.Write(element.Value);
                    writer.Close();
                }
                i++;
            }
            return true;
        }
        public bool WriteLogs(DirectoryInfo LoggetFolder)
        {
            var AllFiles = LoggetFolder.GetFiles();
            foreach (var File in AllFiles)
            {
                _logFiles.Add(File.FullName, File.OpenText().ReadToEnd());
            }
            foreach (var Dir in LoggetFolder.GetDirectories())
            {
                WriteLogs(Dir);
            }
            var NewLogs = LogsFolder.CreateSubdirectory(DateTime.Now.ToString().Replace(':', '-'));
            int i = 0;
            foreach (var element in _logFiles)
            {

                string FileName = NewLogs.FullName + @"\" + element.Key.Replace(":", "#;#").Replace(@"\", "#slash#");
                using (FileStream fstream = new FileStream(FileName, FileMode.OpenOrCreate))
                {
                    var writer = new StreamWriter(fstream);
                    writer.Write(element.Value);
                    writer.Close();
                }
                i++;
            }
            return true;
        }
        public static void GoToSelectLog()
        {
            if (!LogsFolder.Exists || LogsFolder.GetDirectories().Length == 0)
            {
                Console.WriteLine("Logs do not exist");
                return;
            }
            var LogsFolderByDate = LogsFolder.GetDirectories();
            Console.WriteLine("List of existing log dates");
            int Number = 0;
            Dictionary<int, string> LogEntries = new Dictionary<int, string>();
            foreach (var Folder in LogsFolderByDate)
            {
                Number++;
                Console.WriteLine(Number + " - " + Folder.Name);
                LogEntries.Add(Number, Folder.FullName); 
            }
            Console.WriteLine("Please select the log entry number to which you want to go!");
            int SelectNum = 0;
            do
            {
                SelectNum = Create_positive_Int("Enter a value from 1 to " + Number);
            } while (SelectNum < 1 || SelectNum > Number);
            string path = "";
            LogEntries.TryGetValue(SelectNum, out path);
            if (GoToLogByPatch(path))
            {
                Console.WriteLine("Rollback to the selected version completed successfully");
            }
        }
        private static bool GoToLogByPatch(string path)
        {
            var LogsFolder = new DirectoryInfo(path);
            
            foreach (var item in LogsFolder.GetFiles())
            {  
                string filepath = item.Name.Replace("#slash#", @"\").Replace("#;#", ":");
                string pathFolder = filepath.Substring(0, filepath.LastIndexOf('\\'));
                var Folder = new DirectoryInfo(pathFolder);
                if (!Folder.Exists) Folder.Create(); 
                using (FileStream fstream = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    var writer = new StreamWriter(fstream);
                    writer.Write(item.OpenText().ReadToEnd());
                    writer.Close();
                }
            }
            return true;
        }
        private static int Create_positive_Int(string Message)
        {
            int N = 0;
            do
            {
                try
                {
                    Console.WriteLine(Message);
                    N = Convert.ToInt32(Console.ReadLine());
                    if (N < 1) Console.WriteLine("The number must be greater than zero");
                }
                catch (FormatException)
                {
                }
            } while (N < 1);
            return N;
        }
    }
}
