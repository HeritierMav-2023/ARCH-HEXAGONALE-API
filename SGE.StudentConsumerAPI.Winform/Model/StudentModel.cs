using System;
using System.Collections.Generic;


namespace SGE.StudentConsumerAPI.Winform.Model
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? ModifiedOn { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? DeletedOn { get; set; }

    }
}
