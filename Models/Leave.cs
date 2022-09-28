namespace LionDevAPI.Models
{
    public class Leave
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long LeaveType { get; set; }
        public string Reason { get; set; }
        public long LeaveTaken { get; set; }
        public long LeaveAvailable { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
