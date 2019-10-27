using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            List<int> param = new List<int>();
            if (arg.Length > 4 || !GetArgs(arg, param))
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Controller controller;

            switch (arg.Length)
            {
                case 0: controller = new Controller(); break;
                case 1: controller = new Controller(param[0]); break;
                case 2: controller = new Controller(param[0], param[1]); break;
                case 3: controller = new Controller(param[0], param[1], param[2]); break;
                case 4: controller = new Controller(param[0], param[1], param[2], param[3]); break;
                default: controller = new Controller(); break;
            }
            Application.Run(controller);
        }

        private static bool GetArgs(string[] arg, List<int> param)
        {
            try
            {
                foreach (var str in arg)
                {
                    param.Add(int.Parse(str));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
