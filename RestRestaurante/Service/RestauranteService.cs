using RestRestaurante.DataContext;
using RestRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestRestaurante.Service
{
    public class RestauranteService
    {
        public List<Restaurante> buscarRestaurantes()
        {
            DbContexto db = new DbContexto();
            var restaurantes = db.restaurante.ToList();

            return restaurantes;
        }

        public List<Restaurante> buscarRestaurantes(string nome)
        {
            var restaurantes = this.buscarRestaurantes();

            if(nome != null)
                restaurantes = restaurantes
                    .Where(r => r.nmRestaurante.ToUpper().Contains(nome.ToUpper()))
                    .ToList();

            return restaurantes;
        }

        public void removerRestaurante(Restaurante restaurante)
        {
            DbContexto db = new DbContexto();

            var pratos = new PratoService().buscarPratosPorRestaurante(restaurante);

            if(pratos != null && pratos.Count > 0)
                new PratoService().removerPrato(pratos);

            db.restaurante.Attach(restaurante);
            db.Entry(restaurante).State = EntityState.Deleted;

            db.SaveChanges();
        }

        public void cadastrarRestaurante(Restaurante restaurante)
        {
            var rest = this.buscarRestaurantes().Where(r => r.id == restaurante.id).FirstOrDefault();

            DbContexto db = new DbContexto();
            db.restaurante.Add(restaurante);

            if(rest != null)
                db.Entry(restaurante).State = EntityState.Modified;

            db.SaveChanges();
        }
    }
}