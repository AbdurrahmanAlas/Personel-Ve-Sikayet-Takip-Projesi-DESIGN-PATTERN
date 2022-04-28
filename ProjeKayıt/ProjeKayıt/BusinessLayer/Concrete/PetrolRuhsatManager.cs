using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PetrolRuhsatManager : IPetrolRuhsatService
    {

        IPetrolRuhsatDal _petrolRuhsatDal;

        public PetrolRuhsatManager(IPetrolRuhsatDal petrolRuhsatDal)
        {
            _petrolRuhsatDal = petrolRuhsatDal;
        }

        public PetrolRuhsat GetByID(int id)
        {
            return _petrolRuhsatDal.Get(x => x.PetrolId == id);
        }

        public List<PetrolRuhsat> GetList()
        {
            return _petrolRuhsatDal.List();
        }

        public List<PetrolRuhsat> GetListByWriter(int id)
        {
            return _petrolRuhsatDal.List(x => x.WriterID == id);
        }

        public void PetrolRuhsatAdd(PetrolRuhsat heading)
        {
            _petrolRuhsatDal.Insert(heading);
        }

        public void PetrolRuhsatDelete(PetrolRuhsat heading)
        {
            _petrolRuhsatDal.Delete(heading);
        }

        public void PetrolRuhsatUpdate(PetrolRuhsat heading)
        {
            _petrolRuhsatDal.Update(heading);
        }
    }
}
