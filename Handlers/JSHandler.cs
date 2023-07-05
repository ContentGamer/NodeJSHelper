namespace NodeJSHelper.Handlers;

class JSHandler
{
    public void CreateApp(int selectedNumber, string path, string folderName)
    {
        try {
            switch (selectedNumber)
            {
                case 1:
                case 4:
                   Directory.CreateDirectory(Path.Combine(path, folderName));
                   break;
                default:
                   break;
            }
        }catch{
            Console.WriteLine("Folder name should not have special characters!");
            Environment.Exit(0);
        }

        SetupHandler sh = new SetupHandler();
        switch (selectedNumber)
        {
            case 1:
                sh.SetupDefault(Path.Combine(path, folderName), folderName);
                break;
            case 2:
                sh.SetupReactJS(Path.Combine(path, folderName), folderName);
                break;
            case 3:
                sh.SetupReactNative(Path.Combine(path, folderName), folderName);
                break;
            case 4:
                sh.SetupExpressApp(Path.Combine(path, folderName), folderName);
                break;
            default:
                break;
        }
    }
}