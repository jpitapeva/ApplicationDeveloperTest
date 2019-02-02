using System;
using System.Collections.Generic;
using Volvo.Models;
using Volvo.ViewModel;

namespace Volvo.Services
{
    public interface ITruckServices
    {
        void UpdateTruckViewModel(UpdateTruckViewModel updateTruckViewModel);
        void DeleteTruckViewModel(Guid id);
        void CreateTruckViewModel(CreateTruckViewModel createTruckViewModel);
        List<Truck> GetAllTruck();
        Truck GetTruckById(Guid id);
    }
}
