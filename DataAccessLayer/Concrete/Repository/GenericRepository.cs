using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new() //GR is inherited from GD and implements the interface
    {
        public void Delete(T t)
        {
            using var context = new AgricultureContext(); //creating new object from AgrContex

            context.Remove(t);
            context.SaveChanges();

        }

        public T GetById(int id)
        {
            using var context = new AgricultureContext();

            return context.Set<T>().Find(id);   //Find and return the id of the value with respect to T
        }

        public List<T> GetListAll()
        {
            using var context = new AgricultureContext();

            return context.Set<T>().ToList();    // It will be sent to the list according to the T Value
        }

        public void Insert(T t)
        {
            using var context = new AgricultureContext();

            context.Add(t);         
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new AgricultureContext();

            context.Update(t);
            context.SaveChanges();
        }
    }
}

