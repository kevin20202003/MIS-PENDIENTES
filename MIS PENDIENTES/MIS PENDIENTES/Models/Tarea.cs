using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIS_PENDIENTES.Models
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public bool EstaTerminada { get; set; }
    }
}
