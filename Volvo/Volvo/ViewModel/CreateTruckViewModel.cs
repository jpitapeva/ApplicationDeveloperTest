using System;

namespace Volvo.ViewModel
{
    public class CreateTruckViewModel
    {
        public Guid Id { get; set; }
        public Guid TruckModelId { get; set; }
        public string Chassis { get; set; }
        public DateTime ManufactureYear { get; set; }
        public int ResponsableId { get;  set; }
        public bool Status { get; set; }
    }
}
