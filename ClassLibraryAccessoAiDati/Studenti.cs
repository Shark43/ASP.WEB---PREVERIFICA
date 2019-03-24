using Dapper.Contrib.Extensions;

namespace ClassLibraryAccessoAiDati {
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
