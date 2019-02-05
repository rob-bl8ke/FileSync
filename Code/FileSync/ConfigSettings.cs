using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    public static class ConfigSettings
    {
        private static string registryFolder;
        public static string RegistryPath
        {
            get
            {
                if (string.IsNullOrEmpty(registryFolder))
                    registryFolder = ConfigurationManager.AppSettings["RegistryPath"];

                return registryFolder;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["RegistryPath"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string winMergePath;
        public static string WinMergePath
        {
            get
            {
                if (string.IsNullOrEmpty(winMergePath))
                    winMergePath = ConfigurationManager.AppSettings["WinMergePath"];

                return winMergePath;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["WinMergePath"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string applicationTitle;
        public static string ApplicationTitle
        {
            // retrieve this value from AssemblyInfo
            get
            {
                if (string.IsNullOrEmpty(applicationTitle))
                {
                    object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                    if (attributes.Length > 0)
                    {
                        AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                        if (titleAttribute.Title != "")
                        {
                            applicationTitle = titleAttribute.Title;
                            return applicationTitle;
                        }
                    }
                    applicationTitle = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
                    return applicationTitle;
                }
                return applicationTitle;
            }
        }

        private static string lastProject;
        public static string LastProject
        {
            get
            {
                if (string.IsNullOrEmpty(lastProject))
                    lastProject = ConfigurationManager.AppSettings["LastProject"];

                return lastProject;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["LastProject"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string projectBackupFolder;
        public static string ProjectBackupFolder
        {
            get
            {
                if (string.IsNullOrEmpty(projectBackupFolder))
                    projectBackupFolder = ConfigurationManager.AppSettings["ProjectBackupFolder"];

                return projectBackupFolder;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["ProjectBackupFolder"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static bool? backupBeforeLeft;
        public static bool BackupBeforeLeft
        {
            get
            {
                if (!backupBeforeLeft.HasValue)
                    backupBeforeLeft = Boolean.Parse(ConfigurationManager.AppSettings["BackupBeforeLeft"]);

                return backupBeforeLeft.Value;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["BackupBeforeLeft"].Value = value.ToString();
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static bool? backupBeforeRight;
        public static bool BackupBeforeRight
        {
            get
            {
                if (!backupBeforeRight.HasValue)
                    backupBeforeRight = Boolean.Parse(ConfigurationManager.AppSettings["BackupBeforeRight"]);

                return backupBeforeRight.Value;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["BackupBeforeRight"].Value = value.ToString();
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static bool? backupBeforeProjectEdit;
        public static bool BackupBeforeProjectEdit
        {
            get
            {
                if (!backupBeforeProjectEdit.HasValue)
                    backupBeforeProjectEdit = Boolean.Parse(ConfigurationManager.AppSettings["BackupBeforeProjectEdit"]);

                return backupBeforeProjectEdit.Value;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["BackupBeforeProjectEdit"].Value = value.ToString();
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static int? backupFolderLimit;
        public static int BackupFolderLimit
        {
            get
            {
                if (!backupFolderLimit.HasValue)
                    backupFolderLimit = Int32.Parse(ConfigurationManager.AppSettings["BackupFolderLimit"]);

                return backupFolderLimit.Value;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["BackupFolderLimit"].Value = value.ToString();
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string projectExtension;
        public static string ProjectExtension
        {
            get
            {
                if (string.IsNullOrEmpty(projectExtension))
                    projectExtension = ConfigurationManager.AppSettings["ProjectExtension"];

                return projectExtension;
            }
        }

        public static string ProjectFileDialogFilterPattern
        {
            get
            {
                return string.Format("FileSync Project File *.{0} (*.{0})|*.{0}", ProjectExtension);
            }
        }

        public static string ProjectFileDialogDefaultExtension
        {
            get
            {
                return "*." + ProjectExtension;
            }
        }

        public static void Refresh()
        {
            registryFolder = ConfigurationManager.AppSettings["RegistryPath"];
            lastProject = ConfigurationManager.AppSettings["LastProject"];
            winMergePath = ConfigurationManager.AppSettings["WinMergePath"];
            backupBeforeLeft = Boolean.Parse(ConfigurationManager.AppSettings["BackupBeforeLeft"]);
            backupBeforeRight = Boolean.Parse(ConfigurationManager.AppSettings["BackupBeforeRight"]);
            backupBeforeProjectEdit = Boolean.Parse(ConfigurationManager.AppSettings["BackupBeforeProjectEdit"]);
            backupFolderLimit = Int32.Parse(ConfigurationManager.AppSettings["BackupFolderLimit"]);
            projectBackupFolder = ConfigurationManager.AppSettings["ProjectBackupFolder"];
            projectExtension = ConfigurationManager.AppSettings["ProjectExtension"];
        }
    }
}
