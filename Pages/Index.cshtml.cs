using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIwithRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Measurement Input { get; set; }
        public List<Measurement> MeasurementsList = new List<Measurement>();
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            MeasurementsList = DataAccess.GetMeasurements().Result;
            Log.Information("Update page");
        }

        public async Task<IActionResult> OnPostAddMeasurementAsync()
        {
            var response = await DataAccess.PostMeasurement(Input);
            Log.Information("New data: date {date}, temperature {temperature}", Input.DateTime, Input.Temperature);
            return RedirectToPage("Index"); ;
        }
    }
}
