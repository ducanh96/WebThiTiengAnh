using Shop.Models.DTO;
using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.Dao
{
    public class UserDao
    {
        public MyDB db = new MyDB();
        public UserDao()
        {
            
        }
        public  int LoginCheck(string userName, string password)
        {

            int check = db.Users.Count(x => x.userName == userName && x.password == password);

            return check;
        }
        public  List<User> getAllData()
        {

            List<User> lstUser = db.Users.ToList();

            return lstUser;
        }
        public  User getSinglData(string userName)
        {
            return db.Users.SingleOrDefault(x => x.userName == userName);
        }
        public  int addUser(User pd)
        {
            int k = db.Users.Count(x => x.userName == pd.userName);
            if (k > 0)
            {
                return 0;
            }
            else
            {
                try
                {
                    db.Users.Add(pd);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return -1;
                }
            }
            
        }
        //public static User getSinglData(int idPD)
        //{
        //    return db.Users.SingleOrDefault(x => x.idPD == idPD);
        //}
        public  bool updateUser(User pd)
        {
            User pdx = db.Users.Find(pd.userName);
            try
            {
               
                pdx.Quyen = pd.Quyen;
                pdx.phone = pd.phone;
                pdx.password = pd.password;
                
                pdx.fullName = pd.fullName;
                pdx.email = pd.email;
                pdx.address = pd.address;
                pdx.birthDay = pd.birthDay; pdx.userName = pd.userName;
           

                db.SaveChanges();
            return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public  bool deleteUser(string userName)
        {
            User pd = db.Users.Find(userName);
            if (pd != null)
            {
                db.Users.Remove(pd);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
          ///linq
          public IQueryable<User> listUser()
        {
            var rs = (from s in db.Users   select s);
            return rs;
        }
        //public IQueryable<UserDTO> listUserDTO()
        ////{
        ////    var rs = (from s in db.Users
        ////              join gr in db.UsersGroup
        ////              on s.Quyen equals gr.quyen
        ////              select new UserDTO {
        ////                UserName=s.UserName,
        ////                userGroup=gr.UseGroupName
        ////              });
        //    return rs;
        //}
    }
}
