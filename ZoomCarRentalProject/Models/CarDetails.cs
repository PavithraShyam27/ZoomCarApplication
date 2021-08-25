using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZoomCarRentalProject.Models
{
    public class CarDetails
    {
        public int ID { get; set; }
        public string CarModel { get; set; }
        public string CarNo { get; set; }
        [Range(1,8,ErrorMessage ="Only positive number are allowed")]
        public int NoOfSeats { get; set; }
    }
}