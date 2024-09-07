package Java;
import java.util.ArrayList;
import java.util.List;

public class Group {
    private List<User> members;
    private List<User> admins;
    private List<String> messages;
    private List<Post> posts;
    private String name;
    private String description;
    private List<Group> subgroups;
    private final int MAX_SUBGROUPS =5;
    private final int MAX_ADMINS = 5;
    private List<User> requestsUsers; 

    public Group(){}

    public Group(String name, String description){
        this.name = name;
        this.description = description;
        this.members = new ArrayList<>();
        this.admins = new ArrayList<>(MAX_ADMINS);
        this.posts = new ArrayList<>();
        this.messages = new ArrayList<>();
        this.subgroups = new ArrayList<>(MAX_SUBGROUPS);
        this.requestsUsers = new ArrayList<>();
    }

    // Metodos Getters
    public List<User> getMembers(){
        return this.members;
    }

    public List<User> getAdmins(){
        return this.admins;
    }

    public List<Post> getPosts(){
        return this.posts;
    }

    public String getName(){
        return this.name;
    }

    public String getDescription(){
        return this.description;
    }

    public List<Group> getSubgroups(){
        return this.subgroups;
    }

    public List<User> getRequestsUsers(){
        return this.requestsUsers;
    }

    // Metodos Setters
    public void setMembers(List<User> members){
        this.members = members;
    }

    public void setAdmins(List<User> admins){
        this.admins = admins;
    }

    public void setName(String name){
        this.name = name;
    }   

    public void setDescription(String description){
        this.description = description;     
    }

    public void addAdmin(User user){
        this.admins.add(user);
    }

    public void addMember(User user){
        this.members.add(user);
    }

    public void addPost(Post post){
        this.posts.add(post);
    }

    public void addSubgroup(Group group){
        this.subgroups.add(group);
    }

    public void addMessage(String message){
        this.messages.add(message);
    }

    public void listMembers(){
        System.out.println("-------------------------------------");
        System.out.println("Listado de Miembros:\n");
        for(User u: this.members){
            System.out.println(u);
        }
    }

    @Override
    public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append("Grupo: \n");
        sb.append("-----------------------------------\n");
        sb.append("Nombre: " + this.name + "\n");
        sb.append("Descripción: " + this.description + "\n");
        sb.append("Membres: \n");
        for(User u: this.members){
            sb.append(u);
        }
        sb.append("-------------------------------------");
        return sb.toString();
    }

    public void addRequest(User user){
        this.requestsUsers.add(user);
    }

    public void listRequests(){
        System.out.println("-------------------------------------");
        System.out.println("Listado de Solicitudes:\n");
        for(User u: this.requestsUsers){
            System.out.println(u);
        }
    }



}
