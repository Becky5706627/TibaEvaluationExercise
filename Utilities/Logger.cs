using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NLog;
using NUnit.Framework;
using System.Diagnostics;

namespace TibaEvaluationExercise.Utilities
{

    public static class Logger
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        // Initialize the session ID
        public static void InitializeSession()
        {
            NLog.GlobalDiagnosticsContext.Set("sessionID", Guid.NewGuid().ToString("N"));
        }

        private static string GetCallingMethodName()
        {
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(3)?.GetMethod();
            return methodBase?.Name ?? "UnknownMethod";
        }

        public static void Info(string message)
        {
            string testName = TestContext.CurrentContext.Test.Name;
            string methodName = GetCallingMethodName();
            logger.Info($"{testName} | {methodName} | {message}");
        }

        public static void Error(string message)
        {
            string testName = TestContext.CurrentContext.Test.Name;
            string methodName = GetCallingMethodName();
            logger.Error($"{testName} | {methodName} | {message}");
        }

    }
}