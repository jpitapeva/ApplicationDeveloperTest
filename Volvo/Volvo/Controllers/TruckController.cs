using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using Volvo.Repository.Context;

namespace Volvo.Controllers
{
    public class TruckController : ApiController
    {
        private readonly TruckContext _contextDb;

        public TruckController(TruckContext contextDb)
        {
            _contextDb = contextDb;
        }

        public IEnumerable<Truck> GetTruck()
        {
            return _contextDb.Truck.AsEnumerable();
        }

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
