using System;

namespace Volvo.Models
{
    public class TruckModel
    {
        public TruckModel(DateTime modelYear, string color, string engine, string potence, int responsableId, bool status, Truck truck, Guid truckId)
        {
            Id = Guid.NewGuid();
            ModelYear = modelYear;
            Color = color;
            Engine = engine;
            Potence = potence;
            ResponsableId = responsableId;
            Status = status;
            Truck = truck;
            TruckId = truckId;
        }

        public Guid Id { get; set; }
        public Guid TruckId { get; private set; }
        public DateTime ModelYear { get; private set; }
        public string Color { get; private set; }
        public string Engine { get; private set; }
        public string Potence { get; private set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeModification { get; set; }
        public int ResponsableId { get; private set; }
        public bool Status { get; private set; }
        public Truck Truck { get; private set; }
    }
}
