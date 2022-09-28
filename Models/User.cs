namespace LionDevAPI.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Leave { get; set; }
        public long LeaveTaken { get; set; }

        public User() { }

        public User(User model)
        {
            this.Name = model.Name;
            this.Leave = model.Leave;

        }

    }    
}
