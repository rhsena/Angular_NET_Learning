using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto2.Models.DAO
{
    public class ContatoDAO
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Contato> Get()
        {
            //IEnumerable<Contato> contatos;
            using (ApplicationDbContext dbcontext = new ApplicationDbContext())
            {
                return dbcontext.Contatos.Include(o=> o.Operadora).ToList();
                #region join comentada
                //var innerjoin = from contatos in dbcontext.Contatos
                //            join operadora in dbcontext.Operadoras on contatos.Operadora.OperadoraID equals operadora.OperadoraID
                //             select new Contato {
                //                  ContatoID = contatos.ContatoID, NomeContato = contatos.NomeContato,
                //                  TelefoneContato = contatos.TelefoneContato,
                //                  Operadora = new Operadora { OperadoraID = operadora.OperadoraID, CodigoOperadora = operadora.CodigoOperadora,
                //                                               NomeOperadora = operadora.NomeOperadora, Tipo = operadora.Tipo}
                //             };
                #endregion
            }


        }


        public void Insert(Contato contato)
        {
            using (ApplicationDbContext dbcontext = new ApplicationDbContext())
            {
                dbcontext.Contatos.Add(contato);
                dbcontext.SaveChanges();
            }

        }

        public Contato GetById(int id)
        {
            Contato contato;
            using (ApplicationDbContext dbcontext = new ApplicationDbContext())
            {
                contato = db.Contatos.Find(id);
            }
            return contato;
        }

        public void Update(Contato contato)
        {
            using (ApplicationDbContext dbcontext = new ApplicationDbContext())
            {
                dbcontext.Entry(contato).State = EntityState.Modified;
                dbcontext.SaveChanges();
            }
            throw new NotImplementedException();
        }
    }
}