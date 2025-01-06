using SGE.StudentConsumerAPI.Winform.Model;
using SGE.StudentConsumerAPI.Winform.Repositories;
using SGE.StudentConsumerAPI.Winform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SGE.StudentConsumerAPI.Winform.Presenters
{
    public class MainPresenter
    {
        //1- Propriétes
        private IMainView mainView;
        //private readonly string sqlConnectionString;

        //2- Constructeurs
        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;
            this.mainView.ShowStudentView += ShowStudentsView;
        }

        //3-Methods
        private void ShowStudentsView(object sender, EventArgs e)
        {
            IStudentView view = StudentView.GetInstace((MainView)mainView);
            IStudentRepository repository = new StudentRepository();
            new StudentPresenter(view, repository);
        }
    }
}
