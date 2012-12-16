using System;
using System.Runtime.InteropServices;

namespace GameOfLifeApp
{
    internal static class ConsoleCtrlHandler
    {
        #region DllImport SetConsoleCtrlHandler() from Kernel32

        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine handler, bool add);

        public delegate bool HandlerRoutine(CtrlTypes ctrlType);

        public enum CtrlTypes
        {
            CtrlCEvent = 0,
            CtrlBreakEvent = 1,
            CtrlCloseEvent = 2,
            CtrlLogoffEvent = 5,
            CtrlShutdownEvent = 6
        }

        #endregion

        private static bool _exitAtNextIteration;
        private static HandlerRoutine _consoleCtrlHandler;

        public enum RunLoopResult
        {
            KeepGoing,
            Quit
        };

        public static void RunUntilCtrlC(Func<RunLoopResult> runLoop)
        {
            // http://stackoverflow.com/questions/6783561/nullreferenceexception-with-no-stack-trace-when-hooking-setconsolectrlhandler
            _consoleCtrlHandler = consoleCtrlHandler;
            SetConsoleCtrlHandler(_consoleCtrlHandler, true);

            for (;;)
            {
                if (_exitAtNextIteration)
                {
                    break;
                }

                if (runLoop() == RunLoopResult.Quit)
                {
                    break;
                }
            }
        }

        private static bool consoleCtrlHandler(CtrlTypes ctrltype)
        {
            if (ctrltype == CtrlTypes.CtrlCEvent)
            {
                _exitAtNextIteration = true;
                return true;
            }

            return false;
        }
    }
}
