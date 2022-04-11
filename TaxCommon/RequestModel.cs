using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaxCommon
{
    public class RequestModel
    {
        [Required]
        [DisplayName("Municipality Name")]
        public string? MunicipalityName { get; set; }
        [Required(ErrorMessage = "Date is required (yyyy.MM.dd)")]
        [RegularExpression(@"(((19|20)\d\d)\.(0[1-9]|1[0-2])\.((0|1)[0-9]|2[0-9]|3[0-1]))$", ErrorMessage = "Invalid date format (Use (yyyy.MM.dd))")]
        public string? Day { get; set; }
    }
}
