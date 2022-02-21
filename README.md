# sqlite3_analyzer_toObject
## Sqlite3 Analyzer To Object Parser

Converts the output of [sqlite3_analyzer](https://www.sqlite.org/sqlanalyze.html) to an object.

### How to use sqlite3_analyzer_toObject
```
var sqlite3_analyzer_output = File.ReadAllText("./Output.txt");
var obj = new sqlite3_analyzer_Object(sqlite3_analyzer_output);
```
### How to get sqlite3_analyzer output by code example
```
// Create process for exec command
Process p = new Process();
var command = "";

// Redirect the output stream of the child process.
p.StartInfo.UseShellExecute = false;
p.StartInfo.RedirectStandardOutput = true;

// Detect SO and set config
if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
	p.StartInfo.FileName = "cmd.exe";
	p.StartInfo.Arguments = "/C " + "_COMMAND_";

	command = 
		_Config.General.Sqlite_analyzer_Folder + "\\" + "sqlite3_analyzer_windows.exe" + " " +
		_Config.General.DataBaseConnection;
}
else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
	p.StartInfo.FileName = "/bin/bash";
	p.StartInfo.Arguments = "-c \" " + "_COMMAND_" + " \"";

	command = 
		_Config.General.Sqlite_analyzer_Folder + "\\" + "sqlite3_analyzer" + " " +
		_Config.General.DataBaseConnection;
}

p.StartInfo.Arguments = p.StartInfo.Arguments.Replace("_COMMAND_", command);
p.Start();

// Read the output stream first and then wait.
string output = p.StandardOutput.ReadToEnd();
p.WaitForExit();
```

**Feel free to modify and/or improve the code**
