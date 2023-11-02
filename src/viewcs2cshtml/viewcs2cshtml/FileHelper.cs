using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace viewcs2cshtml
{
    public static class FileHelper
    {
        public static List<string> ReadExceptionFiles = new List<string>();
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

                foreach (var methodDeclaration in root.DescendantNodes().OfType<MethodDeclarationSyntax>())
                {
                    if (methodDeclaration.Identifier.ValueText == "ExecuteAsync")
                    {
                        var body = methodDeclaration.Body;
                        var nodes = body.Statements.ToList();
                        foreach (var node in nodes)
                        {
                            var nodebody = node.ToString();
                            switch (node.Kind())
                            {
                                case SyntaxKind.LocalDeclarationStatement:
                                    sb.AppendLine($"@{{");
                                    sb.AppendLine(nodebody);
                                    sb.AppendLine($"}}");
                                    break;
                                case SyntaxKind.ForEachStatement:
                                case SyntaxKind.IfStatement:
                                case SyntaxKind.ForStatement:
                                    sb.Append(ConvertToSectionCode(nodebody));
                                    break;
                                case SyntaxKind.ExpressionStatement:
                                    sb.Append(ExpressionStatement(nodebody));
                                    break;
                            }
                        }
                        var i = 0;
                    }
                }

                Console.WriteLine($"{sb.ToString()}");

                var filepath = file.Split("\\");
                if (filepath.Length > 0 && filepath.Length > 3)
                {
                    var filename = filepath[4].Split("_");
                    var newpath = Merge(filepath.Take(filepath.Count() - 1).ToArray(), filename);
                    var pathroot = string.Join("\\", newpath.Take(newpath.Length - 1));
                    string docPath = string.Join("\\", newpath.Take(newpath.Length - 1));
                    Directory.CreateDirectory(pathroot);
                    // Write the string array to a new file named "WriteLines.txt".
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

        public static StringBuilder ExpressionStatement(string statementcode)
        {
            var sb = new StringBuilder();

            SyntaxTree tree = CSharpSyntaxTree.ParseText(statementcode);

            var root = (CompilationUnitSyntax)tree.GetRoot();

            if (root.DescendantNodes().OfType<InvocationExpressionSyntax>().Any())
            {
                foreach (var invocation in root.DescendantNodes().OfType<InvocationExpressionSyntax>())
                {
                    if (invocation.Expression.ToString() == "DefineSection")
                    {
                        statementcode = statementcode.Replace(invocation.ToString(), "");
                        var argList = invocation.ArgumentList.Arguments;
                        if (argList.Count == 2)
                        {
                            var sectionName = argList[0].Expression.ToString().Trim('"');
                            var lambdaBody = argList[1].Expression as ParenthesizedLambdaExpressionSyntax;
                            sb.AppendLine($"@section {sectionName}{{");
                            if (lambdaBody == null)
                            {
                                var lambdaBody1 = argList[1].Expression as SimpleLambdaExpressionSyntax;
                                if (lambdaBody1 != null)
                                {
                                    var block = lambdaBody1.Body as BlockSyntax;
                                    if (block != null)
                                    {
                                        foreach (var blockinvocation in block.Statements)
                                        {
                                            switch (blockinvocation.Kind())
                                            {
                                                case SyntaxKind.ForEachStatement:
                                                case SyntaxKind.IfStatement:
                                                case SyntaxKind.ForStatement:
                                                    sb.Append(ConvertToSectionCode(blockinvocation.ToString()));
                                                    break;
                                                default:
                                                    sb.Append(AppendStringBuilder(blockinvocation.ToString()));
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var block = lambdaBody.Body as BlockSyntax;
                                if (block != null)
                                {
                                    var stylesContent = block.Statements[0].ToString(); // Assuming it's the first statement
                                    Console.WriteLine($"DefineSection \"{sectionName}\": {stylesContent}");
                                }
                            }
                            sb.AppendLine($"}}");
                        }
                    }
                }

                SyntaxTree tree1 = CSharpSyntaxTree.ParseText(statementcode);

                var root1 = (CompilationUnitSyntax)tree1.GetRoot();

                foreach (var invocation in root1.DescendantNodes().OfType<InvocationExpressionSyntax>())
                {
                    switch (invocation.Kind())
                    {
                        case SyntaxKind.ForEachStatement:
                        case SyntaxKind.IfStatement:
                        case SyntaxKind.ForStatement:
                            sb.Append(ConvertToSectionCode(invocation.ToString()));
                            break;
                        default:
                            sb.Append(AppendStringBuilder(invocation.ToString()));
                            break;
                    }
                }
            }
            else
            {
                sb.AppendLine($"@{{");
                sb.AppendLine(statementcode);
                sb.AppendLine($"}}");
            }
            return sb;
        }
        public static StringBuilder AppendStringBuilder(string statementcode)
        {

            if (statementcode.Contains("BeginContext(") || statementcode.Contains("EndContext("))
            {
                return null;
            }
            var sb = new StringBuilder();

            if (statementcode.Contains("EndWriteAttribute("))
            {
                sb.Append('"');
                return sb;
            }
            try
            {
                SyntaxTree tree = CSharpSyntaxTree.ParseText(statementcode);
                var root = (CompilationUnitSyntax)tree.GetRoot();

                if (root.DescendantNodes().OfType<InvocationExpressionSyntax>().FirstOrDefault() != null)
                {
                    var argList = root.DescendantNodes().OfType<InvocationExpressionSyntax>().FirstOrDefault().ArgumentList.Arguments.Select(o => o.ToString()).ToArray();

                    if (statementcode.Contains("WriteAttributeValue(") || statementcode.Contains("BeginWriteAttribute("))
                    {
                        var index = statementcode.Contains("BeginWriteAttribute(") ? 1 : 2;
                        var splits = argList;
                        if (splits.Length == 6)
                        {
                            if (splits[5].Contains("isLiteral: false"))
                            {
                                splits[index] = $"@({splits[index].Trim()})";
                                splits[index] = splits[index].Replace("\"\\r\\n", "\n").Replace("\\r\\n", "\n");
                                splits[index] = splits[index].Replace("\\\"", "\"");
                                splits[index] = splits[index].Replace("\\\"\"", "\"");
                            }
                            else
                            {
                                splits[index] = splits[index].Trim();
                                splits[index] = splits[index].Replace("\"\\r\\n", "\n").Replace("\\r\\n", "\n");
                                splits[index] = splits[index].Replace("\\\"", "\"");
                                splits[index] = splits[index].Replace("\\\"\"", "\"");
                                splits[index] = splits[index].Substring(1, splits[index].Length - 2);
                            }
                            statementcode = splits[index];
                            if (index == 1)
                            {
                                statementcode = statementcode.Replace(" \"", " ").Replace("\\\"", "\"").Replace("\"\"", "\"");
                            }
                            else
                            {
                                statementcode = statementcode.Replace("\"/", "/").Replace("\"\"", "");
                            }
                        }
                    }
                    if (statementcode.Contains("WriteLiteral("))
                    {
                        argList[0] = argList[0].Replace("\"\\r\\n", "\n").Replace("\\r\\n", "\n");
                        argList[0] = argList[0].Replace("\\\"", "\"");
                        argList[0] = argList[0].Replace("\\\"\"", "\"");
                        statementcode = argList[0].Replace("\\\"", "").Replace("\"\">", "\">");//.Replace("\");", "")
                        if (statementcode.LastOrDefault() == '"')
                        {
                            statementcode = statementcode.Substring(0, statementcode.Length - 1);
                        }
                        if (statementcode.FirstOrDefault() == '"')
                        {
                            statementcode = statementcode.Substring(1, statementcode.Length - 1);
                        }
                    }
                    if (statementcode.Contains("Write("))
                    {
                        argList[0] = argList[0].Replace("\"\\r\\n", "\n").Replace("\\r\\n", "\n");
                        argList[0] = argList[0].Replace("\\\"", "\"");
                        argList[0] = argList[0].Replace("\\\"\"", "\"");

                        statementcode = ("@" + argList[0]).Replace("));", "))");
                    }
                    sb.Append(statementcode);
                    return sb;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        static StringBuilder ConvertToSectionCode(string code)
        {
            Regex regex = new Regex("\n");
            string[] lines = regex.Split(code);
            int index_houkuohao = 0;
            int index_qiandakuohao = 0;
            int breakindex = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                if (index_houkuohao == 0 && lines[i].Contains(")"))
                {
                    index_houkuohao = i;
                    breakindex++;
                }
                if (index_qiandakuohao == 0 && lines[i].Contains("{"))
                {
                    index_qiandakuohao = i;
                    breakindex++;
                }
                if (breakindex >= 2)
                {
                    break;
                }
            }
            //寻找第一个)和第一个{在第几行
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i <= index_houkuohao; i++)
            {
                if (i == 0)
                {
                    sb.Append($"\n@{lines[i]}");
                    code = code.Replace(lines[i], "DefineSection(\"if\", =>");
                }
                else
                {
                    sb.Append($"{lines[i]}");
                    code = code.Replace(lines[i], "");
                }
            }
            sb.Append($"{{\n");

            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = (CompilationUnitSyntax)tree.GetRoot();

            foreach (var invocation in root.DescendantNodes().OfType<InvocationExpressionSyntax>())
            {
                var argList = invocation.ArgumentList.Arguments;
                if (argList.Count == 2)
                {
                    var sectionName = argList[0].Expression.ToString().Trim('"');
                    var lambdaBody = argList[1].Expression as ParenthesizedLambdaExpressionSyntax;

                    if (lambdaBody == null)
                    {
                        var lambdaBody1 = argList[1].Expression as SimpleLambdaExpressionSyntax;
                        if (lambdaBody1 != null)
                        {
                            var block = lambdaBody1.Body as BlockSyntax;
                            if (block != null)
                            {
                                foreach (var str in block.Statements)
                                {
                                    switch (str.Kind())
                                    {
                                        case SyntaxKind.ForEachStatement:
                                        case SyntaxKind.IfStatement:
                                        case SyntaxKind.ForStatement:
                                            sb.Append(ConvertToSectionCode(str.ToString()));
                                            break;
                                        default:
                                            sb.Append(AppendStringBuilder(str.ToString()));
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sb.AppendLine($"}}");

            return sb;
        }

        static string[] Merge(string[] a, string[] b)
        {
            string[] c = new string[a.Length + b.Length];

            Array.Copy(a, 0, c, 0, a.Length);
            Array.Copy(b, 0, c, a.Length, b.Length);

            return c;
        }
    }
}
