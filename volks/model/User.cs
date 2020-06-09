namespace volks
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public User() { }
        public User(string Username)
        {
            this.Username = Username;
        }
        public User(string Username, string Password) {
            this.Username = Username;
            this.Password = Password;
        }
        public User(string Username, string Password, string ConfirmPassword)
        {
            this.Username = Username;
            this.Password = Password;
            this.ConfirmPassword = ConfirmPassword;
        }
        public bool CheckInfo() {
            if (!this.Username.Equals("") && !this.Password.Equals(""))
            {
                return true;
            }            
            else
            {
                return false;
            }
        }
        public bool CheckInfoSignUp()
        {
            if (!this.Username.Equals("") && !this.Password.Equals("") && !this.ConfirmPassword.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckInfoChangePass()
        {
            if (!this.Username.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}