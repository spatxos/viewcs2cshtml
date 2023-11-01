using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using TestWebApplication.Models;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "d6a5625cc8fb4476f348b0fe9041c550465d8bf9", "/Views/Shared/Error.cshtml")]
[RazorSourceChecksum("SHA1", "1aa5ad637b12fd6f9ca502ef7db14293e5cec4d7", "/Views/_ViewImports.cshtml")]
public class Views_Shared_Error : RazorPage<ErrorViewModel>
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
	public IHtmlHelper<ErrorViewModel> Html { get; private set; } = null;


	public override async Task ExecuteAsync()
	{
		base.ViewData["Title"] = "Error";
		WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n\r\n");
		if (base.Model.ShowRequestId)
		{
			WriteLiteral("    <p>\r\n        <strong>Request ID:</strong> <code>");
			Write(base.Model.RequestId);
			WriteLiteral("</code>\r\n    </p>\r\n");
		}
		WriteLiteral("\r\n<h3>Development Mode</h3>\r\n<p>\r\n    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.\r\n</p>\r\n<p>\r\n    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>\r\n    It can result in displaying sensitive information from exceptions to end users.\r\n    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>\r\n    and restarting the app.\r\n</p>\r\n");
	}
}
