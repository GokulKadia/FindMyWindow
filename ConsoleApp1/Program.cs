using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        static void Main(string[] args)
        {

            while(true)
            {
                // Get the foreground window handle
                IntPtr foregroundWindowHandle = GetForegroundWindow();
                // Get the process ID associated with the foreground window
                uint foregroundProcessId;
                GetWindowThreadProcessId(foregroundWindowHandle, out foregroundProcessId);
                // Get the process name using the process ID
                string foregroundProcessName = Process.GetProcessById((int)foregroundProcessId).ProcessName;
                Console.WriteLine("Foreground Process Name: " + foregroundProcessName);



                // Find and kill the Explorer when Vmware-View exe found
                //Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe");
                ////if (foregroundProcessName == "vmware-view")
                ////{
                ////    Process.GetProcesses().Where(x => x.ProcessName == "explorer").ToList().ForEach(x => x.Kill());                    
                ////}
            }
        }
    }
}
