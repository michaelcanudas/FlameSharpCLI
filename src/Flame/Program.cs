using System;
using System.Collections.Generic;
using System.Linq;
using System.CommandLine;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace FlameSharp.CLI;

internal static class Program
{
    private static RootCommand root;

    private static void Main(string[] args)
    {
        root = new RootCommand();

        var newCmd = new Command("new");
        root.AddCommand(newCmd);
        var arg = new Argument<string>("--name");
        newCmd.AddArgument(arg);
        newCmd.SetHandler<string>(NewCmd, arg);
        root.SetHandler(FlameCmd);
       
        var buildCmd = new Command("build");
        buildCmd.AddAlias("bld");
        var configOption = new Option<string>("--config");
        configOption.AddAlias("-c");
        buildCmd.AddOption(configOption);
        root.AddCommand(buildCmd);
        buildCmd.SetHandler<string>(BuildCmd, configOption);

        var runCmd = new Command("run");
        root.AddCommand(runCmd);
        runCmd.SetHandler(RunCmd);

        root.Invoke(Console.ReadLine());
    }

    private static void FlameCmd()
    {
        Console.WriteLine("invokeed");
    }

    private static void NewCmd(string name)
    {
        Console.WriteLine(name);
    }

    private static void BuildCmd(string config)
    {
        
    }

    private static void RunCmd()
    {

    }
}