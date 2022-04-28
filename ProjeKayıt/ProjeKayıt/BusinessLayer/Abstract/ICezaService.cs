using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface ICezaService
    {
        void AddCeza(Punishment punishment);
        void DeleteCeza(Punishment punishment);
        void UpdateCeza(Punishment punishment);
        List<Punishment> GetList();
        Punishment GetByID(int id);

    }
}
