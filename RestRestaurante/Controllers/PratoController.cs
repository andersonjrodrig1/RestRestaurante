using RestRestaurante.Models;
using RestRestaurante.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestRestaurante.Controllers
{
    [RoutePrefix("api/prato")]
    public class PratoController : ApiController
    {
        //Get
        [HttpGet]
        [Route("buscar")]
        public List<Prato> buscarPratos()
        {
            try
            {
                return new PratoService().buscarPratos();
            }
            catch(Exception e)
            {
                throw new Exception("Falha ao buscar dados!");
            }
        }

        //Post
        [HttpPost]
        [Route("cadastrar")]
        public void cadastrarPrato([FromBody]Prato prato)
        {
            try
            {
                new PratoService().cadastrarPrato(prato);
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao cadastrar dados!");
            }
        }

        //Delete
        [HttpDelete]
        [Route("remover")]
        public void removerPrato([FromBody]Prato prato)
        {
            try
            {
                new PratoService().removerPrato(prato);
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao remover dados!");
            }
        }
    }
}
