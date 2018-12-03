using System;
using SQLite;

namespace SwimmingTool.Model
{
    [Table("registros")]
    public class Registro
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }

        public int numBrazadas { get; set; }
        public String time { get; set; }
    }
}
