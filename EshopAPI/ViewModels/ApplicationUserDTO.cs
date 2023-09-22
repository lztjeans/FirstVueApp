

using FirstApp.Models;

namespace EshopAPI.ViewModels
{
    public class ApplicationUserDTO //: FirstApp.Models.BaseEntity
    {
        public ApplicationUserDTO() { }
        public ApplicationUserDTO(ApplicationUser appUser)
        {
            this.Id = Convert.ToString(appUser.Id);
            this.Username = Convert.ToString(appUser.UserName);
            this.Password = Convert.ToString(appUser.Password);
            this.Email = Convert.ToString(appUser.Email);
            this.Age = Convert.ToString( appUser.Age);
            this.Salary = Convert.ToString(appUser.Salary);
            this.Sex = Convert.ToString(appUser.Sex);
            this.Department = Convert.ToString(appUser.Department);
        }

        public string? Id { get; set; }
        public string? Username { get; set; }

        public string? Age { get; set; }

        public string? Salary { get; set; }

        public string? Department { get; set; }

        public string? Sex { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public ApplicationUser ToEntity()
        {
            //throw new NotImplementedException();
            return new ApplicationUser()
            {
                UserName = Username,
                Email = Email,
                Department = Department,
                Password = Password,
                Age = Convert.ToInt32(Age),
                Salary = Convert.ToDecimal(Salary),
                Sex = Convert.ToChar(Sex),
            };
        }
    }
}
