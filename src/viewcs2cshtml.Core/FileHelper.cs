using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using viewcs2cshtml.Core.Members;
using viewcs2cshtml.Core.Tools;
using viewcs2cshtml.Core.Walkers;

namespace viewcs2cshtml.Core
{
    public static class FileHelper
    {
        public static List<string> ReadExceptionFiles = new List<string>();

        public static Dictionary<string, (string, string)> TagHelperContextDic = new Dictionary<string, (string, string)>();

        /// <summary>
        /// 例如：.\viewcs\Api.Agent.Views\AspNetCore\Areas_Admin_Views_Agent_CustomerRecord.cs
        /// </summary>
        /// <param name="file"></param>
        public static void ReadWithLine(string file)
        {
            try
            {
                var sb = new StringBuilder();

                var code = File.ReadAllText(file).Replace("(RenderAsyncDelegate)async delegate", "=>").Replace("base.ViewBag", "ViewBag").Replace("base.Layout", "Layout").Replace("base.Model", "Model");

                SyntaxTree tree = CSharpSyntaxTree.ParseText(code);

                var root = (CompilationUnitSyntax)tree.GetRoot();

                var classbody =   root.DescendantNodes().OfType<MethodDeclarationSyntax>().ToList().FirstOrDefault().Parent as ClassDeclarationSyntax;

                //获取layout
                var layoutwalker = new LayoutWalker();
                layoutwalker.VisitClassDeclarationSyntax(classbody.AttributeLists);
                sb.Append(layoutwalker.sbCode);

                foreach (var member in classbody.Members)
                {
                    if (member is FieldDeclarationSyntax)
                    {
                        var fieldDeclarationSyntaxMember = new FieldDeclarationSyntaxMember();
                        fieldDeclarationSyntaxMember.Visit(member as FieldDeclarationSyntax);
                        sb.Append(fieldDeclarationSyntaxMember.sbCode);
                    }
                    if (member is MethodDeclarationSyntax)
                    {
                        var methodDeclarationSyntaxMember = new MethodDeclarationSyntaxMember();
                        methodDeclarationSyntaxMember.Visit(member as MethodDeclarationSyntax);
                        sb.Append(methodDeclarationSyntaxMember.sbCode);
                    }
                }

                sb.Replace("\r\n}\r\n@{\r\n", "\r\n    ");
                sb.Replace("\r\n@}\r\n@{\r\n", "\r\n    ");

                Console.WriteLine($"{sb.ToString()}");

                var filepath = file.Split("\\");
                if (filepath.Length > 0 && filepath.Length > 3)
                {
                    var filename = filepath[4].Split("_");
                    var newpath = StatementCodeTransformHelper.Merge(filepath.Take(filepath.Count() - 1).ToArray(), filename);
                    var pathroot = string.Join("\\", newpath.Take(newpath.Length - 1));
                    string docPath = string.Join("\\", newpath.Take(newpath.Length - 1));
                    Directory.CreateDirectory(pathroot);
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(pathroot, newpath.LastOrDefault().Replace(".cs", ".cshtml"))))
                    {
                        outputFile.Write(sb);
                    }
                }
                else
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine("./", file.Replace(".cs", ".cshtml"))))
                    {
                        outputFile.Write(sb);
                    }
                }
            }
            catch (Exception ex)
            {
                ReadExceptionFiles.Add(file);
            }
        }
    }


}
