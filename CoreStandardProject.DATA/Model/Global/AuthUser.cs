using SSMDapperV2;

namespace CoreStandardProject.DATA.Model.Global
{
    public class AuthUser : Repository
    {
        public string User_Id { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Personnel_Number { get; set; }
        public string Domain { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Role UserRole { get; set; }
        public bool IsValidUser { get; set; }
        public bool IsAdminUser { get; set; }
        public bool IsSpecialist { get; set; }
        public bool IsResponder { get; set; }
        public bool IsResponderToOFI { get; set; }
        public bool IsFYI { get; set; }

        /// <summary>
        /// AuthUser Constructor with a reference to the base class and the current connections string name.
        /// </summary>
        public AuthUser() : base("NewTemplateDatabase")
        {

        }
    }
}
