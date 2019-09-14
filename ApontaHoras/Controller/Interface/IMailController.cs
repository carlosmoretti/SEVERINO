using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApontaHoras.Controller.Interface
{
    public interface IMailController
    {
        void SendMail(string email, string semana);
        void SendMailError(string email);
    }
}
