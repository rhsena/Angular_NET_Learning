using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto2.Models.DAO
{
    public class OperadoraDAO
    {

        public void Insert(Operadora operadora)
        {
            using (ApplicationDbContext dbcontext = new ApplicationDbContext())
            {
                dbcontext.Operadoras.Add(operadora);
                dbcontext.SaveChanges();
            }
        }

        public IQueryable<Operadora> Get()
        {
            using (ApplicationDbContext dbcontext = new ApplicationDbContext())
            {
                return  dbcontext.Operadoras;
            }
        }

        public Operadora GetbyId(int id)
        {
            Operadora operadora = new Operadora();
            using (ApplicationDbContext dbcontext = new ApplicationDbContext())
            {
                operadora = dbcontext.Operadoras.Find(id);
            }
            return operadora;
        }
    }
}