using System.Text.Json.Serialization;

namespace SocialMediaLoginMaui.Models
{
	public class GoogleProfileModel
	{
		[JsonPropertyName("sub")]
		public string Sub { get; set; }

		[JsonPropertyName("name")]
		public string FullName { get; set; }

		[JsonPropertyName("given_name")]
		public string FirstName { get; set; }

		[JsonPropertyName("family_name")]
		public string LastName { get; set; }

		[JsonPropertyName("picture")]
		public string ProfilePicture { get; set; }

		[JsonPropertyName("email")]
		public string MailId { get; set; }

		[JsonPropertyName("email_verified")]
		public bool IsEmailVerified { get; set; }

		[JsonPropertyName("locale")]
		public string Locale { get; set; }
    }
}

