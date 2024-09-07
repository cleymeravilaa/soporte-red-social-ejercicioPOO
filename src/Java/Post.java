package Java;


import java.util.Date;
import java.util.List;

public class Post {
    protected Date date;
    protected User author;
    protected String title ;
    protected String content;
    
    protected List<Comment> comments;

    public Post(){
    }

    public Post(String title, String content, User author){
        this.title = title;
        this.content = content;
        this.author = author;
        this.date = new Date();
    }

    // Metodos Getters

    public Date getDate(){
        return this.date;
    }

    public User getAutor(){
        return this.author;
    }

    public String getTitle(){
        return this.title;
    }

    public String getContent(){
        return this.content;
    }


    // Metodos Setters
    public void setTitle(String title){
        this.title = title;
    }

    public void setContent(String content){
        this.content = content;
    }


    @Override
    public String toString(){

        StringBuilder sb = new StringBuilder();
        sb.append("-----------------------------------\n");
        sb.append("Titulo: " + this.title + "\n");
        sb.append("Contenido: " + this.content + "\n");
        sb.append("Autor: " + this.author.getUsername() + "\n");
        sb.append("Fecha: " + this.date + "\n");
        return sb.toString();
    }

    public void addComment(String text, User author){
        Comment comment = new Comment(0, text, author, this);
        this.comments.add(comment);
    }
}
