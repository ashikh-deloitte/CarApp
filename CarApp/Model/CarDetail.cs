using System;
using System.Collections.Generic;
using System.IO;

namespace CarApp.Model
{
    public enum FeatureType
    {
        IsJustLaunched=1,
        IsPopular=2,
        IsUpcoming=3
    }
    public class BookingDetails
    {
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
        public string City { get; set; }
        public int CarId { get; set; }

    }
    public class CarCardDetail
    {
        public int Id { get; set; }

        public string CarBrandName { get; set; }

        public string CarName { get; set; }

        public string CarType { get; set; }

        public string CarPrice { get; set; }

        public string CarImage { get; set; }

        public string CarBookingImage { get; set; }
        public bool IsBooked { get; set; }
    }

    public class CarDetail
    {
        public CarCardDetail CarCardDetail { get; set; }

        public CarSpecification CarSpecification { get; set; }

        public CarDescription ExteriorDescription { get; set; }

        public CarDescription InteriorDescription { get; set; }

        public bool IsJustLaunched { get; set; }

        public bool IsPopular { get; set; }

        public bool IsUpcoming { get; set; }
    }

    public class CarSpecification
    {
        public string FuelType { get; set; }
        public string EngineType { get; set; }
        public string Torque { get; set; }
        public string Acceleration { get; set; }
        public string TopSpeed { get; set; }
        public List<string> Variants { get; set; }
    }

    public class CarDescription
    {
        public List<string> Description { get; set; }

        public List<string> Images { get; set; }
    }


    public class FeatureCarType
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }

    public static class CarData
    {
        static List<BookingDetails> lstBookingDetail = new List<BookingDetails>();
        static List<CarDetail> lstCarDetail = new List<CarDetail>();
        public static void InsertBooking(BookingDetails booking)
        {
            lstBookingDetail.Add(booking);

        }

        public static void UpdateBooking(int carId)
        {
            lstCarDetail.ForEach(s =>
            {
                if (s.CarCardDetail.Id == carId) { s.CarCardDetail.IsBooked = true; }
            });

        }

        public static List<CarDetail> GetCars()
        {
            if (lstCarDetail.Count <= 0)
            {

                lstCarDetail.Add(new CarDetail()
                {
                    CarCardDetail = new CarCardDetail()
                    {
                        Id = 1,
                        CarImage = "http://localhost:5000/images/bmwx3.png",
                        CarName = "x3",
                        CarBrandName = "BMW",
                        CarType = "SEDAN",
                        CarPrice = "69.0 lakhs",
                        CarBookingImage = "http://localhost:5000/images/booking.png",
                        IsBooked = true
                    },
                    CarSpecification = new CarSpecification()
                    {
                        Acceleration = "0-100 in 10 sec",
                        EngineType = "K-Series",
                        FuelType = "Petrol",
                        TopSpeed = "200km/hr",
                        Torque = "50",
                        Variants = new List<string>() { "Petrol", "Deisel", "Automatic" }
                    },
                    ExteriorDescription = new CarDescription{
                        Description=new List<string>() {"Good","Mileage" },
                        Images=new List<string>() {
                            "http://localhost:5000/images/bmwx5-exterior1.png",
                            "http://localhost:5000/images/bmwx5-exterior2.png"
                        }
                    },
                    IsJustLaunched = true,
                    IsPopular=false,
                    IsUpcoming= false,
                    InteriorDescription=new CarDescription()
                    {
                        Description = new List<string>() { "Good", "Mileage" },
                        Images = new List<string>() {
                            "http://localhost:5000/images/bmwx5-interior1.png",
                            "http://localhost:5000/images/bmwx5-interior2.png"
                        }
                    }

                });
                lstCarDetail.Add(new CarDetail()
                {
                    CarCardDetail = new CarCardDetail()
                    {
                        Id = 2,
                        CarImage = "http://localhost:5000/images/bmwx5.png",
                        CarName = "x5",
                        CarBrandName = "BMW",
                        CarType = "HatchBack",
                        CarPrice = "90.0 lakhs"
                    },
                    CarSpecification = new CarSpecification()
                    {
                        Acceleration = "0-100 in 10 sec",
                        EngineType = "K-Series",
                        FuelType = "Petrol",
                        TopSpeed = "200km/hr",
                        Torque = "50",
                        Variants = new List<string>() { "Petrol", "Deisel", "Automatic" }
                    },
                    ExteriorDescription = new CarDescription(),
                    IsJustLaunched = true

                });
            }
            return lstCarDetail;
        }

    }
}
