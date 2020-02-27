using DigitalDiary.Interfaces;
using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDiary.Repository
{
    public class MemoryRepository : Repository<Memory>, IMemoryRepository
    {
        DigitalDiaryDataContext context;
        public MemoryRepository()
        {
            context = new DigitalDiaryDataContext();
        }
        public IEnumerable<Memory> GetUserMeoriesList(int userid)
        {
            //using (DigitalDiaryDataContext db = new DigitalDiaryDataContext())
            //{
            //    return db.Memories.Where(x => x.UserId == userid).ToList();
            //    //return UserMemoriesDetails;
            //}

            return context.Memories.Where(x => x.UserId == userid).ToList();
        }
    }
}