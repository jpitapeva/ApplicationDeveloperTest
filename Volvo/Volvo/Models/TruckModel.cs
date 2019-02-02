using System;
using System.ComponentModel.DataAnnotations;

namespace Volvo.Models
{
    public class TruckModel
    {
        public TruckModel() { }

        public void UpdateTruckModel(DateTime modelYear, string color, string engine, string potence, int responsableId, bool status)
        {
            ModelYear = modelYear;
            Color = color;
            Engine = engine;
            Potence = potence;
            ResponsableId = responsableId;
            Status = status;
        }

        public void DeleteTruckModel(Guid truckModelId)
        {
            Id = truckModelId;
        }

        public TruckModel(DateTime modelYear, string color, string engine, string potence, int responsableId, bool status)
        {
            Id = Guid.NewGuid();
            ModelYear = modelYear;
            Color = color;
            Engine = engine;
            Potence = potence;
            ResponsableId = responsableId;
            Status = status;
        }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime ModelYear { get; private set; }
        public string Color { get; private set; }
        public string Engine { get; private set; }
        public string Potence { get; private set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeModification { get; set; }
        [Required]
        public int ResponsableId { get; private set; }
        public bool Status { get; private set; }
        [Required]
        public Truck Truck { get;  set; }
    }
}
