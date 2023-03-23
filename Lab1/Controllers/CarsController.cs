using Lab1.Filters;
using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Car>> GetAll()
        {
            return Car.GetCars(); //status code 200 (default)
        }

        [HttpGet]
        [Route("{id:int}")] //":int" to make a constraint to help if there is ambiguity with same endpoint. We can use this constraint or not
        public ActionResult<Car> GetById(int id)
        {
            var car = Car.GetCars().FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new GeneralResponse("Resource is missing"));
            }
            return car;
        }

        [HttpPost]
        [Route("v1")] //v1 that is deprecated (Old Endpoint)
        [DisabledV1] //Action Filter: to be switched to v2
        public ActionResult Add(Car car)
        {
            car.Id = new Random().Next(1, 1000);
            car.Type = "Gas"; //Old endpoint should explicitly assign type property with "Gas"
            Car.GetCars().Add(car);
            return CreatedAtAction(
                    actionName: nameof(GetById),
                    routeValues: new { id = car.Id },
                    value: new GeneralResponse("Resource is Added Successfully")
                );
        }

        [HttpPost]
        [Route("v2")] //New Endpoint
        [ValidateCarType]
        public ActionResult AddV2(Car car)
        {
            car.Id = new Random().Next(1, 1000);
            Car.GetCars().Add(car);
            return CreatedAtAction(
                    actionName: nameof(GetById),
                    routeValues: new { id = car.Id },
                    value: new GeneralResponse("Resource is Added Successfully")
                );
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<Car> Edit(Car car, int id)
        {
            if(id != car.Id)
            {
                return BadRequest(new GeneralResponse("Ids don't match"));
            }

            var carToEdit = Car.GetCars().FirstOrDefault(c => c.Id == id);
            if(carToEdit == null)
            {
                return NotFound(new GeneralResponse("Resource is missing"));
            }
            carToEdit.FirstUseDate = car.FirstUseDate;
            carToEdit.HtmlDescription = car.HtmlDescription;
            carToEdit.Manufacturer = car.Manufacturer;
            carToEdit.Model = car.Model;
            carToEdit.Image = car.Image;

            return car;
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var carToDelete = Car.GetCars().FirstOrDefault(c => c.Id == id);
            if (carToDelete == null)
            {
                return NotFound(new GeneralResponse("Resource is missing"));
            }
            Car.GetCars().Remove(carToDelete);

            return NoContent();
        }

        [HttpGet]
        //Endpoint to get the value of counter (number of requests)
        [Route("requests")]
        public ActionResult<object> GetRequestsNo()
        {
            var numberOfRequests = HttpContext.Items["counter"];
            return numberOfRequests!;
        }
    }
}
