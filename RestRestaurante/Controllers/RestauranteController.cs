using RestRestaurante.DataContext;
using RestRestaurante.Models;
using RestRestaurante.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace RestRestaurante.Controllers
{
    [RoutePrefix("api/restaurante")]
    public class RestauranteController : ApiController
    {
        //Get
        [HttpGet]
        [Route("buscar")]
        public List<Restaurante> buscaRestaurantes()
        {
            try
            {
                return new RestauranteService().buscarRestaurantes();
            }
            catch(Exception ex)
            {
                throw new Exception("Falha ao buscar dados!");
            }
        }

        //Get
        [HttpGet]
        [Route("pesquisar/{nome?}")]
        public List<Restaurante> pesquisarRestaurantes(string nome = null)
        {
            try
            {
                return new RestauranteService().buscarRestaurantes(nome);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao buscar dados!");
            }
        }

        //Delete
        [HttpDelete]
        [Route("remover")]
        public void removerRestaurante(Restaurante restaurante)
        {
            try
            {
                new RestauranteService().removerRestaurante(restaurante);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao deletar dados!");
            }
        }

        //Post
        [HttpPost]
        [Route("cadastrar")]
        public void cadastrarRestaurante([FromBody]Restaurante restaurante)
        {
            try
            {
                new RestauranteService().cadastrarRestaurante(restaurante);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao deletar dados!");
            }
        }
    }
}
