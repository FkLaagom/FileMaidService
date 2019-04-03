using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MaidService
{
    public class FileMaid
    {
        private readonly Timer _timer;
        private static string _targetPath;
        private static HashSet<Folder> _folders;
        public FileMaid()
        {
            // Set Dir Location
            _targetPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            // Set Folder Settings
            _folders = GetFolders();
            SetFolders();

            _timer = new Timer(10000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void SetFolders()
        {
            foreach (var dir in _folders)
            {
                DirectoryInfo di = Directory.CreateDirectory($@"{_targetPath}\{dir.Name}");
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var folder in _folders)
            {
                foreach (var format in folder.FileFormats)
                {
                    foreach (var file in Directory.GetFiles(_targetPath, $"*{format}"))
                    {
                        var mFile = new FileInfo(file);
                        try
                        {
                            mFile.MoveTo($@"{_targetPath}\{folder.Name}\{mFile.Name}");
                        }
                        catch (Exception ex)
                        {
                            // If File Being Used By Other Process Try Again Later
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        private static HashSet<Folder> GetFolders()
        {
            var f1 = new Folder { Name = "_Audio", FileFormats = new[] { ".mp3", ".wav", ".wma", ".aif", ".cda", ".flac" } };
            var f2 = new Folder { Name = "_Text", FileFormats = new[] { ".txt", ".doc", ".csv", ".tsv", ".xlxs", ".odt", ".rtx", ".ods", ".xlr", ".xlx", ".xlxs", ".xlsm", ".xls" } };
            var f3 = new Folder { Name = "_Video", FileFormats = new[] { ".3g2", "3gp", ".avi", ".hlv", ".h264", ".m4v", ".mkv", ".mov", ".mp4", ".mpg", ".mpeg", ".rm", ".swf", ".vob", ".wmw" } };
            var f4 = new Folder { Name = "_Rar", FileFormats = new[] { ".rar", ".7z", ".arj", ".deb", ".pkg", ".rpm", ".tar.gz", ".z", ".zip" } };
            var f5 = new Folder { Name = "_Pdf", FileFormats = new[] { ".pdf" } };
            var f6 = new Folder { Name = "_Image", FileFormats = new[] { ".jpg", ".jpeg", ".ico", ".png", ".bmp", ".ai", ".ps", ".tif", ".tiff" } };
            var f7 = new Folder { Name = "_Gif", FileFormats = new[] { ".gif" } };
            return new HashSet<Folder>() { f1, f2, f3, f4, f5, f6, f7 };
        }
    }
}
