using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SahaManager : ISahaService
    {

        ISahaDurum _sahadurumdal;

        public SahaManager(ISahaDurum sahadurumdal)
        {



            _sahadurumdal = sahadurumdal;
        }

        public SahaDurum GetByID(int id)
        {
            return _sahadurumdal.Get(x => x.SahaId == id);
        }

        public List<SahaDurum> GetList()
        {
            return _sahadurumdal.List();
        }

        public List<SahaDurum> GetListByWriter(int id)
        {
            return _sahadurumdal.List(x => x.WriterID == id);
        }

        public void SahaAdd(SahaDurum saha)
        {
           _sahadurumdal.Insert(saha);
        }

        public void SahaDelete(SahaDurum saha)
        {
            _sahadurumdal.Delete(saha);
        }

        public void SahaUpdate(SahaDurum saha)
        {
            _sahadurumdal.Update(saha);
        }
    }
}
