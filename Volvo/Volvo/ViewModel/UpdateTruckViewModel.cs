using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo.Models;

namespace Volvo.ViewModel
{
    public class UpdateTruckViewModel
    {
        public Guid Id { get; set; }
        public Guid TruckModelId { get; set; }
        public string Chassis { get; set; }
        public DateTime ManufactureYear { get; set; }
        public int ResponsableId { get; set; }
        public bool Status { get; set; }
        public TruckModel TruckModel { get; set; }
    }
}
