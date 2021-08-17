using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assessment2
{
    [Serializable]
    class User : IComparable<User>
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }

        public User(string UserName, string Password, string Email)
        {

            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;

        }


        public int CompareTo([AllowNull] User other)
        {
            int returnVal;
            if(String.Compare(this.UserName , other.UserName)>0)
            {
                 returnVal= 1;
            }else if(String.Compare(this.UserName, other.UserName) < 0)
            {
                returnVal = -1;
            }
            else
            {
                returnVal = 0;
            }
            return returnVal;
        }
    }
}
