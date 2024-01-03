using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using System.Xml.Linq;

namespace viewcs2cshtml.Core.Walkers
{
    public class LayoutWalker : CSharpSyntaxWalker
    {
        public StringBuilder sbCode = new StringBuilder();

        public string TagHelperContext { get; private set; }

        public LayoutWalker() : base(SyntaxWalkerDepth.Trivia)
        {
            sbCode = new StringBuilder();
        }

        public void VisitClassDeclarationSyntax(SyntaxList<AttributeListSyntax> nodes)
        {
            foreach (var _layout in nodes)
            {
                // 假设属性列表中只有一个属性
                AttributeSyntax razorSourceChecksumAttribute = _layout.Attributes.FirstOrDefault();

                if (razorSourceChecksumAttribute != null)
                {
                    // 检查属性的类型是否为 RazorSourceChecksum
                    if (razorSourceChecksumAttribute.Name is SimpleNameSyntax simpleName && simpleName.Identifier.Text == "RazorSourceChecksum")
                    {
                        // 获取属性参数的值
                        if (razorSourceChecksumAttribute.ArgumentList != null &&
                            razorSourceChecksumAttribute.ArgumentList.Arguments.Count >= 3)
                        {
                            string algorithmType = razorSourceChecksumAttribute.ArgumentList.Arguments[0].Expression.ToString();
                            string hashValue = razorSourceChecksumAttribute.ArgumentList.Arguments[1].Expression.ToString();
                            string filePath = razorSourceChecksumAttribute.ArgumentList.Arguments[2].Expression.ToString();

                            Console.WriteLine($"AlgorithmType: {algorithmType}, HashValue: {hashValue}, FilePath: {filePath}");

                            sbCode.AppendLine($"// Layout = {filePath}");
                        }
                    }
                }
            }
        }
    }
}
