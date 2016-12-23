using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.Security
{
    public class SessionPersister
    {
        static string usernameSessionvar = "username";
        static string userIdSessionvar = "userId";
        static string userRoleSessionvar = "userRole";

        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[usernameSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[usernameSessionvar] = value;
            }
        }

        public static string UserId
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[userIdSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[userIdSessionvar] = value;
            }
        }

        public static string UserRole
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[userRoleSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[userRoleSessionvar] = value;
            }
        }
    }
}