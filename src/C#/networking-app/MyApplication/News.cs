
using System.Text;

namespace MyApplication.Models
{
	public class News : Post 
	{
		private DateTime caducationDate;
		private static int coutsId;
		private int id;
		private static int coutsCommentsId;
		
		public News(string title, string content, User author, DateTime caducationDate) : base(title, content, author)
		{
			this.id = ++News.coutsId;
			this.caducationDate = caducationDate;
			base.comments = new List<Comment>();
		}
		
		// Metodos Getters y Setters
		
		public DateTime CaducationDate
		{
			get {return caducationDate;}
			set {caducationDate = value;}
		}
		
		public int GetId() => this.id;
		
		public void SetId(int id) => this.id = id;
		
		public List<Comment> GetComments() => this.comments;
		
		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			
			sb.Append(base.ToString()); 

			// Agregar información específica de la clase derivada
			sb.Append("Id: " + this.id + "\n");
			sb.Append("Fecha de caducidad: " + this.caducationDate.ToString("d") + "\n"); // Formato de fecha

			if (this.comments.Count > 0)
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
		
		public override void AddComment(String text, User author){
			this.comments.Add(new Comment( ++News.coutsCommentsId,text, this.author, this));
			Notification newNotification = new Notification("Nuevo Comentario", "Nuevo comentario de "+author.Name+ "\nComentario: \n"+ text,this.author.Email, this.author.Name, this.author.PhoneNumber);
			this.author.Notifications.Add(newNotification);
		}
	
	}
}
