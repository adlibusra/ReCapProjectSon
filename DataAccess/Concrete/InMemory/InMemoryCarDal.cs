using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id=1, ColorId=1, DailyPrice=5000, ModelYear=2005, Description=" volkwagen Golf", BrandId=1 },
                new Car{ Id=2, ColorId=2, DailyPrice=3000, ModelYear=2012, Description="Opel Corsa" , BrandId=2},
                new Car{ Id=3, ColorId=3, DailyPrice=8000, ModelYear=2015, Description="Passat", BrandId=3},
                new Car{Id=4, BrandId=4, ColorId=4, ModelYear=2018, DailyPrice=4000, Description="Renault Magane" },
                new Car{Id=5, BrandId=5, ColorId=5, ModelYear=2020, DailyPrice=5000, Description="Opel Astra" }

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate= _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;

        }
    }
}
