using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Models
{
    public class UpdateSerwisDto
    {

        public int Garaz { get; set; }
        [Required]
        public string Pracownik { get; set; }
    }
}
