# viewcs2cshtml
将.View.dll文件反编译出来的*Views*.cs文件转换成.cshtml

先使用反编译工具将.View.dll文件反编译放入文件夹，然后将文件夹整体复制进\src\viewcs2cshtml\viewcs2cshtml\bin\Debug\net6.0\viewcs
复制完成之后运行程序，即可在复制进去的文件夹中看到Views/Areas文件夹

暂不支持有asp-开头属性的控件

# 例子
还原前：
```
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using Service;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "d8a8ee2ca67cc5ce9980cdaac759455a319671bc", "/Views/Home/Index.cshtml")]
[RazorSourceChecksum("SHA1", "1adfc0184e63bea883d1e67d153e30eb9b879251", "/Views/_ViewImports.cshtml")]
public class Views_Home_Index : RazorPage<dynamic>
{
	[RazorInject]
	public IModelExpressionProvider ModelExpressionProvider { get; private set; }

	[RazorInject]
	public IUrlHelper Url { get; private set; }

	[RazorInject]
	public IViewComponentHelper Component { get; private set; }

	[RazorInject]
	public IJsonHelper Json { get; private set; }

	[RazorInject]
	public IHtmlHelper<dynamic> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WebConfig MyWebConfig = base.ViewBag.MyWebConfig;
		vAgentUser LoginAgentUser = base.ViewBag.LoginAgentUser;
		IProductService MyProductService = BaseService.MyProductService;
		base.ViewBag.Title = "平台首页";
		BeginContext(201, 2, isLiteral: true);
		WriteLiteral("\r\n");
		EndContext();
		DefineSection("styles", (RenderAsyncDelegate)async delegate
		{
			BeginContext(219, 162, isLiteral: true);
			WriteLiteral("\r\n    <link href=\"/Scripts/owl-carousel/owl.carousel.css\" rel=\"stylesheet\" />\r\n    <link href=\"/Scripts/owl-carousel/owl.theme.css\" rel=\"stylesheet\" />\r\n    <link");
			EndContext();
			BeginWriteAttribute("href", " href=\"", 381, "\"", 435, 2);
			WriteAttributeValue("", 388, MyWebConfig.Api_Static, 388, 25, isLiteral: false);
			WriteAttributeValue("", 413, "/Contents/calendar.css", 413, 22, isLiteral: true);
			EndWriteAttribute();
			BeginContext(436, 22, isLiteral: true);
			WriteLiteral(" rel=\"stylesheet\" />\r\n");
			EndContext();
		});
		BeginContext(461, 2, isLiteral: true);
		WriteLiteral("\r\n");
		EndContext();
		DefineSection("title", (RenderAsyncDelegate)async delegate
		{
			BeginContext(478, 20, isLiteral: true);
			WriteLiteral("\r\n    <h1>\r\n        ");
			EndContext();
			BeginContext(499, 13, isLiteral: false);
			Write(base.ViewBag.Title);
			EndContext();
			BeginContext(512, 42, isLiteral: true);
			WriteLiteral("\r\n        <small class=\"pull-right\">热线电话: ");
			EndContext();
			BeginContext(556, 21, isLiteral: false);
			Write(MyWebConfig.YlsdaiTel);
			EndContext();
			BeginContext(578, 21, isLiteral: true);
			WriteLiteral("</small>\r\n    </h1>\r\n");
			EndContext();
		});
		BeginContext(602, 128, isLiteral: true);
		WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"selsearch hidden-xs hidden-sm\" id=\"divSearch\">\r\n            ");
		EndContext();
		BeginContext(731, 57, isLiteral: false);
		Write(Html.Action("Cache", "Search", new
		{
			controller = "home"
		}));
		EndContext();
		BeginContext(788, 2772, isLiteral: true);
		WriteLiteral("\r\n        </div>\r\n        <div class=\"selright\">\r\n            <div class=\"login-content\">\r\n                <div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">\r\n                    <!-- Indicators -->\r\n                    <ol class=\"carousel-indicators\">\r\n                        <li data-target=\"#myCarousel\" data-slide-to=\"0\" class=\"active\"></li>\r\n                        <li data-target=\"#myCarousel\" data-slide-to=\"1\"></li>\r\n                        <li data-target=\"#myCarousel\" data-slide-to=\"2\"></li>\r\n                        <li data-target=\"#myCarousel\" data-slide-to=\"3\"></li>\r\n                    </ol>\r\n                    <div class=\"carousel-inner\" role=\"listbox\" style=\"\">\r\n                        <div class=\"item active\">\r\n                            <img src=\"http://www.yiyout.com/Images/front1.jpg\" alt=\"Third slide\">\r\n                        </div>\r\n                        <div class=\"item\">\r\n                            <img src=\"http://www.yiyout.com/Images/front2.jpg\" alt=\"First slide\">");
		WriteLiteral("\r\n                        </div>\r\n                        <div class=\"item\">\r\n                            <img src=\"http://www.yiyout.com/Images/front3.jpg\" alt=\"First slide\">\r\n                        </div>\r\n                        <div class=\"item\">\r\n                            <img src=\"http://www.yiyout.com/Images/front4.jpg\" alt=\"First slide\">\r\n                        </div>\r\n                    </div>\r\n                    <a class=\"left carousel-control\" href=\"#myCarousel\" role=\"button\" data-slide=\"prev\">\r\n                        <span class=\"glyphicon glyphicon-chevron-left\"></span>\r\n                        <span class=\"sr-only\">Previous</span>\r\n                    </a>\r\n                    <a class=\"right carousel-control\" href=\"#myCarousel\" role=\"button\" data-slide=\"next\">\r\n                        <span class=\"glyphicon glyphicon-chevron-right\"></span>\r\n                        <span class=\"sr-only\">Next</span>\r\n                    </a>\r\n                </div>\r\n                <!-- /.carousel -->\r\n   ");
		WriteLiteral("         </div>\r\n\r\n            <div class=\"row margin-top-10\">\r\n                <div class=\"col-md-12\">\r\n                    <div class=\"tabbable-line mytabbable\">\r\n                        <ul class=\"nav nav-tabs\">\r\n                            <li class=\"active\"><a data-toggle=\"tab\" href=\"#tas1\">热门推荐</a></li>\r\n                            <li><a data-toggle=\"tab\" href=\"#tas2\">直订航线</a></li>\r\n                            <li><a data-toggle=\"tab\" href=\"#tas3\">套装长线</a></li>\r\n                        </ul>\r\n                    </div>\r\n                    <div class=\"tab-content\">\r\n                        <div class=\"tab-pane active\" id=\"tas1\">\r\n                            <div class=\"row\">\r\n                                ");
		EndContext();
		BeginContext(3561, 106, isLiteral: false);
		Write(Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: true, isSuit: false, isControlCabin: false)));
		EndContext();
		BeginContext(3667, 207, isLiteral: true);
		WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"tab-pane\" id=\"tas2\">\r\n                            <div class=\"row\">\r\n                                ");
		EndContext();
		BeginContext(3875, 106, isLiteral: false);
		Write(Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: false, isSuit: false, isControlCabin: true)));
		EndContext();
		BeginContext(3981, 207, isLiteral: true);
		WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"tab-pane\" id=\"tas3\">\r\n                            <div class=\"row\">\r\n                                ");
		EndContext();
		BeginContext(4189, 106, isLiteral: false);
		Write(Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: false, isSuit: true, isControlCabin: false)));
		EndContext();
		BeginContext(4295, 673, isLiteral: true);
		WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<!--邮轮日历-->\r\n<div class=\"row\" id=\"calendar\" v-html=\"myhtml\"></div>\r\n\r\n<!--预订流程图片-->\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 col-sm-12\">\r\n        <div class=\"con_procedure hidden-xs\">\r\n            <div class=\"procedure\"></div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<!--邮轮百科-->\r\n<h2 class=\"margin-bottom-30 margin-top-0\">\r\n    邮轮百科 <a class=\"h4 pull-right\" href=\"/BaiKe\">查看更多</a>\r\n</h2>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div id=\"owl-demo\" class=\"owl-carousel\">\r\n");
		EndContext();
		IList<vArticle> arts = ((IQueryOver<vArticle>)(object)new DbHelper<vArticle>().GetQueryOver().Where((ICriterion)(object)Expression.Sql(" this_.CategoryId in (select CategoryId from Category where ParentId=141) and this_.ArticleImg!=''"))).Take(20).List();
		foreach (vArticle art in arts)
		{
			BeginContext(5301, 82, isLiteral: true);
			WriteLiteral("                    <div class=\"item\">\r\n                        <a target=\"_blank\"");
			EndContext();
			BeginWriteAttribute("href", " href=\"", 5383, "\"", 5418, 2);
			WriteAttributeValue("", 5390, "/BaiKe/Detail/", 5390, 14, isLiteral: true);
			WriteAttributeValue("", 5404, art.ArticleId, 5404, 14, isLiteral: false);
			EndWriteAttribute();
			BeginContext(5419, 72, isLiteral: true);
			WriteLiteral(">\r\n                            <img class=\"lazyOwl rollerimg\" data-src=\"");
			EndContext();
			BeginContext(5493, 103, isLiteral: false);
			Write(MyWebConfig.ImgUrl + (string.IsNullOrWhiteSpace(art.ArticleImg) ? "/images/noimg.jpg" : art.ArticleImg));
			EndContext();
			BeginContext(5597, 53, isLiteral: true);
			WriteLiteral("\" />\r\n                            <div class=\"title\">");
			EndContext();
			BeginContext(5651, 16, isLiteral: false);
			Write(art.ArticleTitle);
			EndContext();
			BeginContext(5667, 66, isLiteral: true);
			WriteLiteral("</div>\r\n                        </a>\r\n                    </div>\r\n");
			EndContext();
		}
		BeginContext(5767, 207, isLiteral: true);
		WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n<h2 class=\"margin-bottom-30 margin-top-0\">邮轮游记 <a class=\"h4 pull-right\" href=\"/BaiKe/List/27\">查看更多</a></h2>\r\n<div class=\"row search-page search-content-3 text-center\">\r\n");
		EndContext();
		IList<vArticle> travelnotes = ((IQueryOver<vArticle>)(object)((QueryOverOrderBuilderBase<IQueryOver<vArticle, vArticle>, vArticle, vArticle>)(object)new DbHelper<vArticle>().GetQueryOver().Where((Expression<Func<vArticle, bool>>)((vArticle o) => o.ArticleState == 2 && o.CategoryId == 27)).OrderBy((Expression<Func<vArticle, object>>)((vArticle o) => o.ArticleId))).Desc).Take(4).List();
		foreach (vArticle note in travelnotes)
		{
			BeginContext(6238, 14, isLiteral: true);
			WriteLiteral("            <a");
			EndContext();
			BeginWriteAttribute("href", " href=\"", 6252, "\"", 6288, 2);
			WriteAttributeValue("", 6259, "/BaiKe/Detail/", 6259, 14, isLiteral: true);
			WriteAttributeValue("", 6273, note.ArticleId, 6273, 15, isLiteral: false);
			EndWriteAttribute();
			BeginContext(6289, 179, isLiteral: true);
			WriteLiteral(">\r\n                <div class=\"col-md-3\">\r\n                    <div class=\"tile-container\">\r\n                        <div class=\"tile-thumbnail\">\r\n                            <img");
			EndContext();
			BeginWriteAttribute("src", " src=\"", 6468, "\"", 6582, 1);
			WriteAttributeValue("", 6474, MyWebConfig.ImgUrl + (string.IsNullOrWhiteSpace(note.ArticleImg) ? "/images/noimg.jpg" : note.ArticleImg), 6474, 108, isLiteral: false);
			EndWriteAttribute();
			BeginContext(6583, 204, isLiteral: true);
			WriteLiteral(" class=\"rollerimg\">\r\n                        </div>\r\n                        <div class=\"tile-title\">\r\n                            <h4 class=\"bold\" style=\"height: 24px;\">\r\n                                ");
			EndContext();
			BeginContext(6788, 17, isLiteral: false);
			Write(note.ArticleTitle);
			EndContext();
			BeginContext(6805, 125, isLiteral: true);
			WriteLiteral("\r\n                            </h4>\r\n                            <div class=\"tile-desc\">\r\n                                <p>");
			EndContext();
			BeginContext(6931, 17, isLiteral: false);
			Write(note.ArticleIntro);
			EndContext();
			BeginContext(6948, 144, isLiteral: true);
			WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </a>\r\n");
			EndContext();
		}
		BeginContext(7110, 10, isLiteral: true);
		WriteLiteral("</div>\r\n\r\n");
		EndContext();
		DefineSection("scripts", (RenderAsyncDelegate)async delegate
		{
			BeginContext(7137, 317, isLiteral: true);
			WriteLiteral("\r\n    <script type=\"text/javascript\" src=\"/Scripts/owl-carousel/owl.carousel.min.js\"></script>\r\n    <script type=\"text/javascript\" src=\"/Scripts/Search.js?v=1\"></script>\r\n    <script type=\"text/javascript\">\r\n        var calendar = new Vue({\r\n            el: \"#calendar\",\r\n            data: {\r\n                areaid: ");
			EndContext();
			BeginContext(7455, 25, isLiteral: false);
			Write(MyWebConfig.DefaultAreaId);
			EndContext();
			BeginContext(7480, 27, isLiteral: true);
			WriteLiteral(",\r\n                month: '");
			EndContext();
			BeginContext(7508, 32, isLiteral: false);
			Write(DateTime.Now.ToString("yyyy-MM"));
			EndContext();
			BeginContext(7540, 28, isLiteral: true);
			WriteLiteral("',\r\n                today: '");
			EndContext();
			BeginContext(7569, 35, isLiteral: false);
			Write(DateTime.Now.ToString("yyyy-MM-dd"));
			EndContext();
			BeginContext(7604, 28, isLiteral: true);
			WriteLiteral("',\r\n                userid: ");
			EndContext();
			BeginContext(7633, 21, isLiteral: false);
			Write(LoginAgentUser.UserId);
			EndContext();
			BeginContext(7654, 30, isLiteral: true);
			WriteLiteral(",\r\n                userguid: '");
			EndContext();
			BeginContext(7686, 23, isLiteral: false);
			Write(LoginAgentUser.UserGuid);
			EndContext();
			BeginContext(7710, 801, isLiteral: true);
			WriteLiteral("',\r\n                myhtml: ''\r\n            },\r\n            mounted: function() {\r\n                setTimeout(function() {\r\n                    calendar.GetCalendar();\r\n                    },\r\n                600);\r\n            },\r\n            watch: {\r\n                month: function() {\r\n                    calendar.GetCalendar();\r\n                },\r\n                areaid: function() {\r\n                    calendar.GetCalendar();\r\n                }\r\n            },\r\n            computed: {\r\n            \r\n            },\r\n            methods: {\r\n                //获取日历\r\n                GetCalendar: function() {\r\n                    $.ajax({\r\n                        cache: false,\r\n                        type: \"Post\",\r\n                        dataType: \"html\",\r\n                        url: \"");
			EndContext();
			BeginContext(8513, 23, isLiteral: false);
			Write(MyWebConfig.Api_Gateway);
			EndContext();
			BeginContext(8537, 1428, isLiteral: true);
			WriteLiteral("/MyProduct/Show/Calendar?userguid=\" + calendar.userguid,\r\n                        data: {\r\n                            CruiseMonth: calendar.month,\r\n                            AreaId: calendar.areaid\r\n                        },\r\n                        beforeSend: function() {\r\n                            //vm.isLoading = true;\r\n                        },\r\n                        success: function(data) {\r\n                            calendar.myhtml = (data);\r\n                            setTimeout(function() {\r\n                                MyScript.PageInit();\r\n                                    $(\"#calendarMonth\").change(function() { calendar.month = $(this).val(); });\r\n                                },\r\n                            600);\r\n                        }\r\n                    });\r\n                }\r\n            }\r\n        });\r\n\r\n        function random(owlSelector) {\r\n            owlSelector.children().sort(function () {\r\n                return Math.round(Math.random()) - 0.5;\r\n            })");
			WriteLiteral(".each(function () {\r\n                $(this).appendTo(owlSelector);\r\n            });\r\n        }\r\n\r\n        $(function () {\r\n            $(\"#owl-demo\").owlCarousel({\r\n                beforeInit: function(elem) {\r\n                    random(elem);\r\n                },\r\n                items: 4,\r\n                lazyLoad: true,\r\n                autoPlay: true\r\n            });\r\n        });\r\n    </script>\r\n");
			EndContext();
		});
	}
}
```

还原后
```
WebConfig MyWebConfig = ViewBag.MyWebConfig;
vAgentUser LoginAgentUser = ViewBag.LoginAgentUser;
IProductService MyProductService = BaseService.MyProductService;
ViewBag.Title = "平台首页";

@section styles{

    <link href="/Scripts/owl-carousel/owl.carousel.css" rel="stylesheet" />
    <link href="/Scripts/owl-carousel/owl.theme.css" rel="stylesheet" />
    <link href="@(MyWebConfig.Api_Static)/Contents/calendar.css" rel="stylesheet" />
}

@section title{

    <h1>
        @ViewBag.Title
        <small class="pull-right">热线电话: @MyWebConfig.YlsdaiTel</small>
    </h1>
}
<div class="row">
    <div class="col-md-12">
        <div class="selsearch hidden-xs hidden-sm" id="divSearch">
            @Html.Action("Cache", "Search", new
		{
			controller = "home"
		})Html.Action("Cache", "Search", new
		{
			controller = "home"
		})
        </div>
        <div class="selright">
            <div class="login-content">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                        <li data-target="#myCarousel" data-slide-to="3"></li>
                    </ol>
                    <div class="carousel-inner" role="listbox" style=">
                        <div class="item active">
                            <img src="http://www.yiyout.com/Images/front1.jpg" alt="Third slide">
                        </div>
                        <div class="item">
                            <img src="http://www.yiyout.com/Images/front2.jpg" alt="First slide">
                        </div>
                        <div class="item">
                            <img src="http://www.yiyout.com/Images/front3.jpg" alt="First slide">
                        </div>
                        <div class="item">
                            <img src="http://www.yiyout.com/Images/front4.jpg" alt="First slide">
                        </div>
                    </div>
                    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
                <!-- /.carousel -->
            </div>

            <div class="row margin-top-10">
                <div class="col-md-12">
                    <div class="tabbable-line mytabbable">
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#tas1">热门推荐</a></li>
                            <li><a data-toggle="tab" href="#tas2">直订航线</a></li>
                            <li><a data-toggle="tab" href="#tas3">套装长线</a></li>
                        </ul>
                    </div>
                    <div class="tab-content">
                        <div class="tab-pane active" id="tas1">
                            <div class="row">
                                @Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: true, isSuit: false, isControlCabin: false))Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: true, isSuit: false, isControlCabin: false))MyProductService.GetSpecialProducts(isSpecial: true, isSuit: false, isControlCabin: false)
                            </div>
                        </div>
                        <div class="tab-pane" id="tas2">
                            <div class="row">
                                @Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: false, isSuit: false, isControlCabin: true))Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: false, isSuit: false, isControlCabin: true))MyProductService.GetSpecialProducts(isSpecial: false, isSuit: false, isControlCabin: true)
                            </div>
                        </div>
                        <div class="tab-pane" id="tas3">
                            <div class="row">
                                @Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: false, isSuit: true, isControlCabin: false))Html.Partial("~/Views/Product/Special.cshtml", MyProductService.GetSpecialProducts(isSpecial: false, isSuit: true, isControlCabin: false))MyProductService.GetSpecialProducts(isSpecial: false, isSuit: true, isControlCabin: false)
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>

<!--邮轮日历-->
<div class="row" id="calendar" v-html="myhtml"></div>

<!--预订流程图片-->
<div class="row">
    <div class="col-md-12 col-sm-12">
        <div class="con_procedure hidden-xs">
            <div class="procedure"></div>
        </div>
    </div>
</div>

<!--邮轮百科-->
<h2 class="margin-bottom-30 margin-top-0">
    邮轮百科 <a class="h4 pull-right" href="/BaiKe">查看更多</a>
</h2>
<div class="row">
    <div class="col-md-12">
        <div id="owl-demo" class="owl-carousel">
IList<vArticle> arts = ((IQueryOver<vArticle>)(object)new DbHelper<vArticle>().GetQueryOver().Where((ICriterion)(object)Expression.Sql(" this_.CategoryId in (select CategoryId from Category where ParentId=141) and this_.ArticleImg!=''"))).Take(20).List();
        </div>
    </div>
</div>

<h2 class="margin-bottom-30 margin-top-0">邮轮游记 <a class="h4 pull-right" href="/BaiKe/List/27">查看更多</a></h2>
<div class="row search-page search-content-3 text-center">
IList<vArticle> travelnotes = ((IQueryOver<vArticle>)(object)((QueryOverOrderBuilderBase<IQueryOver<vArticle, vArticle>, vArticle, vArticle>)(object)new DbHelper<vArticle>().GetQueryOver().Where((Expression<Func<vArticle, bool>>)((vArticle o) => o.ArticleState == 2 && o.CategoryId == 27)).OrderBy((Expression<Func<vArticle, object>>)((vArticle o) => o.ArticleId))).Desc).Take(4).List();
</div>

@section scripts{

    <script type="text/javascript" src="/Scripts/owl-carousel/owl.carousel.min.js"></script>
    <script type="text/javascript" src="/Scripts/Search.js?v=1"></script>
    <script type="text/javascript">
        var calendar = new Vue({
            el: "#calendar",
            data: {
                areaid: @MyWebConfig.DefaultAreaId,
                month: '@DateTime.Now.ToString("yyyy-MM")',
                today: '@DateTime.Now.ToString("yyyy-MM-dd")',
                userid: @LoginAgentUser.UserId,
                userguid: '@LoginAgentUser.UserGuid',
                myhtml: ''
            },
            mounted: function() {
                setTimeout(function() {
                    calendar.GetCalendar();
                    },
                600);
            },
            watch: {
                month: function() {
                    calendar.GetCalendar();
                },
                areaid: function() {
                    calendar.GetCalendar();
                }
            },
            computed: {
            
            },
            methods: {
                //获取日历
                GetCalendar: function() {
                    $.ajax({
                        cache: false,
                        type: "Post",
                        dataType: "html",
                        url: "@MyWebConfig.Api_Gateway/MyProduct/Show/Calendar?userguid=" + calendar.userguid,
                        data: {
                            CruiseMonth: calendar.month,
                            AreaId: calendar.areaid
                        },
                        beforeSend: function() {
                            //vm.isLoading = true;
                        },
                        success: function(data) {
                            calendar.myhtml = (data);
                            setTimeout(function() {
                                MyScript.PageInit();
                                    $("#calendarMonth").change(function() { calendar.month = $(this).val(); });
                                },
                            600);
                        }
                    });
                }
            }
        });

        function random(owlSelector) {
            owlSelector.children().sort(function () {
                return Math.round(Math.random()) - 0.5;
            }).each(function () {
                $(this).appendTo(owlSelector);
            });
        }

        $(function () {
            $("#owl-demo").owlCarousel({
                beforeInit: function(elem) {
                    random(elem);
                },
                items: 4,
                lazyLoad: true,
                autoPlay: true
            });
        });
    </script>
}

```