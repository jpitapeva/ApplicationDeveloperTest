using System;
using Volvo.ViewModel;

namespace Volvo.Services
{
    public interface ITruckServices
    {
        void UpdateTruckViewModel(UpdateTruckViewModel updateTruckViewModel);
        void DeleteTruckViewModel(Guid id);
        void CreateTruckViewModel(CreateTruckViewModel createTruckViewModel);
    }
}
