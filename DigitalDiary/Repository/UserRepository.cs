using DigitalDiary.Interfaces;
using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDiary.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public User GetLogInInfo(string username, string password)
        {
            using (DigitalDiaryDataContext db = new DigitalDiaryDataContext())
            {
                var LogInDetails = db.Users.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
                return LogInDetails;
                //if(LogInDetails == null)
                //{
                //    return LogInDetails;
                //}
                //else
                //{
                //    //Session["UserId"] = LogInDetails.userid;
                //    return LogInDetails;
                //}
            }
        }
    }
}