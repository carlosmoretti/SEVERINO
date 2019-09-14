using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApontaHoras.Util.Interface
{
    public interface IHelper
    {
        string Titulo { get; }
        string Projeto { get; }
        string Url { get; }
        string Login { get; }
        string Senha { get; }
        string SendGridApi { get; }
        string Email { get; }
    }
}
