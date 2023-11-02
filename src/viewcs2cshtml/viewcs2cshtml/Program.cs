// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using viewcs2cshtml;

Console.WriteLine("Hello, World!");

String path = @".\viewcs";

var rootfiles = Directory.GetFiles(path, "*.cs");

foreach (var file in rootfiles)
{
    FileHelper.ReadWithLine(file);
    Console.WriteLine(file);
}

var dirs = Directory.GetDirectories(path);
//第一种方法获取指定格式

foreach (var dir in dirs)
{
    //FileHelper.ReadWithLine(file);
    var files = Directory.GetFiles(dir + "\\AspNetCore", "*.cs");

    foreach (var file in files)
    {
        FileHelper.ReadWithLine(file);
        Console.WriteLine(file);//.\viewcs\Api.Agent.Views\AspNetCore\Areas_Admin_Views_Agent_CustomerRecord.cs
    }
}



Console.WriteLine("文件读取异常：");
foreach (var file in FileHelper.ReadExceptionFiles)
{
    Console.WriteLine(file);
}


Console.ReadKey();
