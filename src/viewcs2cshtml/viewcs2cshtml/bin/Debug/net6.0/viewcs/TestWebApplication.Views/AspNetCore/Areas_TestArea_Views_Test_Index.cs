using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "ecb18dc2cb517c4de3783a998fc95051b7cd89a0", "/Areas/TestArea/Views/Test/Index.cshtml")]
[RazorSourceChecksum("SHA1", "1aa5ad637b12fd6f9ca502ef7db14293e5cec4d7", "/Areas/TestArea/Views/_ViewImports.cshtml")]
public class Areas_TestArea_Views_Test_Index : RazorPage<dynamic>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("href", new HtmlString("~/css/site.css"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("rel", new HtmlString("stylesheet"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("href", new HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("href", new HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("src", new HtmlString("~/lib/jquery/dist/jquery.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("src", new HtmlString("~/lib/jquery/dist/jquery.js"), HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager = null;

	private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

	private TagHelperScopeManager __tagHelperScopeManager
	{
		get
		{
			if (__backed__tagHelperScopeManager == null)
			{
				__backed__tagHelperScopeManager = new TagHelperScopeManager(base.StartTagHelperWritingScope, base.EndTagHelperWritingScope);
			}
			return __backed__tagHelperScopeManager;
		}
	}

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
		base.ViewData["Title"] = "Test Page";
		DefineSection("styles", (RenderAsyncDelegate)async delegate
		{
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", TagMode.SelfClosing, "ecb18dc2cb517c4de3783a998fc95051b7cd89a05719", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", TagMode.SelfClosing, "ecb18dc2cb517c4de3783a998fc95051b7cd89a06897", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", TagMode.SelfClosing, "ecb18dc2cb517c4de3783a998fc95051b7cd89a08075", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n");
		});
		WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome Test</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n</div>\r\n\r\n");
		DefineSection("scripts", (RenderAsyncDelegate)async delegate
		{
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "ecb18dc2cb517c4de3783a998fc95051b7cd89a09617", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "ecb18dc2cb517c4de3783a998fc95051b7cd89a010716", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n");
		});
	}
}
