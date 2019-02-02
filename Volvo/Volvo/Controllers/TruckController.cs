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

namespace Volvo.Controllers.v1
{
    [System.Web.Http.Route("volvo/v1/[controller]")]
    public class TruckController : Controller
    {
        private readonly TruckContext _contextDb;

        public TruckController(TruckContext contextDb)
        {
            _contextDb = contextDb;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("getAllTruck")]
        public IEnumerable<Truck> GetAllTruck()
        {
            return _contextDb.Truck.AsEnumerable();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("getTruckById/{id}")]
        public Truck GetTruck(int id)
        {
            Truck truck = _contextDb.Truck.Find(id);

            if (truck == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return truck;
        }
    }
}
