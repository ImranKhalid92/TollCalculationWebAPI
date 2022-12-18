using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TollCalculation.Common;
using TollCalculation.Models;

namespace TollCalculation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TollCalculatorController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetTollAmount()
        {
            var response = new ResponceModel();
            try
            {
                // assuming the entry and exist points.
                // assuming these are points are validated including number plate.
                string numberPlate = "LHR-123";
                var entryPoint = GetEntryPointByNumberPlate(numberPlate);
                var exitPoint = GetExistPoint(numberPlate);

                // assuming that if vehicle exist from the same toll, the base rate will still be charged.
                double discount = 0;
                double kmRate = Rates.DistanceRatePerKM;
                // calculate toll. 

                response.BaseRate = Rates.BaseRate;
                double distanceTraveled = Math.Abs(exitPoint.InterChange - entryPoint.InterChange);

                if (HelpingData.Holidays.Any(d => d.Day == entryPoint.EntryTime.Date.Day && d.Month == entryPoint.EntryTime.Date.Month))
                {
                    // discount as traveling on holiday
                    discount = Rates.DiscountOnHolidays;
                }
                else if (HelpingData.FrySaturSunday.Contains(entryPoint.EntryTime.DayOfWeek) == false)
                {
                    // discount as traveling on Monday - Thursday
                    discount = Rates.DiscountOnTuesdayThursday;
                }

                // supposing that all distance will be charged with same rate - independent if started on Friday night and ended on Saturday 
                if (HelpingData.SaturSunday.Contains(exitPoint.EntryTime.DayOfWeek))
                {
                    kmRate = Rates.DistanceRateOnWeekendPerKM;
                }

                if(distanceTraveled!=0)
                    response.DistanceCost = distanceTraveled * kmRate;

                response.SubTotal = response.BaseRate + response.DistanceCost;
                // apply discount if any.
                if (discount > 0)
                {
                    response.Discount = response.SubTotal * discount;
                }

                response.BaseRate = Rates.BaseRate;
                response.TotalToBeCharged = response.SubTotal - response.Discount;
                response.OperationSuccess = true;
            }
            catch (Exception e)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        private Request GetEntryPointByNumberPlate(string numberPlate)
        {
            // Assumptions 
            // 1- Vehicle number is valid and validated.
            // 2- This vehicle is entered from the Raiwand Interchange.
            return new Request
            {
                InterChange = TollPlaza.ZeroPoint,
                NumberPlate = numberPlate,
                EntryTime = new DateTime(2022, 12, 1, 09, 09, 09)
            };
        }

        private Request GetExistPoint(string numberPlate)
        {
            // Assumptions 
            // 1- Vehicle number is valid and validated.
            // 2- This vehicle is already entered from an inter change
            return new Request
            {
                InterChange = TollPlaza.LakeCityInterchange,
                NumberPlate = numberPlate,
                EntryTime = new DateTime(2022, 12, 1, 09, 09, 50)
            };
        }

        private bool IsVehicleNumberIsEven(string numberPlate)
        {
            return false;
        }
    }
}
