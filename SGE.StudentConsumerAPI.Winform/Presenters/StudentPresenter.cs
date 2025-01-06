using SGE.StudentConsumerAPI.Winform.Model;
using SGE.StudentConsumerAPI.Winform.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SGE.StudentConsumerAPI.Winform.Presenters
{
    public class StudentPresenter 
    {
        //1-Fields
        private IStudentView view;
        private IStudentRepository repository;
        private BindingSource studentsBindingSource;
        private IEnumerable<StudentModel> studentList;

        //2- Constructeurs
        public StudentPresenter(IStudentView view, IStudentRepository repository)
        {
            this.studentsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Abonnez-vous aux méthodes du gestionnaire d'événements pour afficher les événements
            this.view.SearchEvent += SearchStudent;
            this.view.AddNewEvent += AddNewStudent;
            this.view.EditEvent += LoadSelectedStudentToEdit;
            this.view.DeleteEvent += DeleteSelectedStudent;
            this.view.SaveEvent += SaveStudent;
            this.view.CancelEvent += CancelAction;

            //Définir la source de liaison des Student
            this.view.SetStudentListBindingSource(this.studentsBindingSource);

            //Charger la vue de la liste des étudiants
            LoadAllStudentList();

            //Show view
            this.view.Show();
        }

        #region Methodes

        private async void LoadAllStudentList()
        {
            //studentList = repository.GetAllStudent();
            studentList = await repository.GetStudents();
            studentsBindingSource.DataSource = studentList;
        }

        private void SearchStudent(object sender, EventArgs e)
        {

        }

        private void AddNewStudent(object sender, EventArgs e)
        {

        }

        private void LoadSelectedStudentToEdit(object sender, EventArgs e)
        {

        }

        private void SaveStudent(object sender, EventArgs e)
        {

        }

        private void CleanviewFields()
        {
            
        }

        private void CancelAction(object sender, EventArgs e)
        {

        }

        private void DeleteSelectedStudent(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
