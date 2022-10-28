using Core.Entities;

namespace Entity.Dtos.UserDtos
{
    public class UserRegisterDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool isOgrenci { get; set; }
        public bool isHayirSever { get; set; }
    }
}
