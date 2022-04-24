using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarBookingController : ControllerBase
    {
        private readonly ILogger<CarBookingController> _logger;

        public CarBookingController(ILogger<CarBookingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("searchcar")]
        public IEnumerable<CarCardDetail> SearchCarByName(string carName)
        {
            if (!string.IsNullOrEmpty(carName))
            {
                return CarData.GetCars().Where(s => s.CarCardDetail.CarName.Contains(carName)).Select(s=>new CarCardDetail() {
                    CarBrandName=s.CarCardDetail.CarBrandName,
                    CarImage=s.CarCardDetail.CarImage,
                    CarName=s.CarCardDetail.CarName,
                    CarPrice=s.CarCardDetail.CarPrice,
                    CarType=s.CarCardDetail.CarType,
                    Id=s.CarCardDetail.Id

                });
            }
            return new List<CarCardDetail>();
        }

        [HttpGet]
        [Route("landing/{filterType:int?}")]
        public IEnumerable<CarCardDetail> GetLandingPageCard(int? filterType)
        {

            List<CarDetail> lstCarDetail = new List<CarDetail>();
            if (filterType != null && filterType!=0)
            {
                switch (Convert.ToInt32(filterType))
                {
                    case (int)FeatureType.IsJustLaunched:
                        lstCarDetail = CarData.GetCars().Where(s => s.IsJustLaunched).ToList();
                        break;
                    case (int)FeatureType.IsPopular:
                        lstCarDetail = CarData.GetCars().Where(s => s.IsPopular).ToList();
                        break;
                    default:
                        lstCarDetail = CarData.GetCars().Where(s => s.IsUpcoming).ToList();
                        break;
                }
                
            }
            else {
                lstCarDetail = CarData.GetCars().Where(s => s.IsJustLaunched).ToList();
            }
            return lstCarDetail.Select(s => new CarCardDetail()
            {
                CarBrandName = s.CarCardDetail.CarBrandName,
                CarImage = s.CarCardDetail.CarImage,
                CarName = s.CarCardDetail.CarName,
                CarPrice = s.CarCardDetail.CarPrice,
                CarType = s.CarCardDetail.CarType,
                Id = s.CarCardDetail.Id,
                IsBooked=s.CarCardDetail.IsBooked

            });
         
        }

        [HttpGet]
        [Route("get-featurecar-display-type")]
        public IEnumerable<FeatureCarType> GetFeatureCarDisplayType()
        {
            return new List<FeatureCarType>() { new FeatureCarType() { TypeId=1, TypeName="Popular"},
            new FeatureCarType() { TypeId=1, TypeName="Just Launched"},new FeatureCarType() { TypeId=1, TypeName="Upcoming"}};
        }
        [HttpGet]
        [Route("getCarById")]
        public IEnumerable<CarDetail> GetCarById(int id)
        {
            return CarData.GetCars().Where(s => s.CarCardDetail.Id == id).ToList();
        }
        [HttpPost]
        [Route("book-car")]
        public bool PostCarBooking(BookingDetails bookingDetail)
        {
            CarData.InsertBooking(bookingDetail);
            CarData.UpdateBooking(bookingDetail.CarId);
            return true;
        }
    }
}
