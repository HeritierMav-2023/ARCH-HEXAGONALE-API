using SGE.StudentConsumerAPI.Winform.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGE.StudentConsumerAPI.Winform
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            btnStudents.Click += delegate { ShowStudentView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowStudentView;
        public event EventHandler ShowOwnerView;
        public event EventHandler ShowVetsView;
    }
}
