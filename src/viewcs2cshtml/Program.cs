// See https://aka.ms/new-console-template for more information
using Microsoft.Win32;
using System;
using System.Linq;
using System.Management;
using viewcs2cshtml.Core;

Console.WriteLine("Hello, World!");


string uniqueId = GetProcessorId(); // 获取处理器ID作为示例

Console.WriteLine($"计算机唯一标识：{uniqueId}");
static string GetProcessorId()
{
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
    {
        ManagementObjectCollection collection = searcher.Get();

        foreach (ManagementObject obj in collection)
        {
            return obj["ProcessorId"].ToString();
        }
    }

    return string.Empty;
}
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
