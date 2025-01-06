using System;
using System.Windows.Forms;

namespace SGE.StudentConsumerAPI.Winform.Views
{
    public interface IStudentView
    {
        //Properties - Fields
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string DateOfBirth { get; set; }
      
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetStudentListBindingSource(BindingSource studentList);
        void Show();//Optional
    }
}
