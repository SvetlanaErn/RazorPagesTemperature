using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIwithRazorPages
{
    public class DataAccess
    {
        public static async Task<IActionResult> PostMeasurement(Measurement measurement)
        {
            try
            {
                await using var context = new MyContext();
                context.Measurements.Add(measurement);
                context.SaveChanges();
                return new OkObjectResult("success!");
            }
            catch
            {
                return new BadRequestObjectResult("something went wrong :(");
            }
        }

        public static async Task<List<Measurement>> GetMeasurements()
        {
            await using var context = new MyContext();
            List<Measurement> list = context.Measurements.ToList();
            return list;
        }
    }
}
