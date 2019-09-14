using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApontaHoras.Util
{
    public class Helper : Interface.IHelper
    {
        public string Titulo
        {
            get
            {
                return ConfigurationManager.AppSettings["titulo"];
            }
        }

        public string Projeto
        {
            get
            {
                return ConfigurationManager.AppSettings["projeto"];
            }
        }
        public string Url { get
            {
                return ConfigurationManager.AppSettings["url"];
            }
        }
        public string Login
        {
            get
            {
                return ConfigurationManager.AppSettings["login"];
            }
        }
        public string Senha
        {
            get
            {
                return ConfigurationManager.AppSettings["senha"];
            }
        }
        public string SendGridApi {
            get
            {
                return ConfigurationManager.AppSettings["sendgridApi"];
            }
        }
        public string Email
        {
            get
            {
                return ConfigurationManager.AppSettings["email"];
            }
        }
    }
}
