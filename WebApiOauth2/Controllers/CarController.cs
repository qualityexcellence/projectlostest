using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingProject1.Models;
using TestingProject1.Repositories;

namespace TestingProject1.Controllers
{
    [Authorize]
    public class CarController : ApiController
    {
        private CarRepository _carRepository;
        public CarController()
        {
            _carRepository = new CarRepository();
        }
       

        // GET api/values/5
        [HttpGet]
        public APIResponse<List<Car>> LoadByYear(string year)
        {
            APIResponse<List<Car>> response = new APIResponse<List<Car>> { status = new APIResponseStatus() { IsSuccessful = false } };
            try
            {
                response.item = _carRepository.LoadByYearmade(year);
                response.status.IsSuccessful = true;
            }
            catch (Exception e)
            {
                string message = string.IsNullOrWhiteSpace(e.InnerException?.Message) ? e.Message : e.InnerException.Message;
                response.status.ErrorMessage = message;
            }
            return response;
        }

        // POST api/values
        [HttpPost]
        public APIResponse<Car> Add([FromBody] Car model)
        {
            APIResponse<Car> response = new APIResponse<Car> { status = new APIResponseStatus() { IsSuccessful = false } };
            try
            {
                response.item = _carRepository.Add(model);
                response.status.IsSuccessful = true;
            }
            catch (Exception e)
            {

                response.status.ErrorMessage = e.Message;
            }
            return response;
        }

        // PUT api/values/5
        [HttpPatch]
        public APIResponse<Car> Update([FromBody] Car model)
        {
            APIResponse<Car> response = new APIResponse<Car> { status = new APIResponseStatus() { IsSuccessful = false } };
            try
            {
                response.item = _carRepository.Update(model);
                response.status.IsSuccessful = true;
            }
            catch (Exception e)
            {

                response.status.ErrorMessage = e.Message;
            }
            return response;
        }

       
    }
}
