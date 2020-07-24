using System;

namespace CopyFiles
{
    public class CopyFilesHelper
    {
        // Constructor
        public CopyFilesHelper()
        {
        }

        // Properties
        private string DestPath { get; set; }
        private string SourcePath { get; set; }
        private bool Replace { get; set; }

        // Methods
        private bool ConfirmCopy()
        {
            Console.Write("Are you sure you want to copy items from " + SourcePath + " to " + DestPath + "? (Y/N) ");
            string _confirm = Console.ReadLine();

            if (_confirm.ToLower() == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Copy operation cancelled.");
                Console.WriteLine();
                return false;
            }
        }
        private void ConfirmReplace()
        {
            Console.Write("Do you want to replace the destination files? (Y/N) ");
            string _confirm = Console.ReadLine();

            if (_confirm.ToLower() == "y")
            {
                Replace = true;
            }
            else
            {
                Replace = false;
            }
        }
        private void Copy()
        {
            Console.WriteLine("Copying...");

            foreach (var dir in System.IO.Directory.GetDirectories(SourcePath))
            {
                foreach (var file in System.IO.Directory.GetFiles(dir))
                {
                    try
                    {
                        var destFileName = DestPath + "\\" + System.IO.Path.GetFileName(file);
                        if (Replace)
                        {
                            System.IO.File.Copy(file, destFileName, true);
                            Console.WriteLine("Replaced file: " + destFileName);
                        }
                        else
                        {
                            if (!System.IO.File.Exists(destFileName))
                            {
                                System.IO.File.Copy(file, destFileName, false);
                                Console.WriteLine("Copied new file: " + destFileName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        return;
                    }
                }
            }

            Console.WriteLine("Finished copying!");
        }
        private void GetDestPath()
        {
            Console.Write("Enter Destination Directory: ");
            string _destPath = Console.ReadLine();

            if (!System.IO.Directory.Exists(_destPath))
            {
                Console.WriteLine("Dest path does not exist.");
                Console.WriteLine();
                GetDestPath();
            }

            DestPath = _destPath;
        }
        private void GetSourcePath()
        {
            Console.Write("Enter Source Directory: ");
            string _sourcePath = Console.ReadLine();

            if (!System.IO.Directory.Exists(_sourcePath))
            {
                Console.WriteLine("Source path does not exist.");
                Console.WriteLine();
                GetSourcePath();
            }

            SourcePath = _sourcePath;
        }

        // Public methods
        public void Init()
        {
            GetSourcePath();
            GetDestPath();
            ConfirmReplace();
            if (ConfirmCopy())
            {
                Copy();
            }
            else
            {
                Init();
            }
            Console.ReadLine();
        }
    }
}
