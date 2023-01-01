using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService //get Inherited from related Interface to implement it
    {
        private readonly IAnnouncumentDal _announcementDal;  //creating new object from Interface (DAL layer) to achieve CRUD operations 

        public AnnouncementManager(IAnnouncumentDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void AnnouncementStatustoFalse(int id)
        {
            _announcementDal.AnnouncementStatustoFalse(id);
        }

        public void AnnouncementStatustoTrue(int id)
        {
            _announcementDal.AnnouncementStatustoTrue(id);

        }

        public void Delete(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement GetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Announcement> GetListAll()
        {
           return _announcementDal.GetListAll();
        }

        public void Insert(Announcement t)
        {
            _announcementDal.Insert(t);
        }

        public void Update(Announcement t)
        {
           _announcementDal.Update(t);
        }
    }
}
