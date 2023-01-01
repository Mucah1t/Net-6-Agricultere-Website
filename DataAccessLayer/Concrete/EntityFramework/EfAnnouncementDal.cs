using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncumentDal //this will be inherited from the generic then this will take interface from related dal
    {
        public void AnnouncementStatustoFalse(int id)
        {
            using var context = new AgricultureContext();
            Announcement p = context.Announcements.Find(id);
            p.Status = false;
            context.SaveChanges();
        }

        public void AnnouncementStatustoTrue(int id)
        {
            using var context = new AgricultureContext();
            Announcement p = context.Announcements.Find(id);
            p.Status = true;
            context.SaveChanges();
        }
    }
}
