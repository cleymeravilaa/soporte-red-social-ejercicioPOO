using System.Text;

namespace MyApplication.Models
{
    public class Conversation
    {
    	private List<string> messages;
    	private User author;
    	private DateTime date;
    	private User recipient;
    	
    	
    	
    	public Conversation(string message, User author, User recipient){
    		this.messages = new List<string>();
    		this.messages.Add(message);
    		this.author = author;
    		this.date = DateTime.Now;
    		this.recipient = recipient;
    	}

    	// Metodos Getters y Setters
    	public List<string> GetMessages(){
    		return this.messages;
    	}

    	public User GetAuthor(){
    		return this.author;
    	}

    	public DateTime GetDate(){
    		return this.date;
    	}

    	public User GetRecipient(){
    		return this.recipient;
    	}
    	
    	// Metodos Setters
    	public void AddMessage(string message){
    		this.messages.Add(message);
    		Notification newNotification = new Notification("Nuevo Mensaje","Nuevo mensaje de"+ this.recipient.Username+ "\nMensaje: \n"+ message ,this.recipient.Email, this.recipient.Name, this.recipient.PhoneNumber);
    		this.recipient.Notifications.Add(newNotification);

    	}

    	public void SetAuthor(User author){
    		this.author = author;
    	}

    	public void SetDate(DateTime date){
    		this.date = date;
    	}

    	public void SetRecipient(User recipient){
    		this.recipient = recipient;
    	}

    	public void ListMessages(){
    		Console.WriteLine("Conversación con " + this.recipient.Username + "\n");
    		foreach(string s in this.messages){
    			Console.WriteLine(s);
    		}
    	}

    	
    	public override String ToString(){
    		StringBuilder sb = new StringBuilder();
    		sb.Append("-----------------------------------\n");
    		sb.Append("Autor: " + this.author.Username + "\n");
    		sb.Append("Fecha: " + this.date + "\n");
    		sb.Append("Mensajes: " + this.messages.Capacity + "\n");
    		sb.Append("-------------------------------------");
    		return sb.ToString();
    	}
    }
}