namespace MiniWebERP.Web.Infrastructure.TagHelpers
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("div", Attributes = ForAttributeName)]
    [HtmlTargetElement("td", Attributes = ForAttributeName)]
    public class ContentTagHeper : TagHelper
    {
        private const string ForAttributeName = "asp-content-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (this.For.Model != null)
            {
                output.Content.SetContent((string)this.For.Model);
            }
        }
    }
}
