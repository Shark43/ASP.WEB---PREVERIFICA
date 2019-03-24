using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAccessoAiDati {
    public class Result {
        public Result(string message, int status, bool isError) {
            Message = message;
            Status = status;
            this.isError = isError;
        }

        public Result() {
        }

        public string Message { get; set; }
        public int Status { get; set; }
        public bool isError { get; set; }

    }
}
