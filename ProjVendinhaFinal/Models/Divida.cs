using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjVendinhaFinal.Models
{
    public class Divida
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public bool EstaPaga { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataPagamento { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
