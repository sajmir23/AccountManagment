﻿using Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager() { }

       public void LogInfo(string message)=> logger.Info(message);
       public void LogWarning(string message)=> logger.Warn(message);
       public void LogError(string message)=> logger.Error(message);
       public void LogDebug(string message)=> logger.Debug(message);
    }
}
