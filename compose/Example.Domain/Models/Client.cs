namespace Example.Domain.Models
{
    public class Client : Entity
    {
        private Client() { }
        public Client(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public override Entity WithId(int id)
        {
            Id = id;
            return this;
        }
    }
}
