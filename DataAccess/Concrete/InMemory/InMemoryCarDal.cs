using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {

            //Testing Data
            _cars = new List<Car>()
            {
                new Car{ CarId = 1, BrandId= 1, ColorId= 2, DailyPrice=450, ModelYear=2020, Description="Excellent Comfortable Driving"},
                new Car{ CarId = 2, BrandId= 3, ColorId= 1, DailyPrice=600, ModelYear=2021, Description="Amazing Comfortable Driving"},
                new Car{ CarId = 3, BrandId= 4, ColorId= 3, DailyPrice=850, ModelYear=2022, Description="Excellent Comfortable Driving"},
                new Car{ CarId = 4, BrandId= 2, ColorId= 1, DailyPrice=950, ModelYear=2019, Description="İncredible Velocity Increasing"},
                new Car{ CarId = 5, BrandId= 5, ColorId= 4, DailyPrice=1050, ModelYear=2023, Description="Not Bad Comfortable Driving"},

            };
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            var carDeleted = _cars.FirstOrDefault(i => i.CarId == entity.CarId);

            _cars.Remove(carDeleted);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            var carUpdated = _cars.FirstOrDefault(_ => _.CarId == entity.CarId);

            if (carUpdated != null)
            {
                carUpdated.CarId = entity.CarId;
                carUpdated.BrandId = entity.BrandId;
                carUpdated.ColorId = entity.ColorId;
                carUpdated.DailyPrice = entity.DailyPrice;
                carUpdated.Description = entity.Description;
                carUpdated.ModelYear = entity.ModelYear;
            }
            else
            {
                throw new Exception("Car is not found, Please try again");
            }
        }



    }
}
