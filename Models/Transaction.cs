using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Operation.Models
{
    public class Transaction
    {
        [Key] 
        public int id {  get; set; }

        [DisplayName("Account Holder Name")]
        public string accountHolderName { get; set; }

        [DisplayName("Account Number")]
        public string accountNumber { get; set; }

        [DisplayName("Bank Name")]
        public string bankName { get; set; }

        [DisplayName("Amount")]
        public int amount { get; set; }

        [DisplayName("Date")]
        public DateTime date { get; set; }
    }
}
