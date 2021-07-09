using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class UserDetails : System.Web.Services.Protocols.SoapHeader
{
    public string userName { get; set; }
    public string password { get; set; }


    public string checkUserExists(Func<string, string, string> checkCredentialsMethod,string username,string password)
    {
        return checkCredentialsMethod(username, password);
    }
}
