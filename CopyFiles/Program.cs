namespace CopyFiles
{
    public class Program
    {
        // Main Program Entry Point
        public static void Main(string[] args)
        {
            var _copyFilesHelper = new CopyFilesHelper();

            if(args.Length <= 0)
            {
                _copyFilesHelper.Init();
            }
        }
    }
}
