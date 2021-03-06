﻿using Microsoft.ApplicationInsights;
using System.Web.Http.ExceptionHandling;

namespace Narato.Common
{
    public class ApplicationInsightsExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var ai = new TelemetryClient();
            ai.TrackException(context.Exception);

            base.Log(context);
        }

        //public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        //{
        //    var ai = new TelemetryClient();
        //    ai.TrackException(context.Exception);

        //    return base.LogAsync(context, cancellationToken);
        //}
    }
}