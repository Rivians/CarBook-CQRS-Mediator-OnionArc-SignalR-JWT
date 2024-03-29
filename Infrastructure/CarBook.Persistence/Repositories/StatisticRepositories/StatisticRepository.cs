using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;
        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }


        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(q => q.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Aylık").Select(y => y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(q => q.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(q => q.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public string GetBlogTitleByMaxBlogComment()    // xx
        {
            throw new NotImplementedException();
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetBrandNameByMaxCar()    // xx
        {
            var value = _context.Cars.GroupBy(x => x.BrandID).
                            Select(y => new
                            {
                                BrandID = y.Key,
                                Count = y.Count()
                            }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brand = _context.Brands.Where(x => x.BrandID == value.BrandID).Select(y => y.Name).FirstOrDefault();

            return brand;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()  
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingId).Max(y => y.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string carBrandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return carBrandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()  
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingId).Min(y => y.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string carBrandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return carBrandModel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var values = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return values;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var values = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return values;
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
