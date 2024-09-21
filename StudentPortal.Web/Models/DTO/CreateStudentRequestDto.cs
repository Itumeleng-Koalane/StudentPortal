namespace StudentPortal.Web.Models.DTO
{
    public class CreateStudentRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Subscribed { get; set; }
    }
}
