using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace viewcs2cshtml.Core.Walkers
{
    public class IfElseWalker : CSharpSyntaxWalker
    {
        public StringBuilder sbCode = new StringBuilder();
        Regex regex = new Regex("\n");
        public IfElseWalker()
        {
            sbCode = new StringBuilder();
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            // Process the If part
            Console.WriteLine(node.Condition);

            if (node.Statement is BlockSyntax block)
            {
                var elsestr = "";
                if (node.Parent.Kind() == SyntaxKind.ElseClause)
                {
                    elsestr = "else ";
                }
                // Process the If block
                Console.WriteLine(block);
                sbCode.Append(FileHelper.ConvertToSectionCode("DefineSection(\"if\", =>" + block.ToString(), $"{elsestr}if({node.Condition.ToString()})\n"));
            }

            if (node.Else != null)
            {
                // 如果有 else 部分
                var elseClause = node.Else;
                if (elseClause.Statement is IfStatementSyntax elseIf)
                {
                    if (elseIf.Statement is BlockSyntax elseIfBlock)
                    {
                        // Process the else if block
                        Console.WriteLine(elseIfBlock);
                        //sbCode.Append(FileHelper.ConvertToSectionCode("DefineSection(\"if\", =>" + elseIfBlock.ToString(), $"else if({elseIf.Condition})\n"));
                    }
                    //sbCode.Append(FileHelper.ConvertToSectionCode(elseIf.Statement.Parent.ToString(), " else " + elseIf.ToString().Replace(elseIf.Statement.ToString(), "")));
                    // 处理 else if 部分
                    Console.WriteLine($"ELSE IF Part: {elseIf.Statement}");
                    //if(elseIf.Statement.Parent.ToString().Contains("else if"))
                    //{
                    //    VisitIfStatement(elseIf);
                    //}
                    //VisitIfStatement(elseIf);
                }
                else if (node.Else.Statement is BlockSyntax elseBlock)
                {
                    var guid = Guid.NewGuid().ToString();
                    //sbCode.Append(FileHelper.ConvertToSectionCode(node.ToString().Replace("else", $"if(\"{guid}\".Equals(\"{guid}\"))")).Replace($"@if(\"{guid}\".Equals(\"{guid}\"))", "else"));
                    sbCode.Append(FileHelper.ConvertToSectionCode("DefineSection(\"if\", =>" + elseBlock.ToString(), "else \n"));

                    // 处理 else 部分
                    Console.WriteLine($"ELSE Part: {elseClause.Statement}");
                }
            }
            else
            {
                // 处理 if 部分
                Console.WriteLine("IF part:");
                Console.WriteLine(node.Condition);
                base.VisitIfStatement(node);

            }

            sbCode = sbCode.Replace("@else if", " else if ").Replace("@else", " else ");
            base.VisitIfStatement(node);
        }

        //public override void VisitElseClause(ElseClauseSyntax node)
        //{
        //    var code = node.ToString();
        //    if (code.Contains("else if"))
        //    {

        //    }
        //    if (!code.Contains("else if"))
        //    {
        //        var guid = Guid.NewGuid().ToString();
        //        sbCode.Append(FileHelper.ConvertToSectionCode(code.Replace("else", $"if(\"{guid}\".Equals(\"{guid}\"))")).Replace($"@if(\"{guid}\".Equals(\"{guid}\"))", "else"));
        //    }
        //    sbCode = sbCode.Replace(" else \n@if", " else if ");
        //    // 处理 else 部分
        //    Console.WriteLine("ELSE part:");
        //    Console.WriteLine(node.Statement);
        //    base.VisitElseClause(node);
        //}
    }
}
