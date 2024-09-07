package Java;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Conversation {
    private List<String> messages;
    private User author;
    private Date date;
    private User recipient;
    
    public Conversation(){
    }
    
    public Conversation(String message, User author, User recipient){
        this.messages = new ArrayList<>();
        this.messages.add(message);
        this.author = author;
        this.date = new Date();
        this.recipient = recipient;
    }

    // Metodos Getters
    public List<String> getMessages(){
        return this.messages;
    }

    public User getAuthor(){
        return this.author;
    }

    public Date getDate(){
        return this.date;
    }

    public User getRecipient(){
        return this.recipient;
    }
    
    // Metodos Setters
    public void addMessage(String message){
        this.messages.add(message);
        Notification newNotification = new Notification("Nuevo Mensaje", this.recipient.getEmail(), this.recipient.getName(), this.recipient.getPhoneNumber(), "Nuevo mensaje de"+ this.recipient.getUsername()+ "\nMensaje: \n"+ message);
        this.recipient.getNotifications().add(newNotification);

    }

    public void setAuthor(User author){
        this.author = author;
    }

    public void setDate(Date date){
        this.date = date;
    }

    public void setRecipient(User recipient){
        this.recipient = recipient;
    }

    public void listMessages(){
        System.out.println("Conversación con " + this.recipient.getUsername() + "\n");
        for(String s : this.messages){
            System.out.println(s);
        }
    }

    @Override
    public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append("-----------------------------------\n");
        sb.append("Autor: " + this.author.getUsername() + "\n");
        sb.append("Fecha: " + this.date + "\n");
        sb.append("Texto: " + this.messages.iterator()+ "\n");
        sb.append("-------------------------------------");
        return sb.toString();
    }


}
