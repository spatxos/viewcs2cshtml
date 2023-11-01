using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "d8ddb6bffa5a9b264bf8f89038bf03c234083fd3", "/Views/Home/Privacy.cshtml")]
[RazorSourceChecksum("SHA1", "1aa5ad637b12fd6f9ca502ef7db14293e5cec4d7", "/Views/_ViewImports.cshtml")]
public class Views_Home_Privacy : RazorPage<dynamic>
{
	[RazorInject]
	public IModelExpressionProvider ModelExpressionProvider { get; private set; } = null;


	[RazorInject]
	public IUrlHelper Url { get; private set; } = null;


	[RazorInject]
	public IViewComponentHelper Component { get; private set; } = null;


	[RazorInject]
	public IJsonHelper Json { get; private set; } = null;


	[RazorInject]
	public IHtmlHelper<dynamic> Html { get; private set; } = null;


	public override async Task ExecuteAsync()
	{
		base.ViewData["Title"] = "Privacy Policy";
		WriteLiteral("<h1>");
		Write(base.ViewData["Title"]);
		WriteLiteral("</h1>\r\n\r\n<p>Use this page to detail your site's privacy policy.</p>\r\n");
	}
}
