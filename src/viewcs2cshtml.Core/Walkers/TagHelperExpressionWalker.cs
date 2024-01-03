using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viewcs2cshtml.Core.Tools;

namespace viewcs2cshtml.Core.Walkers
{
    public class TagHelperExpressionWalker : CSharpSyntaxWalker
    {
        public StringBuilder sbCode = new StringBuilder();

        public string TagHelperContext { get; private set; }

        public TagHelperExpressionWalker() : base(SyntaxWalkerDepth.Trivia)
        {
            sbCode = new StringBuilder();
        }

        public override void VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            TagHelperContext = node.Body?.ToString();
            if (node.Parent.Parent.Parent.ToString().Contains("__tagHelperScopeManager.Begin(\"form\""))
            {
                sbCode.AppendLine("<form class=\"{formclassname}\" id=\"{formidname}\" action=\"{formactionname}\" method=\"{formmethodname}\">\r\n");
            }
            else if (node.Parent.Parent.Parent.ToString().Contains("__tagHelperScopeManager.Begin(\"option\""))
            {
                sbCode.AppendLine("<option value=\"{optionvaluename}\">\r\n");
            }
            sbCode.Append(StatementCodeTransformHelper.ConvertToSectionCode("DefineSection(\"if\", =>" + TagHelperContext, "}\r\n@"));
            base.VisitAnonymousMethodExpression(node);
        }
    }
}
