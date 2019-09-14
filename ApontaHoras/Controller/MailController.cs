using ApontaHoras.Util;
using ApontaHoras.Util.Interface;
using OpenQA.Selenium;
using SendGrid;
using SendGrid.Helpers.Mail;
using SimpleInjector;
namespace ApontaHoras.Controller
{
    public class MailController : Interface.IMailController
    {

        private IHelper _helper;
        private Container _container;
        public MailController()
        {
            _container = new Container();
            _helper = _container.GetInstance<Helper>();
        }

        public async void SendMail(string email, string semana)
        {
            var cli = new SendGridClient(_helper.SendGridApi);
            var from = new EmailAddress("profissional.casm@gmail.com", "Severino");
            var msg = MailHelper.CreateSingleEmail(from, new EmailAddress(email), $"SEVERINO | Apontei sua semana { semana } no SRA.", $"Olá, acabei de apontar sua semana { semana } no SRA da Softtek.", null);
            var reponse = await cli.SendEmailAsync(msg);
        }

        public async void SendMailError(string email)
        {
            var cli = new SendGridClient(_helper.SendGridApi);
            var from = new EmailAddress("profissional.casm@gmail.com", "Severino");
            var msg = MailHelper.CreateSingleEmail(from, new EmailAddress(email), $"SEVERINO | Não consegui apontar sua semana semana no SRA.", $"Tive um erro ao apontar sua semana. Tente fazer manualmente!", null);
            var reponse = await cli.SendEmailAsync(msg);
        }


    }
}
