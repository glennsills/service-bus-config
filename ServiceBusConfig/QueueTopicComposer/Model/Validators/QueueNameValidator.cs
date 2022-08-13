using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace QueueTopicComposer.Model.Validators
{
	public class QueueNameAttribute : ValidationAttribute
    {
        private static Regex excludedCharacters = new Regex(@"(^/)|([@?#\\])|(/$)");
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