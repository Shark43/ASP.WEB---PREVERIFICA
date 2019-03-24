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
        public IHttpActionResult GetStudentis() {
            DataList.getAllStudenti();
            return Json(content: DataList.Studentis);
        }
        //public List<Studenti> GetStudentis() {
        //    Studenti studenti = new Studenti();
        //    studenti.Nome = "prova";
        //    return (new List<Studenti>() { studenti });
        //}

        public IHttpActionResult GetStudente(int id) {
            return Json(content: DataList.getStudenteFromDB(id));
        }

        public IHttpActionResult deleteStudente(int id) {
            return Json(DataList.deleteStudentis(id));
        }

        //PER GESTIRE INSERIMENTO DI ARRAY DI STUDENTI
        [HttpPost]
        [Route("api/studenti/multiple")]
        public IHttpActionResult insertStudenti(List<Studenti> studenti) {
            return Json(DataList.insertStudentis(studenti));
        }
        public IHttpActionResult insertStudente(Studenti studente) {
            return Json(DataList.insertStudentis(studente));
        }

        [HttpPut]
        [Route("api/studenti/multiple")]
        public IHttpActionResult updateStudenti(List<Studenti> studenti) {
            return Json(DataList.updatesStudentis(studenti));
        }
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
