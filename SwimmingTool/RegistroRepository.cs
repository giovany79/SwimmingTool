using System;
using SQLite;
using System.Collections.Generic;
    
namespace SwimmingTool
{
    public class RegistroRepository
    {
        //private string dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }



        public RegistroRepository(String dbPath)
        {
            dbPath = FileAccessHelper.GetLocalFilePath("swim.db3");
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Registro>();
            conn.CreateTable<Nadador>();
        }


        public void addNewRegistro(Registro registro)
        {
            int result = 0; 
            try
            {
                if (registro ==  null)
                    throw new Exception("Valid name required");

                result = conn.Insert(registro);
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, registro);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", registro, ex.Message);
            }
        }


        public List<Registro> GetAllRegistros()
        {
            try
            {
                return conn.Table<Registro>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Registro>();
        }

        public void addNewNadador(Nadador nadador)
        {
            int result = 0;
            try
            {
                if (nadador == null)
                    throw new Exception("Valid name required");

                result = conn.Insert(nadador);
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, nadador);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", nadador, ex.Message);
            }
        }


        public List<Nadador> GetAllNadadores()
        {
            try
            {
                return conn.Table<Nadador>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Nadador>();
        }

    }


}
