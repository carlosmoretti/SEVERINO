using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ApontaHoras.Util;
using SimpleInjector;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ApontaHoras.Controller.Interface;
using ApontaHoras.Util.Interface;

namespace ApontaHoras.Controller
{
    public class ApontamentoController : Interface.IApontamentoController
    {
        private IHelper _helper;
        private Container _container;
        private IMailController _mailController;
        public ApontamentoController()
        {
            _container = new Container();
            _helper = _container.GetInstance<Helper>();
            _mailController = _container.GetInstance<MailController>();
        }

        public void ClearFields(IWebDriver driver)
        {
            for (int i = 1; i <= 30; i++)
            {
                try
                {
                    driver.FindElement(By.Name($"txtProject_{i.ToString("D2")}")).Clear();
                    var el = driver.FindElement(By.Name($"ddkActivity_{i.ToString("D2")}"));

                    SelectElement sel = new SelectElement(el);
                    sel.SelectByIndex(0);

                    driver.FindElement(By.Id($"txtDescription_{i.ToString("D2")}")).Clear();
                    driver.FindElement(By.Id($"txtMon_{i.ToString("D2")}")).Clear();
                    driver.FindElement(By.Id($"txtTue_{i.ToString("D2")}")).Clear();
                    driver.FindElement(By.Id($"txtWed_{i.ToString("D2")}")).Clear();
                    driver.FindElement(By.Id($"txtThu_{i.ToString("D2")}")).Clear();
                    driver.FindElement(By.Id($"txtFri_{i.ToString("D2")}")).Clear();
                }
                catch(Exception e)
                {
                    continue;
                }
            }
        }

        public void DoAppointment()
        {
            string url = $"https://{_helper.Login}:{_helper.Senha}@{_helper.Url}/";


            var opt = new FirefoxOptions();
            opt.AddArgument("--headless");

            IWebDriver _driver = new FirefoxDriver(opt);
            _driver.Navigate().GoToUrl(url);
            _driver.Navigate().GoToUrl($"https://{_helper.Login}:{_helper.Senha}@{_helper.Url}/SRAWebLightBeta/tabSRA.aspx");

            this.ClearFields(_driver);

            try
            {
                _driver.FindElement(By.Name("txtProject_01")).Clear();
                _driver.FindElement(By.Name("txtProject_01")).SendKeys(_helper.Projeto);
                _driver.FindElement(By.Name("ddkActivity_01")).SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown);
                _driver.FindElement(By.Name("txtDescription_01")).SendKeys(_helper.Titulo);

                _driver.FindElement(By.Id("txtMon_01")).SendKeys("8");
                _driver.FindElement(By.Id("txtTue_01")).SendKeys("8");
                _driver.FindElement(By.Id("txtWed_01")).SendKeys("8");
                _driver.FindElement(By.Id("txtThu_01")).SendKeys("8");
                _driver.FindElement(By.Id("txtFri_01")).SendKeys("8");

                IWebElement combo = _driver.FindElement(By.Id("ddkWeek"));
                SelectElement selected = new SelectElement(combo);
                var sel = selected.SelectedOption.Text;

                _driver.FindElement(By.Name("btnSaveUp")).Click();

                _mailController.SendMail(_helper.Email, sel);

            }
            catch (Exception) {
                _mailController.SendMailError(_helper.Email);
            };

            Console.WriteLine("Acabou a execução pai");
            _driver.Close();
        }
    }
}
