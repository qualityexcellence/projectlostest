using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingProject1.EFContext;
using TestingProject1.Models;

namespace TestingProject1.Repositories
{
    public class UserRepository
    {
        private readonly EfDbContext _dbContext;

        public UserRepository()
        {
            _dbContext = new EfDbContext();
        }

        public User Login(string username, string password)
        {
            try
            {
                if ( string.IsNullOrWhiteSpace(username)) throw new Exception("username is Required");
                if (string.IsNullOrWhiteSpace(password)) throw new Exception("password is Required");
               // var users = _dbContext.Users.ToList();
                User user = _dbContext.Users.ToList().FirstOrDefault(u => u.username.Trim().ToLower() == username.Trim().ToLower() && u.password.Trim() == password.Trim());
                return user;
            }
            catch (Exception e)
            {
                _ = e.Message;
                throw;
            }
           
        }
        public User Add(User model)
        {

            try
            {
                if (model == null || string.IsNullOrWhiteSpace(model?.username)) throw new Exception("username is Required");
                if (string.IsNullOrWhiteSpace(model.password)) throw new Exception("password is Required");
                User user = _dbContext.Users.FirstOrDefault(u => u.username.Trim().ToLowerInvariant() == model.username.Trim().ToLowerInvariant());
                if (user != null) { throw new Exception("Username Already Exist"); }
                _dbContext.Users.Add(model);
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