using System;
using SQLite;

namespace SwimmingTool.Model
{
    [Table("nadadores")]
    public class Nadador
    {

        [PrimaryKey, AutoIncrement]
        public String documentId { get; set; }
        public String nombre { get; set; }
        public Boolean sexo { get; set; }
        public int estatura { get; set; }
        public int longitudBrazo { get; set; }

    }
}
