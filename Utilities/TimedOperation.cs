using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Utilities
{
    public static class LogExtensions
    {
        public static IDisposable TimedOperation<T>(this ILogger<T> logger, string message, params object?[] args)
            => new TimedOperation<T>(logger, LogLevel.Information, message, args);

        public static IDisposable TimedOperation<T>(this ILogger<T> logger, int warningThresholdMilliseconds, string message, params object?[] args)
            => new TimedOperation<T>(logger, LogLevel.Information, message, args)
                .WithWarningThreshold(warningThresholdMilliseconds);
    }

    public sealed class TimedOperation<T> : IDisposable
    {
        private readonly ILogger<T> _logger;
        private readonly LogLevel _logLevel;
        private readonly string _message;
        private readonly object?[] _args;
        private readonly Stopwatch _stopwatch;

        private int _warningThresholdMilliseconds = -1;

        public TimedOperation(ILogger<T> logger, LogLevel logLevel, string message, object?[] args)
        {
            _logger = logger;
            _logLevel = logLevel;
            _message = message;
            _args = args;
            _stopwatch = Stopwatch.StartNew();
        }

        public TimedOperation<T> WithWarningThreshold(int warningThresholdMilliseconds)
        {
            _warningThresholdMilliseconds = warningThresholdMilliseconds;
            return this;
        }

        public void Dispose()
        {
            _stopwatch.Stop();

            if (_stopwatch.ElapsedMilliseconds > _warningThresholdMilliseconds)
                _logger.Log(LogLevel.Warning, $"{_message} completed in {_stopwatch.ElapsedMilliseconds}ms", _args);
            else
                _logger.Log(_logLevel, $"{_message} completed in {_stopwatch.ElapsedMilliseconds}ms", _args);
        }
    }
}
