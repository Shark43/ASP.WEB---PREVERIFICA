using Dapper.Contrib.Extensions;
using Newtonsoft.Json;

namespace ClassLibraryAccessoAiDati {
    //PER FAR FUNZIONARE ORM CHE MAPPA I DATI NEL DB AL INTERNO
    //DELLE CLASSI BISOGNA AGGIUNGERE DEI DECORATORI ALLA CLASSE

    //IL DECORATORE TABLE SPECICA IL NOME DELLA TABELLA A CUI SI RIFERISCE LA CLASSE NEL DB
    //es nome classe impiegati
    // nome tabella su db dipendenti
    //devo mettere Table("dipendenti") cosi lui capira che la classe impiegati si riferisce ai dipenti

    //NOME DELLA TABELLA SUL DB
    [Table("Students")]
    public class Studenti {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Anni { get; set; }

        //SPECIFICA CHE IL CAMPO SOTTOSTANTE E UNA CHIAVE PRIMARIA
        [Key]
        public int ID { get; set; }

        //SPECIFICA CHE IL CAMPO SOTTOSTANTE NON ESISTE NEL DB
        [Write(false)]
        [Computed]
        [JsonIgnore] //PER RIMUOVERE UN CAMPO DEL JSON
        public bool Changed { get; set; }

        public Studenti() {
            Changed = false;
        }

        public Studenti(string nome, string cognome, int anni) {
            Nome = nome;
            Cognome = cognome;
            Anni = anni;
            Changed = false;
        }
        public Studenti(int id, string nome, string cognome, int anni) {
            ID = id;
            Nome = nome;
            Cognome = cognome;
            Anni = anni;
            Changed = false;
        }
    }
}
