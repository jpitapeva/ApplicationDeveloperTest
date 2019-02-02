using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo.Models;

namespace Volvo.ViewModel
{
    public class UpdateTruckModelViewModel
    {
        public Guid Id { get; set; }
        public DateTime ModelYear { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public string Potence { get; set; }
        public int ResponsableId { get; set; }
        public bool Status { get; set; }
    }
}
