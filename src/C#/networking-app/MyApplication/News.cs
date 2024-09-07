
namespace MyApplication.Models
{
	public class News : Post 
	{
		private DateTime caducationDate;
		
		public News(string title, string content, User author, DateTime caducationDate) : base(title, content, author)
		{
			this.caducationDate = caducationDate;
		}
		
		// Metodos Getters y Setters
		
		public DateTime CaducationDate
		{
			get {return caducationDate;}
			set {caducationDate = value;}
		}
	
	}
}
