using System;
using System.ComponentModel.DataAnnotations;

namespace Volvo.Models
{
    public class Truck
    {
        public Truck() { }

        public Truck(string chassis, DateTime manufactureYear, int responsableId, bool status, TruckModel truckModel)
        {
            Id = Guid.NewGuid();
            Chassis = chassis;
            ManufactureYear = manufactureYear;
            ResponsableId = responsableId;
            Status = status;
            TruckModel = truckModel;
        }

        public Truck(string chassis,Guid truckModelId,  DateTime manufactureYear, int responsableId, bool status)
        {
            Id = Guid.NewGuid();
            TruckModelId = truckModelId;
            Chassis = chassis;
            ManufactureYear = manufactureYear;
            ResponsableId = responsableId;
            Status = status;
        }

        public void UpdateTruck(string chassis, Guid truckModelId, DateTime manufactureYear, int responsableId, bool status)
        {
            Chassis = chassis;
            TruckModelId = truckModelId;
            ManufactureYear = manufactureYear;
            ResponsableId = responsableId;
            Status = status;
        }

        public void DeleteTruck(Guid truck)
        {
            Id = truck;
        }

        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid TruckModelId { get; set; }
        [Required]
        public string Chassis { get; private set; }
        [Required]
        public DateTime ManufactureYear { get; private set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeModification { get; set; }
        [Required]
        public int ResponsableId { get; private set; }
        public bool Status { get; private set; }
        [Required]
        public TruckModel TruckModel { get; private set; }
    }
}
