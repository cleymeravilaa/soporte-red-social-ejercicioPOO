using System;
using static System.DateTime;
namespace MyApplication.Models
{
	public class Comment 
	{
		private string id;
		private static int contadorId;
		private DateTime date;
		private User author;
		private string content;
		private Post post;
		private string editorialStatus;
		
		private Comment()
		{
			
		}
		
		public Comment(string content, User author, Post post)
		{
			this.content = content;
			this.author = author;
			this.date = DateTime.Now;
			this.post = post;
		}
	}
}
