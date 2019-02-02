using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Volvo.Models;
using Volvo.Services.Interface;
using Volvo.ViewModel;

namespace Volvo.Controllers
{
    [System.Web.Http.Route("volvo/v1/[controller]")]
    public class TruckModelController : Controller
    {
        private readonly ITruckModelServices _iTruckModelServices;

        public TruckModelController(ITruckModelServices itruckModelServices)
        {
            _iTruckModelServices = itruckModelServices;
        }

        /// <summary>
        /// Method for get all model truck`s
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllTruckModel")]
        public List<TruckModel> GetAllModelTruck()
        {
            var ret = _iTruckModelServices.GetAllTruckModel();
            return ret.ToList();
        }

        /// <summary>
        /// Method for get truck Model by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getTruckModelById")]
        public TruckModel GetTruckModelById(Guid id)
        {
            var ret = _iTruckModelServices.GetTruckModelById(id);
            return ret;
        }

        /// <summary>
        /// Method for delete the truck model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteTruckModelById/{id}")]
        public IActionResult DeleteTruckModelById(Guid id)
        {
            _iTruckModelServices.DeleteTruckModelViewModel(id);
            return Ok();
        }

        /// <summary>
        /// Method for update the truck model by Id
        /// </summary>
        /// <param name="updateTruckModelViewModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateTruckModelById")]
        public IActionResult UpdateTruckModelById([FromBody]UpdateTruckModelViewModel updateTruckModelViewModel)
        {
            try
            {
                _iTruckModelServices.UpdateTruckModelViewModel(updateTruckModelViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Ok();
        }

        /// <summary>
        /// Method for create an new truck model
        /// </summary>
        /// <param name="createTruckModelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createTruckModel")]
        public IActionResult CreateNewTruckModel([FromBody]CreateTruckModelViewModel createTruckModelViewModel)
        {
            try
            {
                _iTruckModelServices.CreateTruckModelViewModel(createTruckModelViewModel);
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
