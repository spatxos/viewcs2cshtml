﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using viewcs2cshtml.Core.Walkers;
using viewcs2cshtml.Core.Members;

namespace viewcs2cshtml.Core.Tools
{
    public static class StatementCodeTransformHelper
    {
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
                                                case SyntaxKind.LocalDeclarationStatement:
                                                    //sb.AppendLine($"@{{");
                                                    sb.AppendLine(blockinvocation.ToString());
                                                    //sb.AppendLine($"}}");
                                                    break;
                                                case SyntaxKind.IfStatement:
                                                    var ifwalker = new IfElseWalker();
                                                    ifwalker.Visit(blockinvocation);
                                                    sb.Append(ifwalker.sbCode);
                                                    break;
                                                case SyntaxKind.ForEachStatement:
                                                    var foreachwalker = new ForeachWalker();
                                                    foreachwalker.Visit(blockinvocation);
                                                    sb.Append(foreachwalker.sbCode);
                                                    break;
                                                case SyntaxKind.SwitchStatement:
                                                    var switchwalker = new SwitchWalker();
                                                    switchwalker.Visit(blockinvocation);
                                                    sb.Append(switchwalker.sbCode);
                                                    break;
                                                case SyntaxKind.ForStatement:
                                                case SyntaxKind.UnsafeStatement:
                                                case SyntaxKind.WhileStatement:
                                                    sb.Append(ConvertToSectionCode(blockinvocation.ToString()));
                                                    break;
                                                case SyntaxKind.InvocationExpression:
                                                case SyntaxKind.ExpressionStatement:
                                                    //MemberAccessExpressionSyntax SimpleMemberAccessExpression __tagHelperScopeManager.Begin
                                                    if (blockinvocation.ToString().Contains("__tagHelper"))
                                                    {
                                                        var taghelpwalker = new TagHelperExpressionWalker();
                                                        taghelpwalker.Visit(blockinvocation);
                                                        sb.Append(taghelpwalker.sbCode);
                                                    }
                                                    else
                                                    {
                                                        sb.Append(ExpressionStatement(blockinvocation.ToString()));
                                                    }
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

                var invocation1 = root1.DescendantNodes().OfType<InvocationExpressionSyntax>().FirstOrDefault();
                if (invocation1 != null)
                {
                    switch (invocation1.Kind())
                    {
                        case SyntaxKind.LocalDeclarationStatement:
                            //sb.AppendLine($"@{{");
                            sb.AppendLine(invocation1.ToString());
                            //sb.AppendLine($"}}");
                            break;
                        case SyntaxKind.IfStatement:
                            var ifwalker = new IfElseWalker();
                            ifwalker.Visit(invocation1);
                            sb.Append(ifwalker.sbCode);
                            break;
                        case SyntaxKind.ForEachStatement:
                            var foreachwalker = new ForeachWalker();
                            foreachwalker.Visit(invocation1);
                            sb.Append(foreachwalker.sbCode);
                            break;
                        case SyntaxKind.SwitchStatement:
                            var switchwalker = new SwitchWalker();
                            switchwalker.Visit(invocation1);
                            sb.Append(switchwalker.sbCode);
                            break;
                        case SyntaxKind.ForStatement:
                        case SyntaxKind.UnsafeStatement:
                        case SyntaxKind.WhileStatement:
                            sb.Append(ConvertToSectionCode(invocation1.ToString()));
                            break;
                        case SyntaxKind.ObjectCreationExpression:

                            break;
                        case SyntaxKind.InvocationExpression:
                            if ((invocation1.ToString().Contains("__tagHelper") || invocation1.ToString().Contains("__Microsoft_AspNetCore_Mvc_TagHelpers")) && invocation1.Expression is MemberAccessExpressionSyntax)
                            {
                                var taghelpwalker = new TagHelperExpressionWalker();
                                taghelpwalker.Visit(invocation1);
                                sb.Append(taghelpwalker.sbCode);
                            }
                            else
                            {
                                sb.Append(AppendStringBuilder(invocation1.ToString()));
                            }
                            break;
                        default:
                            sb.Append(AppendStringBuilder(invocation1.ToString()));
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
                var invocationExpressionSyntax = root.DescendantNodes().OfType<InvocationExpressionSyntax>().FirstOrDefault();
                if (invocationExpressionSyntax != null)
                {
                    var argList = invocationExpressionSyntax.ArgumentList.Arguments.Select(o => o.ToString()).ToArray();

                    if (statementcode.Contains("WriteAttributeValue(") || statementcode.Contains("BeginWriteAttribute("))
                    {
                        var index = statementcode.Contains("BeginWriteAttribute(") ? 1 : 2;
                        var splits = argList;
                        if (splits.Length == 6)
                        {
                            if (splits[5].Contains("isLiteral: false"))
                            {
                                splits[index] = $"@({splits[index].Trim()})";
                                splits[index] = splits[index].Replace("\"\r\\n", "\n").Replace("\\r\\n", "\n");
                                splits[index] = splits[index].Replace("\\\"", "\"");
                                splits[index] = splits[index].Replace("\\\"\"", "\"");
                            }
                            else
                            {
                                splits[index] = splits[index].Trim();
                                splits[index] = splits[index].Replace("\"\r\\n", "\n").Replace("\\r\\n", "\n");
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
                        argList[0] = argList[0].Replace("\"\r\\n", "\n").Replace("\\r\\n", "\n");
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
                        if (argList[0].Contains("money3.MoneyId"))
                        {
                        }
                        argList[0] = argList[0].Replace("\"\r\\n", "\n").Replace("\\r\\n", "\n");
                        argList[0] = argList[0].Replace("\\\"", "\"");
                        argList[0] = argList[0].Replace("\\\"\"", "\"");

                        statementcode = ("@(" + argList[0]).Replace("));", "))") + ")";
                    }
                    sb.Append(statementcode);
                    return sb;
                }
                else
                {
                    //sb.AppendLine($"@{{");
                    if (invocationExpressionSyntax != null && root.Kind() == SyntaxKind.CompilationUnit)
                    {
                        statementcode = statementcode.Replace("\"\r\\n", "\n").Replace("\\r\\n", "\n");
                        statementcode = statementcode.Replace("\\\"", "\"");
                        statementcode = statementcode.Replace("\\\"\"", "\"");
                    }
                    sb.AppendLine(statementcode);
                    //sb.AppendLine($"}}");
                    return sb;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public static StringBuilder ConvertToSectionCode(string code, string headStr = null, string replaceStr = null)
        {
            StringBuilder sb = new StringBuilder();

            Regex regex = new Regex("\n");
            string[] lines = regex.Split(code);
            if (lines.Length <= 1)
            {
                return sb;
            }
            if (code.Contains("InvoiceType"))
            {

            }
            int index_houkuohao = 0;
            int index_qiandakuohao = 0;
            int breakindex = 0;
            //寻找第一个)和第一个{在第几行
            if (string.IsNullOrWhiteSpace(headStr))
            {
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
            }
            else
            {
                sb.Append($"\r\n@{headStr}");
            }
            if (replaceStr != null)
            {
                sb.Append($"{replaceStr}\n");
            }
            else
            {
                sb.Append($"{{\r\n");
            }

            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            var root = (CompilationUnitSyntax)tree.GetRoot();

            var invocationExpressionSyntax = root.DescendantNodes().OfType<InvocationExpressionSyntax>().FirstOrDefault();
            if (invocationExpressionSyntax != null)
            {
                //foreach (var invocation in root.DescendantNodes().OfType<InvocationExpressionSyntax>())
                //{
                var argList = invocationExpressionSyntax.ArgumentList.Arguments;
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
                                    var nodebody = str.ToString();
                                    if (nodebody.Contains("__tagHelperExecutionContext"))
                                    {
                                        
                                    }
                                    switch (str.Kind())
                                    {
                                        case SyntaxKind.LocalDeclarationStatement:
                                            //sb.AppendLine($"@{{");
                                            sb.AppendLine(nodebody);
                                            //sb.AppendLine($"}}");
                                            break;
                                        case SyntaxKind.IfStatement:
                                            if (nodebody.Contains("__tagHelperExecutionContext.Output"))
                                            {
                                                continue;
                                            }
                                            var ifwalker = new IfElseWalker();
                                            ifwalker.Visit(str);
                                            sb.Append(ifwalker.sbCode);
                                            break;
                                        case SyntaxKind.ForEachStatement:
                                            var foreachwalker = new ForeachWalker();
                                            foreachwalker.Visit(str);
                                            sb.Append(foreachwalker.sbCode);
                                            break;
                                        case SyntaxKind.SwitchStatement:
                                            var switchwalker = new SwitchWalker();
                                            switchwalker.Visit(str);
                                            sb.Append(switchwalker.sbCode);
                                            break;
                                        case SyntaxKind.ForStatement:
                                        case SyntaxKind.UnsafeStatement:
                                        case SyntaxKind.WhileStatement:
                                            sb.Append(ConvertToSectionCode(nodebody));
                                            break;
                                        case SyntaxKind.InvocationExpression:
                                        case SyntaxKind.ExpressionStatement:
                                            if (nodebody.Contains("__tagHelper"))
                                            {
                                                switch ((str as ExpressionStatementSyntax).Expression.Kind())
                                                {
                                                    case SyntaxKind.InvocationExpression:
                                                        if (nodebody.Contains("__tagHelperExecutionContext.AddTagHelperAttribute") || nodebody.Contains("__tagHelperExecutionContext.AddHtmlAttribute"))
                                                        {
                                                            var key = nodebody.Replace("__tagHelperExecutionContext.AddTagHelperAttribute(", "").Replace(");", "").Replace("__tagHelperExecutionContext.AddHtmlAttribute(", "").Replace(");", "");
                                                            FileHelper.TagHelperContextDic.TryGetValue(key, out var tagHelperContextDic);
                                                            switch (tagHelperContextDic.Item1)
                                                            {
                                                                case "value":
                                                                    sb.Replace($"{{option{tagHelperContextDic.Item1}name}}", tagHelperContextDic.Item2);
                                                                    sb.AppendLine($"@*{key}*@");
                                                                    sb.Append("</option>");
                                                                    break;
                                                                default:
                                                                    sb.Replace($"{{form{tagHelperContextDic.Item1}name}}", tagHelperContextDic.Item2);
                                                                    sb.Append("</form>");
                                                                    sb.Replace("</form>", "</form>");
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                    case SyntaxKind.SimpleAssignmentExpression:
                                                        var taghelpwalker = new TagHelperExpressionWalker();
                                                        taghelpwalker.Visit(str);
                                                        sb.Append(taghelpwalker.sbCode);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                if((str as ExpressionStatementSyntax).Expression.Kind() is SyntaxKind.InvocationExpression)
                                                {
                                                    sb.Append(ExpressionStatement(nodebody));
                                                }
                                            }
                                            break;
                                        default:
                                            sb.Append(AppendStringBuilder(nodebody));
                                            break;
                                    }
                                }
                            }
                            else if (lambdaBody1.Body is InvocationExpressionSyntax)
                            {
                                var invocationBlock = lambdaBody1.Body as InvocationExpressionSyntax;
                                foreach (var str in invocationBlock.ArgumentList.Arguments)
                                {
                                    var nodebody = str.ToString();
                                    if (nodebody.Contains("money3.ReceiveStateId > 0"))
                                    {

                                    }
                                    switch (str.Kind())
                                    {
                                        case SyntaxKind.LocalDeclarationStatement:
                                            //sb.AppendLine($"@{{");
                                            sb.AppendLine(nodebody);
                                            //sb.AppendLine($"}}");
                                            break;
                                        case SyntaxKind.IfStatement:
                                            var ifwalker = new IfElseWalker();
                                            ifwalker.Visit(str);
                                            sb.Append(ifwalker.sbCode);
                                            break;
                                        case SyntaxKind.ForEachStatement:
                                            var foreachwalker = new ForeachWalker();
                                            foreachwalker.Visit(str);
                                            sb.Append(foreachwalker.sbCode);
                                            break;
                                        case SyntaxKind.SwitchStatement:
                                            var switchwalker = new SwitchWalker();
                                            switchwalker.Visit(str);
                                            sb.Append(switchwalker.sbCode);
                                            break;
                                        case SyntaxKind.ForStatement:
                                        case SyntaxKind.UnsafeStatement:
                                        case SyntaxKind.WhileStatement:
                                            sb.Append(ConvertToSectionCode(nodebody));
                                            break;
                                        case SyntaxKind.InvocationExpression:
                                        case SyntaxKind.ExpressionStatement:
                                            if (nodebody.Contains("__tagHelper") && str.Expression is MemberAccessExpressionSyntax)
                                            {
                                                var taghelpwalker = new TagHelperExpressionWalker();
                                                taghelpwalker.Visit(str);
                                                sb.Append(taghelpwalker.sbCode);
                                            }
                                            else
                                            {
                                                sb.Append(ExpressionStatement(nodebody));
                                            }
                                            break;
                                        default:
                                            sb.Append(AppendStringBuilder(nodebody));
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (invocationExpressionSyntax.Expression.Kind() != SyntaxKind.IdentifierName)
                    {
                        var index = -1;
                        var contains = lines.Select((content, index) => new { index, content }).Where(a => a.content.Contains(invocationExpressionSyntax.ToString())).FirstOrDefault();
                        if (contains != null)
                        {
                            index = contains.index;
                        }
                        if (lines.Select(o => o.Contains(invocationExpressionSyntax.ToString())).Any())
                        {
                            if (index == -1)
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"/*@*{lines[index]}*@*/");
                                sb.AppendLine("");
                            }
                            else
                            {
                                if (invocationExpressionSyntax.Expression.Kind() == SyntaxKind.SimpleMemberAccessExpression && invocationExpressionSyntax.Parent.Kind() != SyntaxKind.IfStatement)
                                {
                                    sb.AppendLine($"<text>");

                                    sb.AppendLine(invocationExpressionSyntax.ToString());
                                    sb.AppendLine($"</text>");
                                }
                            }
                        }
                    }
                }
            }
            if (replaceStr != null)
            {
                sb.AppendLine($"\n{replaceStr}");
            }
            else
            {
                sb.AppendLine($"\n}}");
            }

            return sb;
        }

        public static string[] Merge(string[] a, string[] b)
        {
            string[] c = new string[a.Length + b.Length];

            Array.Copy(a, 0, c, 0, a.Length);
            Array.Copy(b, 0, c, a.Length, b.Length);

            return c;
        }
    }
}
