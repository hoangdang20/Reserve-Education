using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveEducation.Dtos.StudentDto
{
    internal class SearchStudentDto : PagedSearch
    {
        public string Keyword { get; set; }
        public int? ClassID { get; set; } = null;
    }
}
