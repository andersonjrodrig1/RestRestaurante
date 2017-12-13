using RestRestaurante.DataContext;
using RestRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestRestaurante.Service
{
    public class PratoService
    {
        public List<Prato> buscarPratos()
        {
            DbContexto db = new DbContexto();

            var pratos = db.prato.ToList();

            if (pratos != null && pratos.Count > 0)
            {
                var resturantes = db.restaurante.ToList();

                foreach(var prato in pratos)
                {
                    prato.restaurante = resturantes
                        .Where(r => r.id == prato.restaurante.id)
                        .FirstOrDefault();
                }
            }

            return pratos;
        }

        public List<Prato> buscarPratosPorRestaurante(Restaurante restaurante)
        {
            DbContexto db = new DbContexto();
            var restaurantes = db.prato.Where(p => p.restaurante.id == restaurante.id).ToList();

            return restaurantes;
        }

        public void cadastrarPrato(Prato prato)
        {
            DbContexto db = new DbContexto();

            var prt = this.buscarPratos().Where(p => p.id == prato.id).FirstOrDefault();
            var restaurante = new RestauranteService().buscarRestaurantes().Where(r => r.id == prato.restaurante.id).FirstOrDefault();

            prato.restaurante = restaurante;            

            if (prt != null)
            {
                db.prato.Attach(prato);
                db.Entry(prato).State = EntityState.Modified;
            }

            db.prato.Add(prato);
            db.SaveChanges();
        }

        public void removerPrato(Prato prato)
        {
            DbContexto db = new DbContexto();
            db.prato.Attach(prato);
            db.Entry(prato).State = EntityState.Deleted;

            db.SaveChanges();
        }

        public void removerPrato(List<Prato> pratos)
        {
            DbContexto db = new DbContexto();
            pratos.ForEach(prato => db.Entry(prato).State = EntityState.Deleted);

            db.SaveChanges();
        }
    }
}