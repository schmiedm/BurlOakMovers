using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BurlOakMovers.Models
{
    public class WorkOrder
    {
        [Key]
        [Display(Name = "Id")]
        [Required]
        public int wId { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        public string wCustomerName { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string wPhone { get; set; }

        [Display(Name = "Cell Phone")]
        public string wCellPhone { get; set; }

        [Display(Name = "Email")]
        public string wEmail { get; set; }

        [Display(Name = "Pack Date")]
        public string wPackDate { get; set; }

        [Display(Name = "Move Date")]
        public string wMoveDate { get; set; }

        [Display(Name = "Start Time")]
        public string wStartTime { get; set; }

        [Display(Name = "Current Address (From)")]
        [Required]
        public string wCurrentAddressFrom { get; set; }

        [Display(Name = "Unit/Apt#")]
        public string wUnitFrom { get; set; }

        [Display(Name = "City")]
        [Required]
        public string wCityFrom { get; set; }

        [Display(Name = "Postal Code")]
        [Required]
        public string wPostalCodeFrom { get; set; }

        [Display(Name = "Current Address (To)")]
        [Required]
        public string wCurrentAddressTo { get; set; }

        [Display(Name = "Unit/Apt#")]
        public string wUnitTo { get; set; }

        [Display(Name = "City")]
        [Required]
        public string wCityTo { get; set; }

        [Display(Name = "Postal Code")]
        [Required]
        public string wPostalCodeTo { get; set; }

        [Display(Name = "Furnish")]
        [Required]
        public string wFurnish { get; set; }

        [Display(Name = "Van and")]
        [Required]
        public string wVan { get; set; }

        [Display(Name = "Men for")]
        [Required]
        public string wMen { get; set; }

        [Display(Name = "Hours at")]
        [Required]
        public string wHours { get; set; }


    }
}