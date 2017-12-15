using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace namentlitch
{
    using Microsoft.Win32;
    using System.IO;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegistryKey appKey = Application.UserAppDataRegistry;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string folderName = null;
            if (((folderName = (string)appKey.GetValue("LastFolderSearched")) == null) || (!Directory.Exists(folderName)))
            {
                folderName =System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            }

            frmNamentlitch form = null;
            Application.Run((form = new frmNamentlitch(folderName)));

            appKey.SetValue("LastFolderSearched", form.PathToGetImagesFrom, RegistryValueKind.String);
        }
    }
}