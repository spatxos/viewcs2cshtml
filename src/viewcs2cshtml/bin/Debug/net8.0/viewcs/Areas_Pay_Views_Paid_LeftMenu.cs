using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Entity;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Service;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "d569217c32fc3466fd1f8e6ed21039552a460aca", "/Areas/Pay/Views/Paid/LeftMenu.cshtml")]
[RazorSourceChecksum("SHA1", "ca60a6e805d99ceaa3243bd1e077ef29ab48920d", "/Areas/Pay/Views/_ViewImports.cshtml")]
public class Areas_Pay_Views_Paid_LeftMenu : RazorPage<OrderPayableSearchRequest>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("value", "0", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("class", new HtmlString("form search-filter"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("id", new HtmlString("searchForm"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("action", new HtmlString("/Finance/Pay/Paid"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("method", "GET", HtmlAttributeValueStyle.DoubleQuotes);

	private string __tagHelperStringValueBuffer;

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private TagHelperScopeManager __backed__tagHelperScopeManager = null;

	private FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;

	private RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;

	private OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;

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
	public IModelExpressionProvider ModelExpressionProvider { get; private set; }

	[RazorInject]
	public IUrlHelper Url { get; private set; }

	[RazorInject]
	public IViewComponentHelper Component { get; private set; }

	[RazorInject]
	public IJsonHelper Json { get; private set; }

	[RazorInject]
	public IHtmlHelper<OrderPayableSearchRequest> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		base.Layout = null;
		_ = (WebConfig)base.ViewBag.MyWebConfig;
		vAgentUser LoginAgentUser = base.ViewBag.LoginAgentUser;
		_ = BaseService.MyProductService;
		IAgentUserService MyAgentUserService = BaseService.MyAgentUserService;
		BeginContext(288, 269, isLiteral: true);
		WriteLiteral("\r\n    <div class=\"portlet-title\">\r\n        <div class=\"caption caption-md\">\r\n            <i class=\"fa fa-search font-green\"></i>\r\n            <span class=\"caption-subject font-green bold uppercase\">搜索</span>\r\n        </div>\r\n    </div>\r\n    <div class=\"portlet-body\">\r\n");
		EndContext();
		if (!MyAgentUserService.CheckUserPower(LoginAgentUser, AgentEnum.UserRoleGroup.客服))
		{
			BeginContext(662, 12, isLiteral: true);
			WriteLiteral("            ");
			EndContext();
			BeginContext(674, 4414, isLiteral: false);
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "d569217c32fc3466fd1f8e6ed21039552a460aca7244", async delegate
			{
				BeginContext(763, 58, isLiteral: true);
				WriteLiteral("\r\n                <input type=\"hidden\" name=\"MoneyStateId\"");
				EndContext();
				BeginWriteAttribute("value", " value=\"", 821, "\"", 848, 1);
				WriteAttributeValue("", 829, base.Model.MoneyStateId, 829, 19, isLiteral: false);
				EndWriteAttribute();
				BeginContext(849, 204, isLiteral: true);
				WriteLiteral(" />\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label bold\">订单编号</label>\r\n                    <div class=\"controls\">\r\n                        <input name=\"OrderNo\"");
				EndContext();
				BeginWriteAttribute("value", " value=\"", 1053, "\"", 1075, 1);
				WriteAttributeValue("", 1061, base.Model.OrderNo, 1061, 14, isLiteral: false);
				EndWriteAttribute();
				BeginContext(1076, 429, isLiteral: true);
				WriteLiteral(" type=\"text\" placeholder=\"请输入订单编号\" class=\"form-control\" />\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label bold\">付款时间</label>\r\n                    <div class=\"controls\">\r\n                        <input class=\"form-control dateISO\" onclick=\"WdatePicker({ doubleCalendar: true, dateFmt: 'yyyy-MM-dd' })\" type=\"text\" name=\"PayableDate\"");
				EndContext();
				BeginWriteAttribute("value", " value=\"", 1505, "\"", 1532, 2);
				WriteAttributeValue("", 1513, base.Model.PayableDate, 1513, 18, isLiteral: false);
				WriteAttributeValue(" ", 1531, "", 1532, 1, isLiteral: true);
				EndWriteAttribute();
				BeginContext(1533, 253, isLiteral: true);
				WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label bold\">金 额</label>\r\n                    <div class=\"controls\">\r\n                        <input name=\"Money\"");
				EndContext();
				BeginWriteAttribute("value", " value=\"", 1786, "\"", 1806, 1);
				WriteAttributeValue("", 1794, base.Model.Money, 1794, 12, isLiteral: false);
				EndWriteAttribute();
				BeginContext(1807, 385, isLiteral: true);
				WriteLiteral(" class=\"form-control\" type=\"text\" placeholder=\"请输入订单金额\" />\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label bold\">账款类型</label>\r\n                    <div class=\"controls\">\r\n                        <select class=\"form-control\" id=\"MoneyTypeId\" name=\"MoneyTypeId\">\r\n                            ");
				EndContext();
				BeginContext(2192, 31, isLiteral: false);
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", TagMode.StartTagAndEndTag, "d569217c32fc3466fd1f8e6ed21039552a460aca10868", async delegate
				{
					BeginContext(2210, 4, isLiteral: true);
					WriteLiteral("选择类型");
					EndContext();
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<OptionTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				EndContext();
				BeginContext(2223, 2, isLiteral: true);
				WriteLiteral("\r\n");
				EndContext();
				foreach (KeyValuePair<string, string> type in EnumHelper<OrderEnum.MoneyTypeCategory>.GetDict())
				{
					BeginContext(2358, 33, isLiteral: true);
					WriteLiteral("                                <");
					EndContext();
					BeginContext(2392, 6, isLiteral: true);
					WriteLiteral("option");
					EndContext();
					BeginWriteAttribute("value", " value='", 2398, "'", 2415, 1);
					WriteAttributeValue("", 2406, type.Key, 2406, 9, isLiteral: false);
					EndWriteAttribute();
					BeginContext(2416, 1, isLiteral: true);
					WriteLiteral(" ");
					EndContext();
					BeginContext(2419, 68, isLiteral: false);
					Write((type.Key == base.Model.MoneyTypeId.ToString()) ? "selected='selected'" : "");
					EndContext();
					BeginContext(2488, 1, isLiteral: true);
					WriteLiteral(">");
					EndContext();
					BeginContext(2490, 10, isLiteral: false);
					Write(type.Value);
					EndContext();
					BeginContext(2500, 2, isLiteral: true);
					WriteLiteral("</");
					EndContext();
					BeginContext(2503, 9, isLiteral: true);
					WriteLiteral("option>\r\n");
					EndContext();
				}
				BeginContext(2543, 244, isLiteral: true);
				WriteLiteral("                        </select>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label bold\">供应商</label>\r\n                    <label class=\"pull-right\">\r\n");
				EndContext();
				BeginContext(2975, 124, isLiteral: true);
				WriteLiteral("                    </label>\r\n                    <div class=\"controls\">\r\n                        <input name=\"SupplierName\"");
				EndContext();
				BeginWriteAttribute("value", " value=\"", 3099, "\"", 3126, 1);
				WriteAttributeValue("", 3107, base.Model.SupplierName, 3107, 19, isLiteral: false);
				EndWriteAttribute();
				BeginContext(3127, 272, isLiteral: true);
				WriteLiteral(" type=\"text\" placeholder=\"请输入供应商名称\" class=\"form-control\" />\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label bold\">大巴供应商</label>\r\n                    <label class=\"pull-right\">\r\n");
				EndContext();
				BeginContext(3587, 131, isLiteral: true);
				WriteLiteral("                    </label>\r\n                    <div class=\"controls\">\r\n                        <input name=\"TrafficSupplierName\"");
				EndContext();
				BeginWriteAttribute("value", " value=\"", 3718, "\"", 3752, 1);
				WriteAttributeValue("", 3726, base.Model.TrafficSupplierName, 3726, 26, isLiteral: false);
				EndWriteAttribute();
				BeginContext(3753, 427, isLiteral: true);
				WriteLiteral(" type=\"text\" placeholder=\"请输入供应商名称\" class=\"form-control\" />\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label bold\">航班日期</label>\r\n                    <div class=\"controls\">\r\n                        <input class=\"form-control dateISO\" onclick=\"WdatePicker({ doubleCalendar: true, dateFmt: 'yyyy-MM-dd' })\" type=\"text\" name=\"CruiseDate\"");
				EndContext();
				BeginWriteAttribute("value", " value=\"", 4180, "\"", 4206, 2);
				WriteAttributeValue("", 4188, base.Model.CruiseDate, 4188, 17, isLiteral: false);
				WriteAttributeValue(" ", 4205, "", 4206, 1, isLiteral: true);
				EndWriteAttribute();
				BeginContext(4207, 320, isLiteral: true);
				WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label bold\">邮轮</label>\r\n                    <div class=\"controls\">\r\n                        <select class=\"form-control\" id=\"ShipId\" name=\"ShipId\">\r\n                            ");
				EndContext();
				BeginContext(4527, 31, isLiteral: false);
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", TagMode.StartTagAndEndTag, "d569217c32fc3466fd1f8e6ed21039552a460aca17908", async delegate
				{
					BeginContext(4545, 4, isLiteral: true);
					WriteLiteral("选择邮轮");
					EndContext();
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<OptionTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				EndContext();
				BeginContext(4558, 2, isLiteral: true);
				WriteLiteral("\r\n");
				EndContext();
				foreach (vShip ship in BaseService.MyShipService.GetPublicProductShips())
				{
					BeginContext(4693, 33, isLiteral: true);
					WriteLiteral("                                <");
					EndContext();
					BeginContext(4727, 6, isLiteral: true);
					WriteLiteral("option");
					EndContext();
					BeginWriteAttribute("value", " value='", 4733, "'", 4753, 1);
					WriteAttributeValue("", 4741, ship.ShipId, 4741, 12, isLiteral: false);
					EndWriteAttribute();
					BeginContext(4754, 1, isLiteral: true);
					WriteLiteral(" ");
					EndContext();
					BeginContext(4757, 55, isLiteral: false);
					Write((ship.ShipId == base.Model.ShipId) ? "selected='selected'" : "");
					EndContext();
					BeginContext(4813, 1, isLiteral: true);
					WriteLiteral(">");
					EndContext();
					BeginContext(4815, 13, isLiteral: false);
					Write(ship.ShipName);
					EndContext();
					BeginContext(4828, 2, isLiteral: true);
					WriteLiteral("</");
					EndContext();
					BeginContext(4831, 9, isLiteral: true);
					WriteLiteral("option>\r\n");
					EndContext();
				}
				BeginContext(4871, 210, isLiteral: true);
				WriteLiteral("                        </select>\r\n\r\n                    </div>\r\n                </div>\r\n\r\n                <button type=\"submit\" class=\"btn green btn-block\"><i class=\"fa fa-search\"></i>搜索</button>\r\n            ");
				EndContext();
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
			__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			EndContext();
			BeginContext(5088, 2, isLiteral: true);
			WriteLiteral("\r\n");
			EndContext();
		}
		BeginContext(5101, 16, isLiteral: true);
		WriteLiteral("    </div>\r\n\r\n\r\n");
		EndContext();
	}
}
