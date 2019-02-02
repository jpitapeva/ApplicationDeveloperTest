using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                update.UpdateTruck(updateTruckViewModel.TruckModelId,
                    updateTruckViewModel.Chassis,
                    updateTruckViewModel.ManufactureYear,
                    updateTruckViewModel.ResponsableId,
                    updateTruckViewModel.Status,
                    updateTruckViewModel.TruckModel);

                _contextDb.Update(update);
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

        public void CreateTruckViewModel(CreateTruckViewModel createTruckViewModel)
        {
           
            //update.UpdateTruck(updateTruckViewModel.TruckModelId,
            //    updateTruckViewModel.Chassis,
            //    updateTruckViewModel.ManufactureYear,
            //    updateTruckViewModel.ResponsableId,
            //    updateTruckViewModel.Status,
            //    updateTruckViewModel.TruckModel);

            //_contextDb.Update(update);
           
        }
    }
}
