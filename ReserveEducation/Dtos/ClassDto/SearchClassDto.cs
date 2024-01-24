using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveEducation.Dtos.ClassDto
{
    internal class SearchClassDto:PagedSearch
    {
        public string Keyword { get; set; }
        public int? SpecializationID { get; set; } = null;
    }
}
