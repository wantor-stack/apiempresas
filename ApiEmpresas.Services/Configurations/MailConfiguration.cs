﻿using ApiEmpresas.Messages.Services;
using ApiEmpresas.Messages.Settings;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe de configuração para serviço de envio de email
    /// </summary>
    public class MailConfiguration
    {
        /// <summary>
        /// Método para configuração do uso do serviço de email
        /// </summary>
        public static void AddMail(WebApplicationBuilder builder)
        {
            #region Capturar as configurações do appsettings.json

            var settings = builder.Configuration.GetSection("MailSettings");
            builder.Services.Configure<MailSettings>(settings);

            var mailSettings = settings.Get<MailSettings>();

            #endregion

            #region Injeção de dependência

            builder.Services.AddTransient(map => new MailService(mailSettings));

            #endregion
        }
    }
}



