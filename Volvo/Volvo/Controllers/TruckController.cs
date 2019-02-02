using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Volvo.Repository.Context;
using Volvo.Services;
using Volvo.ViewModel;

namespace Volvo.Controllers.v1
{
    [System.Web.Http.Route("volvo/v1/[controller]")]
    public class TruckController : Controller
    {
        private readonly TruckContext _contextDb;
        private readonly ITruckServices _itruckServices;

        public TruckController(TruckContext contextDb, ITruckServices itruckServices)
        {
            _contextDb = contextDb;
            _itruckServices = itruckServices;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("getAllTruck")]
        public IEnumerable<Truck> GetAllTruck()
        {
            return _contextDb.Truck.AsEnumerable();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("getTruckById/{id}")]
        public Truck GetTruckById(Guid id)
        {
            Truck truck = _contextDb.Truck.FirstOrDefault(c => c.Id == id);

            if (truck == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return truck;
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("deleteTruckById/{id}")]
        public IActionResult DeleteTruckById(Guid id)
        {
            _itruckServices.DeleteTruckViewModel(id);

            return Ok();
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("updateTruckById/{updateTruckViewModel}")]
        public IActionResult UpdateTruckById(UpdateTruckViewModel updateTruckViewModel)
        {
            try
            {
                _itruckServices.UpdateTruckViewModel(updateTruckViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Ok();
        }
    }
}
