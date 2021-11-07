
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSEat_Project
{
    public class BusinessExceptions : Exception 
    {
        private static long serialVersionUID = -446022369330950597L;

        private ErrorCodes errorCode { get; }

        
            public BusinessExceptions(string message) : base(message)
            {
            }
        
        public BusinessExceptions(String msg, ErrorCodes errorCode)
        : base(msg)
        {
            this.errorCode = errorCode;
        }

    }

    public class ErrorCodes
    {
        // = Classe de type Enuméré, Fonctionne comme les classes
        //Permet de gérer plus facilement le code d'erreur
        private int code{ get; }
        private string msg { get; }

        public ErrorCodes(int code)
        {
            this.code = code;
        }

    }
}
