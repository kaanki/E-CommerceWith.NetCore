using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Northwind.MvcWebUi.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PageTagHelpler:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int Pagesize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPAge { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='pagination'>");

            for (int i = 1; i <= PageCount; i++)
            {
                stringBuilder.AppendFormat("<li class ='{0}'>", i == CurrentPAge ? "active" : "");
                stringBuilder.AppendFormat("<a href='/product/index?page={0}&category={1}'>{2}</a>", i, CurrentCategory, i);
                stringBuilder.Append("</li>");
            }
            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}
