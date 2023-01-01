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
    public class ImageManager : IImageService //get Inherited from related Interface to implement it
    {
        private readonly IImageDal _imageDal;  //creating object from related DAL

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void Delete(Image t)
        {
            _imageDal.Delete(t);
        }

        public Image GetById(int id)
        {
            return _imageDal.GetById(id);
        }

        public List<Image> GetListAll()
        {
            return _imageDal.GetListAll();
        }

        public void Insert(Image t)
        {
            _imageDal.Insert(t);    
        }

        public void Update(Image t)
        {
            _imageDal.Update(t);
        }
    }
}
