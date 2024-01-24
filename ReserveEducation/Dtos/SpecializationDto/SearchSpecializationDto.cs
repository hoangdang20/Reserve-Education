using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveEducation.Dtos.SpecializationDto
{
    internal class SearchSpecializationDto : PagedSearch
    {
        public string Keyword { get; set; }
        public int? FacultyID { get; set; }
    }
}
