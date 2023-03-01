using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission09_nsweiler.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_nsweiler.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-information")] // specify where this tag helper will be used (in div tags with attribute "page-model")
    public class PaginationTagHelper : TagHelper // inherits from the default Microsoft taghelpers
    {
        // Dynamically create the page links for us

        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]

        public ViewContext vc { get; set; }

        // different than vc
        public PageInfo PageInformation { get; set; } // retrieves page information from the view
        public string PageAction { get; set; }

        // bootstrap variables
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho) // overrides the parent process
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div"); // new div tag builder


            for (int i = 1; i <= PageInformation.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new {pageNum = i}); // returns what page we are on and the page number i

                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageInformation.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }

                tb.InnerHtml.Append(i.ToString()); // appends a string version of i to the innerHTML of the div on the current page

                final.InnerHtml.AppendHtml(tb);

                tho.Content.AppendHtml(final.InnerHtml);
            }
        }

    }
}
