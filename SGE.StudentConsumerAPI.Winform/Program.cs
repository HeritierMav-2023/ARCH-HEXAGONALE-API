using SGE.StudentConsumerAPI.Winform.Presenters;
using SGE.StudentConsumerAPI.Winform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGE.StudentConsumerAPI.Winform
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMainView mainView = new MainView();
            new MainPresenter(mainView);
            Application.Run((Form)mainView);
        }
    }
}
