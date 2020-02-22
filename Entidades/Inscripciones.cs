using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistroInscripcion1.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }

        public DateTime Fecha { get; set; }

        public int EstudianteID { get; set; }

        public string Comentario { get; set; }

        public decimal Monto { get; set; }

        public decimal Balance { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            Fecha = DateTime.Now;
            EstudianteID = 0;
            Monto = 0;
            Balance = 0;
        }


    }
}
