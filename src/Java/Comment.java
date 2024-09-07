package Java;

import java.util.Date;

public class Comment {


    private int id;
    private Date date;
    private User author;
    private String text;
    private Post post;
    private String editorialStatus;


    public Comment(){
    }

    public Comment(int id, String text, User author, Post post){
        this.id = id;
        this.text = text;
        this.author = author;
        this.date = new Date();
    }

    // Metodos Getters
    public int getId(){
        return this.id;
    }

    public Date getDate(){
        return this.date;
    }

    public User getAuthor(){
        return this.author;
    }

    public String getText(){
        return this.text;
    }
    
    public String getEditorialStatus(){
        return this.editorialStatus;
    }
    
    public Post getPost(){
        return this.post;
    }
    
    // Metodos Setters
    public void setText(String text){
        this.text = text;
    }

    public void setEditorialStatus(String editorialStatus){
        this.editorialStatus = editorialStatus;
    }   

    public void setAuthor(User author){
        this.author = author;
    }

    public void setDate(Date date){
        this.date = date;
    }

    public void setPost(Post post){
        this.post = post;
    }

    @Override 
    public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append("-----------------------------------\n");
        sb.append("Id: " + this.id + "\n");
        sb.append("Autor: " + this.author.getUsername() + "\n");
        sb.append("Fecha: " + this.date + "\n");
        sb.append("Texto: " + this.text + "\n");
        sb.append("-------------------------------------");
        return sb.toString();
    }

}

