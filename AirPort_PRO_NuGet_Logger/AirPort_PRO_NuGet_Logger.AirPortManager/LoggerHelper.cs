﻿using Microsoft.Extensions.Logging;
using System;

namespace AirPort_PRO_NuGet_Logger.AirPortManager
{
    static internal class LoggingHelper
    {
        private const string InfoLoggerTemplatePlane =
           "Заполнено {0} для самолета с идентификатором {1} и номерами \"{2}\", прошло время: {3} мс; дата: {4}";
        private const string ErrorLoggerTemplateAvto =
            "Не удалось заполнить {0} для самолета с идентификатором {1} и номерами \"{2}\", прошло время: {3} мс; дата: {4}; сообщение об ошибке: {5}";
        private const string ErrorLoggerTemplateCommon =
            "Не удалось завершить {0}, дата: {1}; сообщение об ошибке: {2}";

        /// <summary>
        /// Залогировать информацию о действии с самолетами
        /// </summary>
        public static void LogErrorPlane(ILogger logger, string actionName, Guid applicantId, long msElapsed, string errorMessage, string applicantName = null)
        {
            logger.LogError(
                string.Format(
                            ErrorLoggerTemplateAvto,
                            actionName,
                            applicantId,
                            applicantName ?? "-",
                            msElapsed,
                            DateTime.Now,
                            errorMessage
                            )
                );
        }

        /// <summary>
        /// Логирование ошибки при действии с самолетами
        /// </summary>
        public static void LogInfoAirPlane(ILogger logger, string actionName, Guid applicantId, long msElapsed, string applicantName = null)
        {
            logger.LogInformation(
                string.Format(
                              InfoLoggerTemplatePlane,
                              actionName,
                              applicantId,
                              applicantName ?? "-",
                              msElapsed,
                              DateTime.Now
                              )
                );
        }

        /// <summary>
        /// Логирование ошибки
        /// </summary>
        public static void LogError(ILogger logger, string actionName, string errorMessage)
        {
            logger.LogError(string.Format(
                                          ErrorLoggerTemplateCommon,
                                          actionName,
                                          DateTime.Now,
                                          errorMessage
                                          )
                );
        }
    }
}
