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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SGE.StudentConsumerAPI.Winform
{
    public partial class StudentView : Form, IStudentView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;
        public StudentView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageStudentDetail);
            btnClose.Click += delegate { this.Close(); };
        }

        //Propriétes
        public string Id 
        {
            get => txtStudentId.Text; 
            set => txtStudentId.Text = value; 
        }
        public string FirstName 
        { 
            get => txtFirstName.Text;
            set => txtFirstName.Text = value; 
        }
        public string LastName 
        { 
            get => txtLastName.Text;
            set => txtLastName.Text = value; 
        }
        public string Email 
        { 
            get => txtEmail.Text;
            set => txtEmail.Text = value; 
        }
        //public DateTime DateOfBirth 
        //{ 
        //    get => DateTime.Parse(txtDateOfBirth.Text); 
        //    //set => txtDateOfBirth.Text = value; 
        //}

        public string DateOfBirth
        {
            get => txtDateOfBirth.Text;
            set => txtDateOfBirth.Text = value; 
        }

        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        //Events
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        private void AssociateAndRaiseViewEvents()
        {
            //Search
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Add new
            btnAddNew.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageStudentList);
                tabControl1.TabPages.Add(tabPageStudentDetail);
                tabPageStudentDetail.Text = "Add new Student";
            };
            //Edit
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageStudentList);
                tabControl1.TabPages.Add(tabPageStudentDetail);
                tabPageStudentDetail.Text = "Edit Student";
            };
            //Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPageStudentDetail);
                    tabControl1.TabPages.Add(tabPageStudentList);
                }
                MessageBox.Show(Message);
            };
            //Cancel
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageStudentDetail);
                tabControl1.TabPages.Add(tabPageStudentList);
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected pet?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public void SetStudentListBindingSource(BindingSource studentList)
        {
            dataGridView.DataSource = studentList;
        }

        //Singleton pattern (Open a single form instance)
        private static StudentView instance;
        public static StudentView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new StudentView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

    }
}
