using System;
using System.ComponentModel;
using System.Diagnostics;

namespace open
{
    public class Program
    {
        // `open` ShellExecutes its argument.
        // It parses the CommandLine preserving any quotes (that CLR would otherwise strip out)

        internal static void Main(string[] argsWihtoutQuotes)
        {
            var thisProcessNameLen = NextArgLength(Environment.CommandLine);
            var theCommand = Environment.CommandLine.Substring(thisProcessNameLen);

            var processNameLen = NextArgLength(theCommand);
            var processName = theCommand.Substring(0, processNameLen).Trim();
            var processArgs = theCommand.Substring(processNameLen);

            processName = processName.Replace("/", "\\");

            Start(processName, processArgs);
        }

        // Find the length of the next argument including any surrounding whitespace
        private static int NextArgLength(string arg)
        {
            var len = 0;
            while (len < arg.Length && char.IsWhiteSpace(arg[len])) len++;
            var delim = len < arg.Length && arg[len] == '"' ? '"' : ' ';
            if (delim == '"') len++;
            while (len < arg.Length && arg[len] != delim) len++;
            if (len < arg.Length && arg[len] == delim) len++;
            while (len < arg.Length && char.IsWhiteSpace(arg[len])) len++;
            return len;
        }

        // ShellExecute the proc, passing any args. Prints a short error message on failure.
        private static void Start(string proc, string args)
        {
            var psi = new ProcessStartInfo(proc, args) {UseShellExecute = true};
            try
            {
                Process.Start(psi);
            }
            catch (Win32Exception e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
