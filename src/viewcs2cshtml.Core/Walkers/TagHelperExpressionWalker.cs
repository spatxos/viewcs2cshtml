using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            sbCode.Append(FileHelper.ConvertToSectionCode("DefineSection(\"if\", =>" + TagHelperContext, " _taghelper \n"));
            base.VisitAnonymousMethodExpression(node);
        }
    }
}
