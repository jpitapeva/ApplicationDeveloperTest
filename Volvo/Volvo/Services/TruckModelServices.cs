using System;
using System.Collections.Generic;
using System.Linq;
using Volvo.Models;
using Volvo.Repository.Context;
using Volvo.Services.Interface;
using Volvo.ViewModel;

namespace Volvo.Services
{
    public class TruckModelServices : ITruckModelServices
    {
        private readonly TruckContext _contextDb;

        public TruckModelServices(TruckContext contextDb)
        {
            _contextDb = contextDb;
        }

        public void UpdateTruckModelViewModel(UpdateTruckModelViewModel updateTruckModelViewModel)
        {
            try
            {
                var update = _contextDb.Truck.FirstOrDefault(s => s.Id == updateTruckModelViewModel.Id);
                if (update == null)
                {
                    throw new Exception("Id not found");
                }
                update.TruckModel.UpdateTruckModel(updateTruckModelViewModel.ModelYear,
                    updateTruckModelViewModel.Color,
                    updateTruckModelViewModel.Engine,
                    updateTruckModelViewModel.Potence,
                    updateTruckModelViewModel.ResponsableId,
                    updateTruckModelViewModel.Status);

                _contextDb.Update(update);
                _contextDb.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteTruckModelViewModel(Guid id)
        {
            try
            {
                var delete = _contextDb.TruckModels.FirstOrDefault(s => s.Id == id);
                if (delete == null)
                {
                    throw new Exception("Id not found");
                }
                delete.DeleteTruckModel(id);
                _contextDb.Remove(delete);
                _contextDb.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void CreateTruckModelViewModel(CreateTruckModelViewModel truckModel)
        {
            TruckModel tr = new TruckModel(truckModel.ModelYear,
                truckModel.Color,
                truckModel.Engine,
                truckModel.Potence,
                truckModel.ResponsableId, 
                truckModel.Status);
            _contextDb.Add(tr);
            _contextDb.SaveChanges();
        }

        public List<TruckModel> GetAllTruckModel()
        {
            var ret = _contextDb.TruckModels.AsEnumerable();
            return ret.ToList();
        }

        public TruckModel GetTruckModelById(Guid id)
        {
            var ret = _contextDb.TruckModels.FirstOrDefault(t => t.Id == id);
            return ret;
        }

       
    }
}
