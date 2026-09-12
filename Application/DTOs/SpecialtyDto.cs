using Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SpecialtyDto : BaseDTOs
    {
        [Required]
        public string SpecialtyName { get; set; }
    }
}
