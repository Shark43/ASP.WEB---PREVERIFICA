using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibraryAccessoAiDati;
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
            DataList.getAllStudenti();
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
            return Json(content: DataList.getStudenteFromDB(id));
        }

        //DELETE api/studenti/ID_STUDENTE
        public IHttpActionResult deleteStudente(int id) {
            //return Json(content: DataList.deleteStudentis(id));
            bool deleted = DataList.deleteStudentis(id);
            //creao un oggetto result a cui gli passo il messaggi di successo o errore
            return Json(content: new Result { Message = deleted ? $"eliminato {id} con successo" : "errore durante eliminazione", isError = !deleted, Status = deleted ? 200 : 500 });
        }

        //PER GESTIRE INSERIMENTO DI ARRAY DI STUDENTI
        //POST api/studenti/multiple - in post [{oggetto da inserire},{nome: nome, cognome:cognome, anni:anni}, ecc]
        [HttpPost]
        [Route("api/studenti/multiple")]
        public IHttpActionResult insertStudenti(List<Studenti> studenti) {
            return Json(DataList.insertStudentis(studenti));
        }
        //POST api/studenti - in post {Nome: nome, Cognome: cognome, Anni: anni}
        public IHttpActionResult insertStudente(Studenti studente) {
            return Json(DataList.insertStudentis(studente));
        }

        //PER GESTIRE AGGIORNAMENTO DI ARRAY DI STUDENTI
        //PUT api/studenti/multiple [{},{}, ecc]
        [HttpPut]
        [Route("api/studenti/multiple")]
        public IHttpActionResult updateStudenti(List<Studenti> studenti) {
            return Json(DataList.updatesStudentis(studenti));
        }
        //PUT api/studenti in put {Nome: nome, Cognome: cognome, Anni: anni}
        [HttpPut]
        public IHttpActionResult updateStudenti(Studenti studente) {
            return Json(DataList.updatesStudentis(studente));
        }

        //GET: API/STUDENTI/TEST
        //[Route("studenti/test")]
        //public IHttpActionResult GetStudentis2() {
        //    DataList.getAllStudenti();
        //    return Json(content: DataList.Studentis);
        //}



    }
}
