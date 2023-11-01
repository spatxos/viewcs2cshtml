# viewcs2cshtml
将.View.dll文件反编译出来的*Views*.cs文件转换成.cshtml

先使用反编译工具将.View.dll文件反编译放入文件夹，然后将文件夹整体复制进\src\viewcs2cshtml\viewcs2cshtml\bin\Debug\net6.0\viewcs
复制完成之后运行程序，即可在复制进去的文件夹中看到Views/Areas文件夹

暂不支持有asp-开头属性的控件
