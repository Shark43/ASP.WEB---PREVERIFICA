using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace ClassLibraryAccessoAiDati {
    public class DataList {
        public static BindingList<Studenti> Studentis { get; set; } = new BindingList<Studenti>();
        public static BindingList<Classe> Classes { get; set; } = new BindingList<Classe>();

        //stringa di connessione per access
        //public static string connectionString { get; } = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.GetData("DataDirectory") + "\\per_verifica.accdb";
        //stringa di connesione per sql server
        public static string ConnectionString { get; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.GetData("DataDirectory") + "\\test.mdf";

        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Scuola\informatica\ASP\PerVerifica\WebApplicationAPI\App_Data\per_verifica.accdb
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Scuola\informatica\ASP\PerVerifica\WebApplicationAPI\App_Data\test.mdf;Integrated Security=True;Connect Timeout=30
        public static bool GetAllStudenti() {
            //LEGGE DAL DB TUTTI GLI ELEMENTI E LI CARICA IN UNA LISTA
            try {
                using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                    connection.Open();
                    //connection.GetAll<Nome classe> prende tutti i dati dal db della determinata classe e li mappa nel db restituendo una lista con tutti gli oggetti gia caricati
                    DataList.Studentis = new BindingList<Studenti>(connection.GetAll<Studenti>().ToList());
                    //stampa nella console del debugger
                    System.Diagnostics.Debug.WriteLine("GET ALL FINISHED");

                    return true;
                }
            }
            catch(Exception ex) {
                Debug.WriteLine(ex);
                Studentis = new BindingList<Studenti>();
                return false;
            }
        }

        //Funzione per ottenere una lista di studenti in base al nome, il parametro e caricato dinamicamente nella query
        public static BindingList<Studenti> GetStudentiByName(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string sql = "SELECT * FROM studenti WHERE Name=@name1";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("name1",name);
                    Debug.WriteLine("GET Student by Name FINISHED");
                    return new BindingList<Studenti>(connection.Query<Studenti>(sql, parameters).ToList());                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new BindingList<Studenti>();
            }
        }

        public static BindingList<Studenti> ExecuteQueryStudenti(string sql, DynamicParameters parameters) {
            try {
                using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                    Debug.WriteLine("GET Student by Name FINISHED");
                    return new BindingList<Studenti>(connection.Query<Studenti>(sql, parameters).ToList());
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);
                return new BindingList<Studenti>();
            }
        }

        public static bool DeleteStudentis(int toDelete) {
            //ELIMINA ELEMENTO CON ID = toDelete
            //CERCA NELLA LISTA L'ELEMENTO CON ID = toDelete E LO ELIMINA
            IEnumerable<Studenti> ie = Studentis.Where(s => s.ID == toDelete);
            var enumerable = ie as Studenti[] ?? ie.ToArray();
            if(enumerable.Count() == 1) {
                Studentis.Remove(enumerable.First());
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                connection.Open();
                //CREA UN OGGETTO CON ID = toDelete E LO ELIMINA DAL DB
                return connection.Delete(new Studenti { ID = toDelete});
            }
        }

        //AGGIORNA(UPDATE) GLI ELEMENTI CONTENUTI NELLA LISTA
        public static bool UpdatesStudentis(List<Studenti> studentis) {
            using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                connection.Open();
                return connection.Update(studentis);
            }
        }
        //AGGIORNA(UPDATE) ELEMENTO PASSATO
        public static bool UpdatesStudentis(Studenti studentis) {
            using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                connection.Open();
                return connection.Update(studentis);
            }
        }
        public static Studenti GetStudenteFromDb(int studenteCode) {
            //RESTITUISCE L'ELEMENTO CON UN DETERMINATO ID
            using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                connection.Open();
                return connection.Get<Studenti>(studenteCode);
            }
        }
        public static long InsertStudentis(List<Studenti> studenti) {
            using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                connection.Open();
                //RITORNA IL NUMERO DI ELEMENTI AGGIUNTI
                int ninserted = Convert.ToInt32(connection.Insert(studenti));

                //AGGIORNAMENTO ASCINCRONO DELLA LISTA
                new Task(() => { GetAllStudenti(); }).Start();
                return ninserted;
            }
        }
        public static long InsertStudentis(Studenti studenti) {
            using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                connection.Open();
                //RITORNA ID DEL ELEMENTO AGGIUNTO
                int id = Convert.ToInt32(connection.Insert(studenti));
                //ASSEGNO ID AL ELEMENTO AGGIUNTO
                studenti.ID = id;
                Studentis.Add(studenti);
                return id;
            }
        }
        #region ACCESS
        //PER ACCESS
        //public static long insertStudentis(Studenti studenti) {
        //    using (SqlConnection connection = new SqlConnection(connectionString)) {
        //        connection.Open();
        //        studenti.ID = -1;
        //        int id = Convert.ToInt32(connection.Insert(new Studenti { Nome= studenti.Cognome, Cognome= studenti.Cognome, Anni=studenti.Anni}));
        //        studenti.ID = id;
        //        DataList.Studentis.Add(studenti);
        //        return id;
        //    }
        //}

        //public static bool getAllStudenti() {
        //    using (OleDbConnection connection = new OleDbConnection(connectionString)) {
        //        connection.Open();
        //        DataList.Studentis = new BindingList<Studenti>(connection.GetAll<Studenti>().ToList());
        //    }
        //    return true;
        //}

        //public static bool deleteStudentis(int toDelete) {
        //    DataList.Studentis.Remove(DataList.Studentis.First(s => s.ID == toDelete));
        //    using (OleDbConnection connection = new OleDbConnection(connectionString)) {
        //        connection.Open();
        //        return connection.Delete(new Studenti { ID = toDelete });
        //    }
        //}

        //public static bool updatesStudentis() {
        //    using (OleDbConnection connection = new OleDbConnection(connectionString)) {
        //        connection.Open();
        //        return true;
        //        //return connection.Update(DataList.Studentis.ToList().FindAll(s => s.Changed == true));
        //    }
        //}

        //public static Studenti getStudenteFromDB(int studente_code) {
        //    using (OleDbConnection connection = new OleDbConnection(connectionString)) {
        //        connection.Open();
        //        return connection.Get<Studenti>(studente_code);
        //    }
        //}

        //public static Studenti getStudenteFromDB(int studente_code) {
        //    return Studentis.Where(s => s.ID == studente_code).First();
        //}
        #endregion


        public static bool GetAllClassi() {
            Classes = new BindingList<Classe> { new Classe("5", "INF"), new Classe("4", "INF") };

            return true;
        }
    }
}
