using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAccessoAiDati {
    public class Classe {
        public string Nome { get; set; }
        public string Settore { get; set; }

        public Classe(string nome, string settore) {
            Nome = nome;
            Settore = settore;
        }

        public Classe() {
        }
    }
}
