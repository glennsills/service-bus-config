using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace QueueTopicComposer.Model.Validators
{
	public class QueueNameAttribute : ValidationAttribute
    {
        private static Regex excludedCharacters = new Regex(@"(^/)|([@?#\*])|(/$)");
        
        public QueueNameAttribute()
        {
            ErrorMessage = "Azure Queue names cannot begin or end with a '\' or contain any of the characters '@','?','#','*'";
        }
        public override bool IsValid(object value )
        {
            var stringValue = value as string;
            if (string.IsNullOrWhiteSpace(stringValue) || !excludedCharacters.IsMatch(stringValue))
            {
                return true;
            }
            return false;
        }
    }
}