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
    public class PunishmentManager : ICezaService
    {
        ICezaDal  _cezaDal;

        public PunishmentManager(ICezaDal cezaDal)
        {
            _cezaDal = cezaDal;
        }

        public void AddCeza(Punishment punishment)
        {
            _cezaDal.Insert(punishment);
        }

        public void DeleteCeza(Punishment punishment)
        {
            _cezaDal.Delete(punishment);
        }

        public Punishment GetByID(int id)
        {
            return _cezaDal.Get(x => x.CezaId == id);
        }

        public List<Punishment> GetList()
        {
            return _cezaDal.List();
        }

        public void UpdateCeza(Punishment punishment)
        {
            _cezaDal.Update(punishment);
        }
    }
}
