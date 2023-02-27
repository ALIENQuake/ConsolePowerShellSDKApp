// See https://aka.ms/new-console-template for more information
using Microsoft.PowerShell;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

Console.WriteLine("Hello, World!");
string AppDir = System.Diagnostics.Debugger.IsAttached ? Path.GetFullPath(AppContext.BaseDirectory) : Environment.CurrentDirectory;

var runspaceConfiguration = InitialSessionState.CreateDefault2();
if (OperatingSystem.IsWindows() == true)
{
    runspaceConfiguration.ExecutionPolicy = ExecutionPolicy.Bypass;
}
var pipeline = PowerShell.Create(RunspaceFactory.CreateRunspace(runspaceConfiguration));

pipeline.Runspace.Open();
pipeline.Commands.AddCommand("Get-ChildItem");

var results = pipeline.Invoke();
foreach (var item in results)
{
    Console.WriteLine(item);
}

if (!System.Diagnostics.Debugger.IsAttached)
{
    Console.WriteLine(@"Press any key.");
    Console.ReadKey();
}
