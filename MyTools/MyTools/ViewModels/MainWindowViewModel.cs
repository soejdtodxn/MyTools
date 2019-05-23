using MyTools.TempLibrary;
using System.Diagnostics;
using System.Windows.Input;

namespace ViewModels.MyTools
{
    public class MainWindowViewModel
    {
        public ICommand ShowSecondCommand;
        public ICommand HideSecondCommand;

        public bool RunAsAdministrator { get; set; }

        public MainWindowViewModel()
        {
            ShowSecondCommand = new Command((object obj) =>
            {
                RunBatchFile("../../Scripts/ShowSecondOnTaskBarClock.bat");
            });

            HideSecondCommand = new Command((object obj) =>
            {
                RunBatchFile("../../Scripts/HideSecondOnTaskBarClock.bat");
            });
        }

        private void RunBatchFile(string path)
        {
            var processStartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                FileName = @"cmd.exe",
                Arguments = "/C" + path
            };

            if (RunAsAdministrator)
                processStartInfo.Verb = "runas";

            var process = new Process() { StartInfo = processStartInfo };
            process.Start();
        }
    }
}
