using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_ContratoV1.Entidades
{
    public class TBT_SEDES
    {
        [Key]
        public int IDD_SEDES { get; set; }
        [Display(Name = "Código")]
        public string COD_SEDES { get; set; }
        public string DES_SEDES { get; set; }
    }
}
