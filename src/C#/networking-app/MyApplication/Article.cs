
using System.Text;

namespace MyApplication.Models
{
	public class Article : Post
	{
		private string EditorialStatus { get; set; } // "sent", "approved", "rejected"
		private static int coutsId;
		private int id;
		private static int coutsCommentsId;

		// Constructor
		public Article(string title, string content, User author) : base(title, content, author)
		{	
			this.id = ++Article.coutsId;
			EditorialStatus = "sent";
			this.comments = new List<Comment>();
		}

		// Métodos Getters y Setters
		public string GetEditorialStatus() => EditorialStatus;

		public void SetEditorialStatus(string editorialStatus) => EditorialStatus = editorialStatus;
		
		public int GetId() => this.id;
		
		public void SetId(int id) => this.id = id;
		
		public List<Comment> GetComments() => this.comments;
		
		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToString());
			sb.Append("Id: " + this.id + "\n");
			sb.Append("Estado de editorial: " + this.EditorialStatus + "\n");
			if (base.comments.Count > 0)
			{
				sb.Append("-------------------------------------\n");
				sb.Append("Comentarios: \n");
				foreach (Comment c in base.comments)
				{
					sb.Append(c.ToString());
					sb.Append("\n");
				}
			}
			else
			{
				sb.Append("No hay comentarios\n");
			}
			sb.Append("-------------------------------------");
			return sb.ToString();
		}
		
		
		public override void AddComment(string text, User author){
			this.comments.Add(new Comment(++Article.coutsCommentsId, text, author, this));
			Notification newNotification = new Notification("Nuevo Comentario","Nuevo comentario de "+author.Username+ "\nComentario: \n"+ text ,this.author.Email, this.author.Name, this.author.PhoneNumber); 
			this.author.Notifications.Add(newNotification);
		}
	}

}
