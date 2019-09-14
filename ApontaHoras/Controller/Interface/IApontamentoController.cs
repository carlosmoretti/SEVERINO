using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApontaHoras.Controller.Interface
{
    public interface IApontamentoController
    {
        void DoAppointment();
        void ClearFields(IWebDriver driver);
    }
}
