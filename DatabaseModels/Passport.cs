using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFDS.DatabaseModels
{
    public class Passport
    {
        public int Id { get; set; }
        public int PassportNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        public string Cpr { get; set; } = "";

        public Passenger? Passenger { get; set; }

        public Passport()
        {
            
        }
        public void Clear()
        {
            ExpirationDate = DateTime.MinValue;
            IssueDate = DateTime.MinValue;
            PassportNumber = 0;
            Cpr = "";
        }
        public bool isValid() => 
            PassportNumber != 0 && 
            Cpr != null
            && IssueDate != DateTime.MinValue
            && ExpirationDate != DateTime.MinValue
            && ExpirationDate > IssueDate
            ;

    }
}
