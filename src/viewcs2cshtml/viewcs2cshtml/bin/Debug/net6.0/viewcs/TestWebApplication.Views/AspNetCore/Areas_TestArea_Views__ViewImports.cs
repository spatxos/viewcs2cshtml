using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "1aa5ad637b12fd6f9ca502ef7db14293e5cec4d7", "/Areas/TestArea/Views/_ViewImports.cshtml")]
public class Areas_TestArea_Views__ViewImports : RazorPage<dynamic>
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
	}
}
