using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace SQLITE_BOOK.Clases
{
    class Libros
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Anio { get; set; }

        public override string ToString()
        {
            return $"{Titulo} - {Autor} - {Anio}";
        }
    }
}
