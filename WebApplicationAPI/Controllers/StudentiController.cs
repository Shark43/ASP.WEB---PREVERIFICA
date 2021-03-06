﻿using System.Collections.Generic;
using System.Web.Http;
using ClassLibraryAccessoAiDati;
using Dapper;
namespace WebApplicationAPI.Controllers
{
    //IMPOSTA IN MANIERA STATICA IL PATH PER ACCEDERE ALLA RISORSA
    //API/TEST
    //[Route("api/test")]
    //API/STUDENTI
    //[Route("api/studenti")]
    public class StudentiController : ApiController
    {
        //GET api/studenti/
        public IHttpActionResult GetStudentis() {
            DataList.GetAllStudenti();
            return Json(content: DataList.Studentis);
        }
        //public List<Studenti> GetStudentis() {
        //    Studenti studenti = new Studenti();
        //    studenti.Nome = "prova";
        //    return (new List<Studenti>() { studenti });
        //}
        //public List<Studenti> GetStudentis() {
        //DataList.getAllStudenti();
        //    return (DataList.Studentis);
        //}

        //GET api/studenti/ID_STUDENTE
        public IHttpActionResult GetStudente(int id) {
            return Json(content: DataList.GetStudenteFromDb(id));
        }

        [HttpGet]
        [Route("api/studenti/filterByCognome/{cognome}")]
        public IHttpActionResult GetStudenteByCognome(string cognome) {
            //SQL NON SUPPORTA IL CONFRONTO DEI CAMPI DI TIPO TEXT QUINDI DEVI CONVERTIRE IL CAMPO IN VARCHAR
            string sql = "SELECT * FROM Students WHERE CONVERT(VARCHAR, Cognome) = @cognome";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cognome", cognome);
            return Json(content: DataList.ExecuteQuery(sql, parameters));
        }

        //DELETE api/studenti/ID_STUDENTE
        public IHttpActionResult deleteStudente(int id) {
            //return Json(content: DataList.deleteStudentis(id));
            bool deleted = DataList.DeleteStudentis(id);
            //creao un oggetto result a cui gli passo il messaggi di successo o errore
            return Json(content: new Result { Message = deleted ? $"eliminato {id} con successo" : "errore durante eliminazione", isError = !deleted, Status = deleted ? 200 : 500 });
        }

        //PER GESTIRE INSERIMENTO DI ARRAY DI STUDENTI
        //POST api/studenti/multiple - in post [{oggetto da inserire},{nome: nome, cognome:cognome, anni:anni}, ecc]
        [HttpPost]
        [Route("api/studenti/multiple")]
        public IHttpActionResult InsertStudenti(List<Studenti> studenti) {
            return Json(DataList.InsertStudentis(studenti));
        }
        //POST api/studenti - in post {Nome: nome, Cognome: cognome, Anni: anni}
        public IHttpActionResult insertStudente(Studenti studente) {
            return Json(DataList.InsertStudentis(studente));
        }

        //PER GESTIRE AGGIORNAMENTO DI ARRAY DI STUDENTI
        //PUT api/studenti/multiple [{},{}, ecc]
        [HttpPut]
        [Route("api/studenti/multiple")]
        public IHttpActionResult UpdateStudenti(List<Studenti> studenti) {
            return Json(DataList.UpdatesStudentis(studenti));
        }
        //PUT api/studenti in put {Nome: nome, Cognome: cognome, Anni: anni}
        [HttpPut]
        public IHttpActionResult UpdateStudenti(Studenti studente) {
            return Json(DataList.UpdatesStudentis(studente));
        }

        //Ricerche avanzate con query custom con parametri dinamici No sql-Injectio guys :( 
        [HttpGet]
        public IHttpActionResult GetStudentiByName(string Name)
        {
            return Json(DataList.GetStudentiByName(Name));
        }

        //GET: API/STUDENTI/TEST
        //[Route("studenti/test")]
        //public IHttpActionResult GetStudentis2() {
        //    DataList.getAllStudenti();
        //    return Json(content: DataList.Studentis);
        //}
    }
}
