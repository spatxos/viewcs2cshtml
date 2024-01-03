using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viewcs2cshtml.Core.Tools;

namespace viewcs2cshtml.Core.Walkers
{
    public class SwitchWalker : CSharpSyntaxWalker
    {
        public StringBuilder sbCode = new StringBuilder();
        public SwitchWalker()
        {
            sbCode = new StringBuilder();
        }
        public override void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            sbCode.AppendLine($"switch({node.Expression.ToString()})");
            sbCode.AppendLine("{");
            foreach (var switchSection in node.Sections)
            {
                var label = "";
                if (switchSection.Labels.Count > 0 && switchSection.Labels.First() is CaseSwitchLabelSyntax caseLabel)
                {
                    label = caseLabel.ToString();
                }
                else
                {
                    label = "default:";
                }
                var removeBreakCase = switchSection.Statements.Where(o => o.GetType() != typeof(BreakStatementSyntax)).FirstOrDefault();
                if (removeBreakCase != null)
                {
                    var replacestr = removeBreakCase.ToString();
                    var body = @$" {{" +
                               "\n" + switchSection.Statements.ToString().Replace(replacestr, "") +
                               "\n})\n";
                    var newblockStr = "DefineSection(\"if\", =>" +
                                        body;
                    sbCode.Append(StatementCodeTransformHelper.ConvertToSectionCode(newblockStr, label, "").Replace($"@{label}", $"{label}\n"));
                }
                else
                {

                }
            }
            sbCode.AppendLine("}");
            base.VisitSwitchStatement(node);
        }
    }
}
