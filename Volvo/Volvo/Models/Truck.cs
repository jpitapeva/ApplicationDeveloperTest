using System;

namespace Volvo.Models
{
    public class Truck
    {
        public Truck(string chassis, DateTime manufactureYear, int responsableId, bool status, TruckModel truckModels)
        {
            Id = Guid.NewGuid();
            Chassis = chassis;
            ManufactureYear = manufactureYear;
            ResponsableId = responsableId;
            Status = status;
            TruckModels = truckModels;
        }

        public Guid Id { get; set; }
        public string Chassis { get; private set; }
        public DateTime ManufactureYear { get; private set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeModification { get; set; }
        public int ResponsableId { get; private set; }
        public bool Status { get; private set; }
        public TruckModel TruckModels { get; private set; }
    }
}
