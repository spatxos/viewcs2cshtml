using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viewcs2cshtml.Core.Walkers
{
    public class ForeachWalker : CSharpSyntaxWalker
    {
        public StringBuilder sbCode = new StringBuilder();
        public ForeachWalker()
        {
            sbCode = new StringBuilder();
        }
        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            var foreachBodyStr = node.ToString().Replace(node.Statement.ToString(), "");
            //sbCode.AppendLine(foreachBodyStr);
            if (node.Statement.Kind() == SyntaxKind.Block)
            {
                var newblockStr = "DefineSection(\"if\", =>" + node.Statement.ToString();
                sbCode.Append(FileHelper.ConvertToSectionCode(newblockStr, foreachBodyStr));
            }
            Console.WriteLine($"Foreach Part: {node}");

            base.VisitForEachStatement(node);
        }
    }

}
