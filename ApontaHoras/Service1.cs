using System;
using System.Collections.Generic;
using SimpleInjector;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ApontaHoras.Util.Interface;
using ApontaHoras.Controller.Interface;
using ApontaHoras.Controller;

namespace ApontaHoras
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var container = new Container();
            container.Register<IHelper, ApontaHoras.Util.Helper>();
            container.Register<IApontamentoController, ApontamentoController>();
            container.Register<IMailController, MailController>();

            var _apontamento = container.GetInstance<ApontamentoController>();
            _apontamento.DoAppointment();
        }

        protected override void OnStop()
        {
        }
    }
}
