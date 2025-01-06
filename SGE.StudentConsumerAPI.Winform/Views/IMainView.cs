using System;
using System.Collections.Generic;


namespace SGE.StudentConsumerAPI.Winform.Views
{
    public interface IMainView
    {
        //Events View
        event EventHandler ShowStudentView;
        event EventHandler ShowOwnerView;
        event EventHandler ShowVetsView;
    }
}
