using SGE.StudentConsumer.WPF.Models;
using SGE.StudentConsumer.WPF.Services;
using SGE.StudentConsumer.WPF.ViewModels.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;


namespace SGE.StudentConsumer.WPF.ViewModels
{
    public class StudentViewModel :INotifyPropertyChanged
    {

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Propriétes
        private readonly IStudentService _studentService;
        private StudentModel _studentModel;
        private ObservableCollection<StudentModel> _students;

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth;

        #endregion

        #region Constructeur
        public StudentViewModel()
        {
            _studentService = new StudentService();
            _studentModel = new StudentModel();
            //Afficher
            GetAll();
        }
        #endregion

        #region Commands
        private ICommand _saveCommand;
        private ICommand _resetCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        #endregion

        #region Command Methods
        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new RelayCommand(param => ResetData(), null);

                return _resetCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(param => SaveStudent(), null);

                return _saveCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new RelayCommand(param => EditStudent((int)param), null);

                return _editCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(param => DeleteStudent((int)param), null);

                return _deleteCommand;
            }
        }
        #endregion

        #region Ascesseurs

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyPropertyChanged("LastName");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged(nameof(Email));
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                NotifyPropertyChanged(nameof(DateOfBirth));
            }
        }

        public ObservableCollection<StudentModel> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                NotifyPropertyChanged(nameof(Students));
            }
        }

        public StudentModel StudentModel
        {
            get { return _studentModel; }
            set
            {
                _studentModel = value;
                NotifyPropertyChanged(nameof(_studentModel));
            }
        }
        #endregion

        #region Methods
        public void GetAll()
        {
            Students = new ObservableCollection<StudentModel>(
                _studentService.GetAllStudent());
        }

        public void ResetData()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            DateOfBirth = new DateTime(0001, 01, 01);
        }

        public async void EditStudent(int id)
        {
            var student = await _studentService.GetDataTask(id);

            if (student != null)
            {
                Id = student.Id;
                FirstName = student.FirstName;
                LastName = student.LastName;
                Email = student.Email;
                DateOfBirth = student.DateOfBirth;
            }
        }

        public void SaveStudent()
        {
            if (StudentModel != null)
            {
                StudentModel.FirstName = FirstName;
                StudentModel.LastName = LastName;
                StudentModel.Email = Email;
                StudentModel.DateOfBirth = DateOfBirth;

                try
                {
                    if (StudentModel.Id == 0) 
                    {
                      _studentService.SaveTask(StudentModel);
                      MessageBox.Show("New record successfully saved.");
                    }
                    else
                    {
                      StudentModel.Id = Id;
                      _studentService.UpdateTask(StudentModel);
                      MessageBox.Show("Record successfully updated.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    GetAll();
                    ResetData();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            if(id != 0)
            {
               _studentService.DeleteTask(id);
                MessageBox.Show("New record deleted successfully.");
                GetAll();
            }
        }
        #endregion

    }
}
