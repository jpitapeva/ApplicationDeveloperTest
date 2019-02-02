using System;
using System.Collections.Generic;
using System.Linq;
using Volvo.Models;
using Microsoft.AspNetCore.Mvc;
using Volvo.Services;
using Volvo.ViewModel;

namespace Volvo.Controllers.v1
{
    [System.Web.Http.Route("volvo/v1/[controller]")]
    public class TruckController : Controller
    {
        private ITruckServices _itruckServices;

        public TruckController(ITruckServices itruckServices)
        {
            _itruckServices = itruckServices;
        }

        /// <summary>
        /// Method for get all truck`s
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllTruck")]
        public List<Truck> GetAllTruck()
        {
            var ret = _itruckServices.GetAllTruck();
            return ret.ToList();
        }

        /// <summary>
        /// Method for get truck by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getTruckById")]
        public Truck GetTruckById(Guid id)
        {
            var ret = _itruckServices.GetTruckById(id);
            return ret;
        }

        /// <summary>
        /// Method for delete the truck by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteTruckById/{id}")]
        public IActionResult DeleteTruckById(Guid id)
        {
            _itruckServices.DeleteTruckViewModel(id);
            return Ok();
        }

        /// <summary>
        /// Method for update the truck by Id
        /// </summary>
        /// <param name="updateTruckViewModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateTruckById")]
        public IActionResult UpdateTruckById([FromBody]UpdateTruckViewModel updateTruckViewModel)
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

        /// <summary>
        /// Method for create an new truck
        /// </summary>
        /// <param name="createTruckViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createTruck")]
        public IActionResult CreateNewTruck([FromBody]CreateTruckViewModel createTruckViewModel)
        {
            try
            {
                _itruckServices.CreateTruckViewModel(createTruckViewModel);
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
