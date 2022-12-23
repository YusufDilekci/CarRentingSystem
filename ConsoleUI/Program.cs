using Business.Concrete;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using DataAccess.Migrations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

//Araba Kiralama projemiz üzerinde çalışmaya devam edeceğiz.

//Car nesnesine ek olarak;

//1) Brand ve Color nesneleri ekleyiniz(Entity)

//Brand-- > Id,Name

//Color-->Id, Name

//2) Sql Server tarafında yeni bir veritabanı kurunuz. Cars, Brands, Colors tablolarını oluşturunuz. (Araştırma)

//3) Sisteme Generic IEntityRepository altyapısı yazınız.

//4) Car, Brand ve Color nesneleri için Entity Framework altyapısını yazınız.

//5) GetCarsByBrandId , GetCarsByColorId servislerini yazınız.

//6) Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.

//Araba ismi minimum 2 karakter olmalıdır

//Araba günlük fiyatı 0'dan büyük olmalıdır.


//var customers = new List<Customer>()
//{
//    new Customer(){UserId = 8, CompanyName="Wawa Car"},
//    new Customer(){UserId = 9, CompanyName="Sahibinden"},
//    new Customer(){UserId = 10, CompanyName="Sixt"},

////};


//Data Transformation Object

//CarContext context= new CarContext();

//CarDetails();

//InsertData();

//AddCustomer(customers);

//RentCar();

GetCarsByBrandId(13);
static void InsertData()
{
    var cars = new List<Car>()
            {
                new Car{ BrandId= 1, ColorId= 2, DailyPrice=450, ModelYear=2020, Description="Excellent Comfortable Driving", CarName="Sedan"},
                new Car{ BrandId= 3, ColorId= 1, DailyPrice=600, ModelYear=2021, Description="Amazing Comfortable Driving", CarName="Hatchback"},
                new Car{ BrandId= 4, ColorId= 3, DailyPrice=850, ModelYear=2022, Description="Excellent Comfortable Driving", CarName="Station wagon"},
                new Car{ BrandId= 2, ColorId= 1, DailyPrice=950, ModelYear=2019, Description="İncredible Velocity Increasing", CarName="Cabrio"},
                new Car{ BrandId= 5, ColorId= 4, DailyPrice=1050, ModelYear=2023, Description="Not Bad Comfortable Driving", CarName="SUV"},

            };

    EfCarDal efCarDal = new EfCarDal();
    EfBrandDal efBrandDal = new EfBrandDal();
    EfColorDal efColorDal = new EfColorDal();


    var colors = new List<Color>()
{
    new Color(){ColorName="Blue"},
    new Color(){ColorName="Yellow"},
    new Color(){ColorName="Green"},
    new Color(){ColorName="Purple"},
    new Color(){ColorName="Black"},
    new Color(){ColorName="Orange"},

};

    var brands = new List<Brand>()
{
    new Brand(){BrandName="Mercedes"},
    new Brand(){BrandName="BMW"},
    new Brand(){BrandName="Ferrai"},
    new Brand(){BrandName="Lamborghni"},
    new Brand(){BrandName="Ford"},
    new Brand(){BrandName="Range Rover"},

};


    foreach (var car in cars)
    {
        efCarDal.Add(car);
    }

    foreach (var brand in brands)
    {
        efBrandDal.Add(brand);

    }


    foreach (var color in colors)
    {
        efColorDal.Add(color);

    }
}

static void CarDetails()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var carDetails = carManager.GetCarDetails();

    foreach (var car in carDetails.Data)
    {
        Console.WriteLine($" BrandName: {car.BrandName} **** Car Name: {car.CarName} **** ColorName: {car.ColorName} **** DailyPrice: {car.DailyPrice}\n");
    }
}


static void AddCustomer(List<Customer> customers)
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

    foreach (var customer in customers)
    {
        var result = customerManager.Add(customer);
        Console.WriteLine(result.Message);
    }
}


static void RentCar()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    Rental rental = new Rental() { CarId=8, CustomerId=1, RentDate=new DateTime(2022,12, 5), ReturnDate=new DateTime(2022,12, 6)};

    var result = rentalManager.Add(rental);
    Console.WriteLine(result.Message);
}

static void GetCarsByBrandId(int id)
{
    CarManager carManager = new CarManager(new EfCarDal());

    var result = carManager.GetCarsByBrandId(id);
    foreach(var item in result.Data)
    {
        Console.WriteLine(item.BrandId);
    }
}