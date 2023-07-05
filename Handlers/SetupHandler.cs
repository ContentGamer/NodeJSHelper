namespace NodeJSHelper.Handlers;

using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;

#nullable disable

enum Result
{
    Ok = 1,
    ErrorOccured = 2,
    NotInstalled = 3
}

class SetupHandler
{
    public void SetupDefault(string fPath, string folName)
    {
        Directory.CreateDirectory(Path.Combine(fPath, "src"));

        var cmdProcess = new Process();
        var cmdInfo = new ProcessStartInfo();
        cmdInfo.WindowStyle = ProcessWindowStyle.Normal;
        cmdInfo.FileName = "cmd.exe";
        cmdInfo.Arguments = "/C npm init -y";
        cmdInfo.WorkingDirectory = fPath;
        cmdInfo.RedirectStandardOutput = true;
        cmdProcess.StartInfo = cmdInfo;
        cmdProcess.Start();

        Console.WriteLine(cmdProcess.StandardOutput.ReadToEnd());

        string[] pckgWrite = new string[] { 
            "{", 
            $"  \"name\": \"{folName}\",",
            "  \"version\": \"1.0.0\",",
            "  \"description\": \"\",",
            "  \"main\": \"src/index.js\",",
            "  \"scripts\": {",
            "      \"test\": \"node .\"",
            "  },",
            "  \"keywords\": [],",
            "  \"author\": \"\",",
            "  \"license\": \"ISC\"",
            "}"
        };

        File.WriteAllLines(Path.Combine(fPath, "package.json"), pckgWrite);
        File.WriteAllLines(Path.Combine(fPath, "src", "index.js"), new[]{ "console.log('Hello world!')" });
    }

    public void SetupReactJS(string fPath, string folName)
    {
        var cmdProcess = new Process();
        var cmdInfo = new ProcessStartInfo();
        cmdInfo.WindowStyle = ProcessWindowStyle.Normal;
        cmdInfo.FileName = "cmd.exe";
        cmdInfo.Arguments = $"/C npx create-react-app {folName}";
        cmdInfo.WorkingDirectory = Path.Combine(fPath, "../");
        cmdInfo.RedirectStandardOutput = true;
        cmdProcess.StartInfo = cmdInfo;
        cmdProcess.Start();

        Console.WriteLine(cmdProcess.StandardOutput.ReadToEnd());
    }

    public void SetupReactNative(string fPath, string folName)
    {
        var cmdProcess = new Process();
        var cmdInfo = new ProcessStartInfo();
        cmdInfo.WindowStyle = ProcessWindowStyle.Normal;
        cmdInfo.FileName = "cmd.exe";
        cmdInfo.Arguments = $"/C nnpx create-expo-app {folName}";
        cmdInfo.WorkingDirectory = Path.Combine(fPath, "../");
        cmdInfo.RedirectStandardOutput = true;
        cmdProcess.StartInfo = cmdInfo;
        cmdProcess.Start();

        Console.WriteLine(cmdProcess.StandardOutput.ReadToEnd());
    }

    public void SetupExpressApp(string fPath, string folName)
    {
        Directory.CreateDirectory(Path.Combine(fPath, "src"));
        Directory.CreateDirectory(Path.Combine(fPath, "public"));

        var cmdProcess = new Process();
        var cmdInfo = new ProcessStartInfo();
        cmdInfo.WindowStyle = ProcessWindowStyle.Hidden;
        cmdInfo.FileName = "cmd.exe";
        cmdInfo.Arguments = "/C npm init -y";
        cmdInfo.WorkingDirectory = fPath;
        cmdInfo.RedirectStandardOutput = true;
        cmdProcess.StartInfo = cmdInfo;
        cmdProcess.Start();

        Console.WriteLine(cmdProcess.StandardOutput.ReadToEnd());
        cmdProcess.Kill();

        string[] pckgWrite = new string[] { 
            "{", 
            $"  \"name\": \"{folName}\",",
            "  \"version\": \"1.0.0\",",
            "  \"description\": \"\",",
            "  \"main\": \"src/server.js\",",
            "  \"scripts\": {",
            "      \"test\": \"node .\"",
            "  },",
            "  \"keywords\": [],",
            "  \"author\": \"\",",
            "  \"license\": \"ISC\"",
            "}"
        };

        string serverJSScript = "const express = require(\"express\");\nconst path = require(\"path\")\nconst app = express();\n\napp.use(\"/\", (req, res) => {\n    res.sendFile(path.join(__dirname, \"../public\", \"index.html\"));\n});\n\napp.listen(8080, () => {\n    console.log(\"Website is working and on http://localhost:8080\");\n});";
        string indexHTMLScript = "<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n    <meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>HTML Page</title>\n</head>\n<body>\n    <h1>Hello world! From HTML</h1>\n</body>\n</html>";

        File.WriteAllLines(Path.Combine(fPath, "package.json"), pckgWrite);

        var cmdProcessInit = new Process();
        var cmdInfoInit = new ProcessStartInfo();
        cmdInfoInit.WindowStyle = ProcessWindowStyle.Hidden;
        cmdInfoInit.FileName = "cmd.exe";
        cmdInfoInit.Arguments = "/C npm i express";
        cmdInfoInit.WorkingDirectory = fPath;
        cmdInfoInit.RedirectStandardOutput = true;
        cmdProcessInit.StartInfo = cmdInfoInit;
        cmdProcessInit.Start();

        Console.WriteLine(cmdProcessInit.StandardOutput.ReadToEnd());
        cmdProcessInit.Kill();

        File.WriteAllLines(Path.Combine(fPath, "src", "server.js"), serverJSScript.Split("\n"));
        File.WriteAllLines(Path.Combine(fPath, "public", "index.html"), indexHTMLScript.Split("\n"));
    }
}