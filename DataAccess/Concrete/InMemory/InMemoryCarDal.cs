using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{ CarID=1, ColorID=1, DailyPrice=5000, ModelYear=2015, Description=" volkwagen Golf", BrandID=1 },
                new Car{ CarID=2, ColorID=2, DailyPrice=3000, ModelYear=2012, Description="Opel Corsa" , BrandID=2},
                new Car{ CarID=3, ColorID=1, DailyPrice=8000, ModelYear=2005, Description="volkwagen Passat", BrandID=3},
                new Car{CarID=4, BrandID=4, ColorID=4, ModelYear=2018, DailyPrice=4000, Description="Renault Magane" },
                new Car{CarID=5, BrandID=5, ColorID=5, ModelYear=2020, DailyPrice=5000, Description="Opel Astra" }

            };
            // TestAny();
            // AscDescTest();
            //ClassicLinqTest();

        }

        private void ClassicLinqTest()
        {
            var result = from c in _cars
                         where c.ModelYear > 2010
                         orderby c.DailyPrice descending
                         select c;

            foreach (var car in result)
            {
                Console.WriteLine(car.DailyPrice);
            }
        }

        private void AscDescTest()
        {
            var result = _cars.Where(c => c.Description.Contains("wagen")).OrderByDescending(c => c.ColorID).ThenBy(c => c.Description);
            foreach (var car in result)
            {
                Console.WriteLine(car.ModelYear);
            }
        }

        private void TestAny()
        {
            var result = _cars.Any(c => c.ColorID == 3);
            Console.WriteLine(result);
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.CarID    == car.CarID);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarID == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate= _cars.SingleOrDefault(c => c.CarID== car.CarID);
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
