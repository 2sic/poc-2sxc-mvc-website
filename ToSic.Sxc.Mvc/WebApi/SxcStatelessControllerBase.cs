﻿using System;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ToSic.Eav.Logging;
using ToSic.Eav.Logging.Simple;

namespace Website.WebApi
{
    public abstract class SxcStatelessControllerBase : ControllerBase, IHasLog
    {
        protected SxcStatelessControllerBase()
        {
            // ensure that the sql connection string is correct
            // this is technically only necessary, when dnn just restarted and didn't already set this
            // todo: verify: probably not necessary in MVC
            //Settings.EnsureSystemIsInitialized();
            // ReSharper disable once VirtualMemberCallInConstructor
            // todo: redesign so it works - in .net core the HttpContext isn't ready in the constructor
            Log = new Log(HistoryLogName, null, $"Path: {HttpContext?.Request.GetDisplayUrl()}");
            //TimerWrapLog = Log.Call(message: "timer", useTimer: true);

            // register for dispose / stopping the timer at the end
            _logWrapper = new LogWrapper(Log);
            // todo: get this to work
            // ControllerContext.HttpContext.Response.RegisterForDispose(_logWrapper);
        }

        /// <inheritdoc />
        public ILog Log { get; }

        private readonly LogWrapper _logWrapper;

        /// <summary>
        /// The group name for log entries in insights.
        /// Helps group various calls by use case. 
        /// </summary>
        protected virtual string HistoryLogGroup { get; } = "web-api";

        /// <summary>
        /// The name of the logger in insights.
        /// The inheriting class should provide the real name to be used.
        /// </summary>
        protected abstract string HistoryLogName { get; }

        //protected void Dispose(bool disposing)
        //{
        //    TimerWrapLog(null);
        //    base.Dispose(disposing);
        //}

    }

    internal class LogWrapper: IDisposable
    {
        private readonly Action<string> _timerWrapLog;

        internal LogWrapper(ILog log) => _timerWrapLog = log.Call(message: "timer", useTimer: true);
        public void Dispose() => _timerWrapLog(null);
    }
}
