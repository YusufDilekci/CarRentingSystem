using Business.Abstract;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            if(rental.ReturnDate == null) //Burda bokluk var zaten sonra bak
            {
                return new ErrorResult("Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.");
            }

            _rentalDal.Add(rental);
            return new SuccessResult("Araba kullanıcıya kiralanmıştır.");
        }
    }
}
