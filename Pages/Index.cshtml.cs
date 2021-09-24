using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public async Task<IActionResult> OnPostAddMeasurementAsync()
        {
            var response = await DataAccess.PostMeasurement(Input);
            return RedirectToPage("Index"); ;
        }
    }
}
