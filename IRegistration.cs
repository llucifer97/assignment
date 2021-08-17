using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment2
{
    interface IRegistration
    {
        String addNewUser(User user);
        void SaveUserInExcelFile();
        void SerializeUser();
        void DeSerializeUser();
        String ValidateUser(String UserName, String password);


    }
}
