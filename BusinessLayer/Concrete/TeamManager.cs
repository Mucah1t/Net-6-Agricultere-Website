using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TeamManager: ITeamService  //Inheriting from the related service, abstratc is included now. Then, we implemented the interface
    {
        private readonly ITeamDal _teamDal;  //creating object from related DAL

        public TeamManager(ITeamDal teamDal) // It has assigned with constructor
        {
            _teamDal = teamDal;
        }

        public void Delete(Team t)
        {
            _teamDal.Delete(t); 
        }

        public Team GetById(int id)
        {
            return _teamDal.GetById(id);
        }

        public List<Team> GetListAll()
        {
            return _teamDal.GetListAll();
        }

        public void Insert(Team t)
        {
            _teamDal.Insert(t);
        }

        public void Update(Team t)
        {
            _teamDal.Update(t);
        }
    }
}
