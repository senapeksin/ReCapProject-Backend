using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getcarsbycolorid")]
      public ActionResult GetCarsByColorId(int ColorId)
        {
            var result = _carService.GetCarsByColorId(ColorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandid")]
        public ActionResult GetCarsByBrandId(int BrandId)
        {
            var result = _carService.GetCarsByBrandId(BrandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetails")]
        public ActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public ActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

            [HttpPost("update")]
            public IActionResult Update(Car car)
            {
                var result = _carService.Update(car);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            [HttpPost("delete")]
            public IActionResult Delete(Car car)
            {
                var result = _carService.Delete(car);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

        }
}
