using System.ComponentModel.DataAnnotations;

namespace Lab1.Validations
{
    //Custom Validation Of Date
    public class DateInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return (value is DateTime date && date <= DateTime.Now);
            //var date = value as DateTime; //error
            //var date = value as DateTime?;
            //if(date == null)
            //{
            //    return false;
            //}
            //if(date > DateTime.Now)
            //{
            //    return false;
            //}
            //return true;
        }
    }
}
