namespace TheMessage.Business.Interfaces.Entities
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Lastname { get; set; }
        string Email { get; set; }
    }
}
