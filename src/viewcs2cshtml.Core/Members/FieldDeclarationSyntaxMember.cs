using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace viewcs2cshtml.Core.Members
{
    public class FieldDeclarationSyntaxMember
    {
        public StringBuilder sbCode = new StringBuilder();
        public FieldDeclarationSyntaxMember()
        {
            sbCode = new StringBuilder();
        }

        public void Visit(FieldDeclarationSyntax fieldDeclarationSyntax)
        {
            var variableDeclarator = fieldDeclarationSyntax?.Declaration.Variables.FirstOrDefault();

            if (variableDeclarator != null && variableDeclarator.Initializer != null)
            {
                string fieldName = variableDeclarator.Identifier.Text;
                if (variableDeclarator.Initializer.Value != null && variableDeclarator.Initializer.Value.ChildNodes().Any())
                {
                    string attributeName = variableDeclarator.Initializer.Value.ChildNodes().First().ToString();
                    foreach (ArgumentListSyntax argumentListSyntax in variableDeclarator.Initializer.Value.ChildNodes().ToList().Where(o => o is ArgumentListSyntax))
                    {
                        var args = argumentListSyntax.Arguments.ToList();
                        Console.WriteLine($"Field Name: {fieldName}");
                        Console.WriteLine($"Attribute Name: {attributeName}");
                        if (args.Count >= 2)
                        {
                            if (args[1].ToString().Contains("HtmlString"))
                            {
                                // 使用正则表达式匹配并提取内容
                                string pattern = @"\""([^\""]+)\""";
                                Match match = Regex.Match(args[1].ToString(), pattern);

                                if (match.Success && match.Groups.Count > 1)
                                {
                                    // 提取第一个捕获组的值
                                    string extractedValue = match.Groups[1].Value;
                                    Console.WriteLine($"提取的值: {extractedValue}");
                                    FileHelper.TagHelperContextDic.Add(fieldName, (args[0].ToString().Replace("\"", ""), extractedValue.Replace("\"", "")));
                                    sbCode.AppendLine($"// {fieldName} {args[0]} {extractedValue}");
                                }
                                else
                                {
                                    Console.WriteLine("未找到匹配的内容");
                                    sbCode.AppendLine($"// {fieldName} {args[0]} 未找到匹配的内容");
                                }
                            }
                            else
                            {
                                FileHelper.TagHelperContextDic.Add(fieldName, (args[0].ToString().Replace("\"",""), args[1].ToString().Replace("\"", "")));
                                sbCode.AppendLine($"// {fieldName} {args[0]} {args[1]}");
                            }
                            Console.WriteLine($"Attribute Value: {args[0]},{args[1]}");
                        }
                    }
                }
            }
        }
    }
}
