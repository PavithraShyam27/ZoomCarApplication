using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoomCarApplication.Models
{
    [Table("CarDetails")]
    public class CarDetails
    {
        public int ID { get; set; }
        public string CarModel { get; set; }
        public string CarNo { get; set; }
        public int NoOfSeats { get; set; }
    }
}
