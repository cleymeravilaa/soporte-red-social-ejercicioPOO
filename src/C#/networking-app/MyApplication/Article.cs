
namespace MyApplication.Models
{
	public class Article : Post
	{
		private string EditorialStatus { get; set; } // "sent", "approved", "rejected"

		// Constructor
		public Article(string title, string content, User author) : base(title, content, author)
		{
			EditorialStatus = "sent";
		}

		// Métodos Getters y Setters
		public string GetEditorialStatus() => EditorialStatus;

		public void SetEditorialStatus(string editorialStatus) => EditorialStatus = editorialStatus;
	}

}
