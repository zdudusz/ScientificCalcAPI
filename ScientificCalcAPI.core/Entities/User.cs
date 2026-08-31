namespace ScientificCalcAPI.Core.Entities;

public class User
{
    public User(string name, string email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.Now; //inicio já com a data de criação do usuário
        UpdatedAt = DateTime.Now;
    }

    public int Id { get; set; }

    public string Name { get;}

    public string Email { get; }

    public string PasswordHash { get; }

    public DateTime CreatedAt { get;}

    public DateTime UpdatedAt { get;}
}
