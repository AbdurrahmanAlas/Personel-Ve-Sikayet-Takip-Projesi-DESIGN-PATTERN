using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repositories
{
    public class HeadingRepository : IHeadingDal
    {
        Context c = new Context();
        DbSet<Heading> _object;

        public void Delete(Heading p)
        {
            throw new NotImplementedException();
        }

        public Heading Get(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Heading p)
        {
            throw new NotImplementedException();
        }

        public List<Heading> List()
        {
            throw new NotImplementedException();
        }

        public List<Heading> List(Expression<Func<Heading, bool>> filter)
        {
            return c.Set<Heading>().Where(filter).ToList();
        }

        public object OrderByDescending(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public void Update(Heading p)
        {
            throw new NotImplementedException();
        }
    }
}
