using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveEducation.Dtos.StudentDto
{
    internal class SearchStudentSubjectDto : PagedSearch
    {
        public string Keyword { get; set; }
        public int? StudentID { get; set; } = null;
        public int? SubjectID { get; set; } = null;

    }
}
