using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System.Text.Encodings.Web;

namespace RuralCourtyard.Models.TagHelpers
{
    public class AlertsTagHelper : TagHelper
    {
        private const string AlertKey = "SimpleToDo.Alert";

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        protected ITempDataDictionary TempData => ViewContext.TempData;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddClass("alert-parent", HtmlEncoder.Default);

            if (TempData[AlertKey] == null)
                TempData[AlertKey] = JsonConvert.SerializeObject(new HashSet<Alert>());

            var alerts = JsonConvert.DeserializeObject<ICollection<Alert>>(TempData[AlertKey].ToString());

            var html = string.Empty;

            int alertIndex = 0;
            foreach (var alert in alerts)
            {
                alert.Message = alert.Message.Replace("\n", "<br>");
                html += $"<div class='alert {alert.Type}' id='alert{alertIndex} inner-alert' role='alert'>" +
                            $"<button type='button' class='close' data-dismiss='alert' aria-label='Close' onClick='closeAlert({alertIndex})'>" +
                                $"<span aria-hidden='true'>&times;</span>" +
                            $"</button>" +
                            $"<h5>{alert.Message}</h5>" +
                        $"</div>";

                alertIndex++;
            }

            output.Content.SetHtmlContent(html);
        }
    }
}
