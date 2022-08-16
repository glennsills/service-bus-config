using System.ComponentModel.DataAnnotations;
using QueueTopicComposer.Model;

namespace QueueTopicComposer.Tests.Model;
public class BaseQueuePropertiesTests
{
	[Fact]
	public void EmptyNameIsDetected()
	{
        var validationResults = new List<ValidationResult>();
		var cut = new BaseQueueProperties();
		var ctx = new ValidationContext(cut, null, null);
		Validator.TryValidateObject(cut, ctx, validationResults, true);
		Assert.Contains(validationResults, vr=> vr.MemberNames.Contains("Name"));
	}

	[Fact]
	public void NameWithLeadingForwardSlashIsDetected()
	{
        var validationResults = new List<ValidationResult>();
		var cut = new BaseQueueProperties{ Name = "/something"};
		var ctx = new ValidationContext(cut, null, null);
		Validator.TryValidateObject(cut, ctx, validationResults, true);
		Assert.Contains(validationResults, vr=> vr.MemberNames.Contains("Name"));
	}

	[Fact]
	public void NameWithTrailingForwardSlashIsDetected()
	{
        var validationResults = new List<ValidationResult>();
		var cut = new BaseQueueProperties{ Name = "something/"};
		var ctx = new ValidationContext(cut, null, null);
		Validator.TryValidateObject(cut, ctx, validationResults, true);
		Assert.Contains(validationResults, vr=> vr.MemberNames.Contains("Name"));
	}

	[Fact]
	public void NameWithIllegalCharactersIsDetected()
	{
        var validationResults = new List<ValidationResult>();
		var cut = new BaseQueueProperties{ Name = "SOMENAME#"};
		var ctx = new ValidationContext(cut, null, null);
		Validator.TryValidateObject(cut, ctx, validationResults, true);
		Assert.Contains(validationResults, vr=> vr.MemberNames.Contains("Name"));
	}

	[Fact]
	public void NameThatIsValidIsAccepted()
	{
        var validationResults = new List<ValidationResult>();
		var cut = new BaseQueueProperties{ Name = "Goodname"};
		var ctx = new ValidationContext(cut, null, null);
		Validator.TryValidateObject(cut, ctx, validationResults, true);
		Assert.DoesNotContain(validationResults, vr=> vr.MemberNames.Contains("Name"));
	}

	[Fact]
	public void AutoDeleteOnIdleToShorIsDetected()
	{
        var validationResults = new List<ValidationResult>();
		var cut = new BaseQueueProperties{ Name = "GoodName", AutoDeleteOnIdle = TimeSpan.Parse("0:0:4:59")};
		var ctx = new ValidationContext(cut, null, null);
		Validator.TryValidateObject(cut, ctx, validationResults, true);
		Assert.Contains(validationResults, vr=> vr.MemberNames.Contains("AutoDeleteOnIdle"));
	}

}
