using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viewcs2cshtml.Core.Walkers;
using viewcs2cshtml.Core.Tools;

namespace viewcs2cshtml.Core.Members
{
    public class MethodDeclarationSyntaxMember
    {
        public StringBuilder sbCode = new StringBuilder();

        public string TagHelperContext { get; private set; }

        public MethodDeclarationSyntaxMember()
        {
            sbCode = new StringBuilder();
        }

        public void Visit(MethodDeclarationSyntax methodDeclarationSyntax)
        {
            var body = methodDeclarationSyntax.Body;
            var nodes = body.Statements.ToList();
            foreach (var node in nodes)
            {
                var nodebody = node.ToString();
                if (nodebody.Contains("table-responsive"))
                {

                }
                switch (node.Kind())
                {
                    case SyntaxKind.LocalDeclarationStatement:
                        sbCode.AppendLine($"@{{");
                        sbCode.AppendLine(nodebody);
                        sbCode.AppendLine($"}}");
                        break;
                    case SyntaxKind.IfStatement:
                        var ifwalker = new IfElseWalker();
                        ifwalker.Visit(node);
                        sbCode.Append(ifwalker.sbCode);
                        break;
                    case SyntaxKind.ForEachStatement:
                        var foreachwalker = new ForeachWalker();
                        foreachwalker.Visit(node);
                        sbCode.Append(foreachwalker.sbCode);
                        break;
                    case SyntaxKind.SwitchStatement:
                        var switchwalker = new SwitchWalker();
                        switchwalker.Visit(node);
                        sbCode.Append(switchwalker.sbCode);
                        break;
                    case SyntaxKind.ForStatement:
                    case SyntaxKind.UnsafeStatement:
                    case SyntaxKind.WhileStatement:
                        sbCode.Append(StatementCodeTransformHelper.ConvertToSectionCode(nodebody));
                        break;
                    case SyntaxKind.InvocationExpression:
                        if (nodebody.Contains("__tagHelper"))
                        {
                            var taghelpwalker = new TagHelperExpressionWalker();
                            taghelpwalker.Visit(node);
                            sbCode.Append(taghelpwalker.sbCode);
                        }
                        break;
                    case SyntaxKind.ExpressionStatement:
                        sbCode.Append(StatementCodeTransformHelper.ExpressionStatement(nodebody));
                        break;
                }
            }
        }
    }
}
