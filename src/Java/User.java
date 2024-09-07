package Java;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;


public class User {
    private String username;
    private String  name;
    private String email;
    private String phoneNumber;
    private String password;
    private List<Group> groups;
    private Profile profile;
    private List<Post> posts;
    private List<User> personalContacts;
    private List<Post> markedPosts;
    private boolean isModerator;
    private List<Notification> notifications;
    private List<Conversation> conversations; 

    public User(){

    }

    public User(String name, String email,String username, String password, String phoneNumber){
        this.name = name;
        this.email = email;
        this.username = username;
        this.password = password;
        this.phoneNumber = phoneNumber;
        this.posts = new ArrayList<>();
        this.personalContacts = new ArrayList<>();
        this.markedPosts = new ArrayList<>();
        this.notifications = new ArrayList<>();
        this.groups = new ArrayList<>();
        this.conversations = new ArrayList<>();
    }

    // Metodos Getters
    public String getName(){
        return this.name;
    }

    public String getEmail(){
        return this.email;
    }

    public String getPhoneNumber(){
        return this.phoneNumber;
    }

    public String getPassword(){
        return this.password;
    }

    public String getUsername(){
        return this.username;
    }

    public List<Group> getGroups(){
        return this.groups;
    }

    public Profile getProfile(){
        return this.profile;
    }

    public List<Post> getPosts(){
        return this.posts;
    }

    public List<User> getPersonalContacts(){
        return this.personalContacts;
    }

    public List<Post> getMarkedPosts(){
        return this.markedPosts;
    }

    public boolean isModerator(){
        return this.isModerator;
    }

    public List<Notification> getNotifications(){
        return this.notifications;
    }

    public List<Conversation> getConversations(){
        return this.conversations;
    }

    // Metodos Setters
    public void setName(String name){
        this.name = name;
    }

    public void setEmail(String email){
        this.email = email;
    }

    public void setPhoneNumber(String phoneNumber){
        this.phoneNumber = phoneNumber;
    }

    public void setPassword(String password){
        this.password = password;
    }

    public void serUsername(String username){
        this.username = username;
    }

    public void setProfile(String personalWebsiteURL, String location, Date birthDate, String biography, String profilePicture){
        this.profile = new Profile(personalWebsiteURL, location, birthDate, biography, profilePicture);
    }

    @Override
    public String toString(){

        StringBuilder sb = new StringBuilder();
        sb.append(" User: \n");
        sb.append("-----------------------------------\n");
        sb.append("Nombre: " + this.name + "\n");
        sb.append("Email: " + this.email + "\n");
        sb.append("Usuario: " + this.username + "\n");
        sb.append("Teléfono: " + this.phoneNumber + "\n");
        sb.append("Contraseña: " + this.password + "\n");
        sb.append("-------------------------------------");

        return sb.toString();
    }

    public void PostArticle(String title, String text){
        Article post = new Article(title, text, this);
        posts.add(post);
    }

    public void PostNews(String title, String text, Date caducationDate ){
        News post = new News(title, text, this, caducationDate);
        posts.add(post);
    }

    public void ListPosts(){

        System.out.println("-------------------------------------");
        System.out.println("Listado de Publicaciones:\n");
        for(Post p : this.posts){
            if(p instanceof Article){
                System.out.println("Tipo de Publicación: Artículo");
                System.out.println(p);
            } else {
                System.out.println("Tipo de Publicación: Noticia");
                System.out.println(p);
            }
        }
    }
    
    public void addPostToMarkedPosts(Post post){
        this.markedPosts.add(post);
    }

    public void listMarkedPosts(){
        System.out.println("-------------------------------------");
        System.out.println("Listado de Publicaciones marcadas:\n");
        for(Post p : this.markedPosts){
            System.out.println(p);
        }
    }

    public void addUserToPersonalContacts(User user){
        this.personalContacts.add(user);
    }

    public void listPersonalContacts(){
        System.out.println("-------------------------------------");
        System.out.println("Listado de Contactos:\n");
        for(User u : this.personalContacts){
            System.out.println(u);
        }
    }

    public void createGroup(String name, String description){
        Group group = new Group(name, description);
        group.addAdmin(this);
        group.addMember(this);
        this.isModerator = true;
        this.groups.add(group);
    }

    public void addMemberToGroup(Group group, User user){
        group.addMember(user);

    }

    public void addAdminToGroup(Group group, User user){
        if (group.getMembers().contains(user)) {
            group.addAdmin(user);
            user.isModerator = true;
            
        } else {
            System.out.println("El usuario no es miembro del grupo");
        }
    }
    public void listGroups(){
        System.out.println("-------------------------------------");
        System.out.println("Listado de Grupos:\n");
        for(Group g : this.groups){
            System.out.println(g);
        }
    }

    public void requestToJoinGroup(Group group){
        group.addRequest(this);
    }

    public void acceptUserRequest(Group group, int index){
        if (group.getAdmins().contains(this)) {
            User user = group.getRequestsUsers().get(index);
            addMemberToGroup(group,user);
            group.getRequestsUsers().remove(index);
            user.addNotification("Solicitud de Grupo: "+ group.getName(), "Has sido aceptado a unirte al grupo\nFelicitaciones ya eres miembro de este maravilloso grupo");
            System.out.println("El usuario ha sido aceptado");

        } else {
            System.out.println("No eres el administrador del grupo");
        }
    }


    public void deleteUserFromGroup(Group group, int index){
        if (group.getAdmins().contains(this)) {
            User user = group.getMembers().get(index);
            group.getMembers().remove(index);
            user.addNotification("Solicitud de Grupo: "+ group.getName(), "Has sido eliminado de este grupo por "+ this.name);
            System.out.println("El usuario ha sido eliminado");
        } else {
            System.out.println("No eres el administrador del grupo");
        }
    }

    private void addNotification(String subject, String content) {
        Notification notification = new Notification(subject, this.email, this.name, this.phoneNumber, content);
        this.notifications.add(notification);
    }

    public void sentPostToGroup(Group group, Post post){
        if (group.getMembers().contains(this)) {

            StringBuilder sb = new StringBuilder();
            sb.append("Publicación enviada a grupo:\n");
            sb.append("Tipo de Publicación: " + post.getClass().getSimpleName() + "\n");
            sb.append(post);

            if (post instanceof Article) {
                var article = (Article) post;
                article.setEditorialStatus("enviado");
            }


            group.addPost(post);
            for(User u : group.getMembers()){
                u.getNotifications().add(new Notification("Nueva Publicación", u.email, u.name, u.phoneNumber, "Nueva publicación de "+ this.name+ "\nPublicación: \n"+ sb.toString()));
            }
            group.addMessage(sb.toString());

        } else {
            System.out.println("No eres miembro del grupo");
        }
    }

    public void postOnGroup(Group group, String text){
        if(group.getMembers().contains(this)){
            group.addMessage(text);
        }
    }


    public void createConversation(User user, String text){
        Conversation conversationStarter= new Conversation(text, this, user);
        Conversation conversationParticipant = new Conversation(text, user, this);
        this.conversations.add(conversationStarter);
        user.conversations.add(conversationParticipant);

        Notification newNotification = new Notification("Nueva Conversación", user.getEmail(), user.getName(), user.getPhoneNumber(), "Nuevo mensaje de"+ user.getUsername()+ "\nMensaje: \n"+ text); 
        user.getNotifications().add(newNotification);
    }

    public void listNotifications(){
        System.out.println("-------------------------------------");
        System.out.println("Listado de Notificaciones:\n");
        for(Notification n : this.notifications){
            System.out.println(n);
        }
    }
}
