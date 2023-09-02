using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Operation.Models
{
    public class Transaction
    {
        [Key] 
        public int id {  get; set; }

        [Required(ErrorMessage = "This Feild is Required")]
        [StringLength(50)]
        [DisplayName("Account Holder Name")]        
        public string accountHolderName { get; set; }

        [Required(ErrorMessage = "This Feild is Required")]
        [MaxLength(11, ErrorMessage = "Account Number Should be 11 Characters")]
        [MinLength(11, ErrorMessage = "Account Number Should be 11 Characters")]
        [DisplayName("Account Number")]
        public string accountNumber { get; set; }

        [Required(ErrorMessage = "This Feild is Required")]
        [StringLength(50)]
        [DisplayName("Bank Name")]
        public string bankName { get; set; }

        [Required(ErrorMessage = "This Feild is Required")]
        [DisplayName("Amount")]
        public int amount { get; set; }

        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:MMM:dd:yy}")]
        public DateTime date { get; set; }
    }
}
