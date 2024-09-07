using System;
using static System.DateTime;
namespace MyApplication.Models
{
	public class Comment 
	{
		private int id;
		private static int coutsId;
		private DateTime date;
		private User author;
		private string content;
		private Post post;
		private string editorialStatus;

		
		public Comment(int id, string content, User author, Post post)
		{
			this.id = ++Comment.coutsId;
			this.content = content;
			this.author = author;
			this.date = DateTime.Now;
			this.editorialStatus = "";
			this.post = post;
		}
		
		// Metodos Getters y Setters
		public int GetId() => this.id;
		
		public string GetContent() => this.content;
		public User GetAuthor() => this.author;
		public DateTime GetDate() => this.date;
		public string GetEditorialStatus() => this.editorialStatus;
		public void SetContent(string content) => this.content = content;
		public void SetAuthor(User author) => this.author = author;
		public void SetDate(DateTime date) => this.date = date;
		public void SetEditorialStatus(string editorialStatus) => this.editorialStatus = editorialStatus;
		public override string ToString(){
			return $"Id: {this.id}\n" +
				   $"Autor: {this.author.Name}\n" +
				   $"Fecha: {this.date}\n" +
				   $"Texto: {this.content}\n" +
				   $"Estado de editorial: {this.editorialStatus}\n";
		}
	}
}
