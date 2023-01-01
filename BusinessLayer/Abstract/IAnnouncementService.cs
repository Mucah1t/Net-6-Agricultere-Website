using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnnouncementService : IGenericService<Announcement>  //Inheriting GenericService according to the relevant table
    {
        void AnnouncementStatustoTrue(int id);

        void AnnouncementStatustoFalse(int id);

    }
}
