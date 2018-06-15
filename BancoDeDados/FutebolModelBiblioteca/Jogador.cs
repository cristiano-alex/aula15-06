using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolModelBiblioteca
{
    class Jogador
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public int Numero { get; set; }

        public int TimeId { get; set;}

        [ForeignKey("TimeId")]
        public Time Time { get; set; }
    }
}
