using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestRestaurante.Models
{
    public class Prato
    {
        public int id { get; set; }

        public string nmPrato { get; set; }

        public decimal vrPreco { get; set; }

        public Restaurante restaurante { get; set; }
    }
}