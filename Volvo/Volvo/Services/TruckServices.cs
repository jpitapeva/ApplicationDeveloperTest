using System;
using System.Collections.Generic;
using System.Linq;
using Volvo.Models;
using Volvo.Repository.Context;
using Volvo.ViewModel;

namespace Volvo.Services
{
    public class TruckServices : ITruckServices
    {
        private readonly TruckContext _contextDb;

        public TruckServices(TruckContext contextDb)
        {
            _contextDb = contextDb;
        }

        public void UpdateTruckViewModel(UpdateTruckViewModel updateTruckViewModel)
        {
            try
            {
                var update = _contextDb.Truck.FirstOrDefault(s => s.Id == updateTruckViewModel.Id);
                if (update == null)
                {
                    throw new Exception("Id not found");
                }
                update.UpdateTruck(
                    updateTruckViewModel.Chassis,
                    updateTruckViewModel.TruckModelId,
                    updateTruckViewModel.ManufactureYear,
                    updateTruckViewModel.ResponsableId,
                    updateTruckViewModel.Status);

                _contextDb.Update(update);
                _contextDb.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteTruckViewModel(Guid id)
        {
            try
            {
                var delete = _contextDb.Truck.FirstOrDefault(s => s.Id == id);
                if (delete == null)
                {
                    throw new Exception("Id not found");
                }
                delete.DeleteTruck(id);
                _contextDb.Remove(delete);
                _contextDb.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void CreateTruckViewModel(CreateTruckViewModel truck)
        {
            Truck tr = new Truck(truck.Chassis, truck.TruckModelId, truck.ManufactureYear, truck.ResponsableId, truck.Status);

            _contextDb.Add(tr);
            _contextDb.SaveChanges();

        }

        public List<Truck> GetAllTruck()
        {
            var ret = _contextDb.Truck.AsEnumerable();
            return ret.ToList();
        }

        public Truck GetTruckById(Guid id)
        {
            var ret = _contextDb.Truck.FirstOrDefault(t => t.Id == id);
            return ret;
        }
    }
}
