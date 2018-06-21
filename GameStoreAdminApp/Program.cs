using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStoreAdminApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clsAllGame.LoadGameForm = new clsAllGame.LoadGameFormDelegate(frmGame.Run);
            Application.Run(frmMain.Instance);
        }
    }
}
