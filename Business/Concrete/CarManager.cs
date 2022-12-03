using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

      

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(i => i.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(i => i.ColorId== colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Add(Car car)
        {

            if (car.CarName.Length < 2) //Car entitysinden navigation prop ile BrandName'e ulaşma SORUN VAR!!
            {
                throw new Exception("Length of Car Name must be more than two");
            }
            if (car.DailyPrice < 0)
            {
                throw new Exception("Price of Car have to be bigger than zero");
            }
            else
            {
                _carDal.Add(car);
            }
        }



    }
}
