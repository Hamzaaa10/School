using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public class StudentSubject
    {
        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }
        public double? grade { get; set; }

        [ForeignKey("StudID")]
        [InverseProperty("StudentSubject")]
        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subject? Subject { get; set; }

    }

}
