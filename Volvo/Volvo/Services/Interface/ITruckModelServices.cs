using System;
using System.Collections.Generic;
using Volvo.Models;
using Volvo.ViewModel;

namespace Volvo.Services.Interface
{
    public interface ITruckModelServices
    {
        void UpdateTruckModelViewModel(UpdateTruckModelViewModel updateTruckViewModel);
        void DeleteTruckModelViewModel(Guid id);
        void CreateTruckModelViewModel(CreateTruckModelViewModel createTruckViewModel);
        List<TruckModel> GetAllTruckModel();
        TruckModel GetTruckModelById(Guid id);
    }
}
