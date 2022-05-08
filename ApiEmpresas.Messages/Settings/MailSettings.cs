using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Messages.Settings
{
    /// <summary>
    /// Modelo de dados para capturar os parâmetros de envio de email
    /// </summary>
    public class MailSettings
    {
        public string Conta { get; set; }
        public string Senha { get; set; }
        public string Smtp { get; set; }
        public int Porta { get; set; }
    }
}
