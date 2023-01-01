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
    public class AddressManager:IAdressService
    {
        IAdressDal _addessDal;

        public AddressManager(IAdressDal addessDal)
        {
            _addessDal = addessDal;
        }

        public void Delete(Adress t)
        {
            throw new NotImplementedException();
        }

        public Adress GetById(int id)
        {
            return _addessDal.GetById(id);
        }

        public List<Adress> GetListAll()
        {
            return _addessDal.GetListAll();
        }

        public void Insert(Adress t)
        {
            throw new NotImplementedException();
        }

        public void Update(Adress t)
        {
            _addessDal.Update(t);
        }
    }
}
