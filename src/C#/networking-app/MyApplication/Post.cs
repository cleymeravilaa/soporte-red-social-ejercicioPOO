using System.Collections.Generic;
using static System.DateTime;

namespace MyApplication.Models
{
	public class Post
	{
		protected string title;
		protected string content;
		protected User author;
		protected List<Comment> comments;
		protected DateTime date;
		protected int id;
		protected static int contadorId;
		
		private Post()
		{
			this.id = ++Post.contadorId;
		}
		
		public Post(string title, string content, User author) : this()
		{
			this.date = DateTime.Now;
			this.author = author;
			this.title = title;
			this.content = content;
			this.comments = new List<Comment>();
			this.title = title;
		}
		
		// Metodos Getters y Setters
		public int Id
		{
			get {return id;}
			set {id = value;}
		}
		
		public DateTime Date
		{
			get {return date;}
			set {date = value;}
		}
		
		public User Author
		{
			get {return author;}
			set {author = value;}
		}
		
		public string Title
		{
			get {return title;}
			set {title = value;}
		}
		
		public string Content
		{
			get {return content;}
			set {content = value;}
		}
		
		public List<Comment> Comments
		{
			get {return comments;}
			set {comments = value;}
		}
	}
}
