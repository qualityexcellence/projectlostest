using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestingProject1.EFContext;
using TestingProject1.Models;

namespace TestingProject1.Repositories
{
    public class CarRepository
    {
        private readonly EfDbContext _dbContext;

        public CarRepository()
        {
            _dbContext = new EfDbContext();
        }

       
        public Car Add(Car model)
        {

            try
            {
                if (model == null || string.IsNullOrWhiteSpace(model?.Name)) throw new Exception("Name is Required");
                if (string.IsNullOrWhiteSpace(model.Color)) throw new Exception("Color is Required");
                if (string.IsNullOrWhiteSpace(model.YearMade)) throw new Exception("Year Made is Required");
                if (model.YearMade.Trim().Length !=4) throw new Exception("Invalid Year Made");
                int year;
                int.TryParse(model.YearMade, out year);
                if (year<1) throw new Exception("Invalid Year Made");
                Car item = _dbContext.Cars.FirstOrDefault(u => u.Name.Trim().ToLower() == model.Name.Trim().ToLower() && u.Color.Trim().ToLower() == model.Color.Trim().ToLower()&& u.YearMade.Trim() == model.YearMade.Trim());
                if (item != null) { throw new Exception("Car Already Exist"); }
                _dbContext.Cars.Add(model);
                _dbContext.SaveChanges();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Car> LoadByYearmade(string yearmade)
        {

            try
            {
                if (yearmade.Trim().Length != 4) throw new Exception("Invalid Year Made");
                int year;
                int.TryParse(yearmade, out year);
                if (year < 1) throw new Exception("Invalid Year Made");
                
               return _dbContext.Cars.Where(u =>   u.YearMade.Trim() == yearmade.Trim()).ToList();
               
            }
            catch (Exception e)
            {
                _ = e.Message;
                throw;
            }
        }
        public Car Update(Car model)
        {

            try
            {
                if (model == null || model.Id<1) throw new Exception("Id is Required");
                if ( string.IsNullOrWhiteSpace(model?.Name)) throw new Exception("Name is Required");
                if (string.IsNullOrWhiteSpace(model.Color)) throw new Exception("Color is Required");
                if (string.IsNullOrWhiteSpace(model.YearMade)) throw new Exception("Year Made is Required");
                if (model.YearMade.Trim().Length != 4) throw new Exception("Invalid Year Made");
                int year;
                int.TryParse(model.YearMade, out year);
                if (year < 1) throw new Exception("Invalid Year Made");
                Car item = _dbContext.Cars.FirstOrDefault(u => u.Name.Trim().ToLower() == model.Name.Trim().ToLower() && u.Color.Trim().ToLower() == model.Color.Trim().ToLower() && u.YearMade.Trim() == model.YearMade.Trim()&& model.Id != u.Id);
                if (item != null) { throw new Exception("Car Already Exist"); }
                _dbContext.Cars.Add(model);
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}