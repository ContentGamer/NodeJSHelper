namespace NodeJSHelper;

using NodeJSHelper.Handlers;
using CliWrap;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello! Welcome to the NodeJS Setup wizard!\n");
        Console.WriteLine("Choose From the selections:\n");
        
        Console.WriteLine("· [1] Default App");
        Console.WriteLine("· [2] React App");
        Console.WriteLine("· [3] React Native");
        Console.WriteLine("· [4] Express App");

        Console.WriteLine("\n");

        Console.WriteLine("Choose: ");
        string num = Console.ReadLine() ?? "";

        switch (num)
        {
            case "1":
            case "2":
            case "3":
            case "4":
               Console.WriteLine("\nGood Choice!\n\nPlease Select a path to begin the installation:");
               break;
            default:
                Console.WriteLine("\nInvalid Choice, Exiting...");
                Environment.Exit(0);
                break;
        }

        string installationPath = Console.ReadLine() ?? "";

        if(!Path.Exists(installationPath))
        {
            Console.WriteLine("\nInvalid Path, Exiting...");
            Environment.Exit(0);
        }

        Console.WriteLine("\nChoose a good folder name:");
        string folderName = Console.ReadLine() ?? "";

        if(String.IsNullOrEmpty(folderName) || String.IsNullOrWhiteSpace(folderName))
        {
            Console.WriteLine("Invalid Folder Name, Exiting...");
            Environment.Exit(0);
        }

        string appType =   num == "1" ? "NodeJS" 
                       : num == "2" ? "React" 
                       : num == "3" ? "React Native" 
                       : num == "4" ? "Express" 
                       : "Unknown";

        Console.WriteLine($"\nAlright you are good to go! We are setting up the {appType} App Now... Please dont exit and be patient...\n");

        JSHandler handler = new JSHandler();
        handler.CreateApp(Convert.ToInt32(num), installationPath, folderName.ToLower().Replace(" ", "-"));
    }
}