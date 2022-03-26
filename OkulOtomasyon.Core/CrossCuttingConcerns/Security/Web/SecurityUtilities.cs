using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace OkulOtomasyon.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var Identity = new Identity()
            {
                Id = SetId(ticket),
                Name = SetName(ticket),
                EMail = SetEmail(ticket),
                Roles = SetRoles(ticket),
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                AuthenticationType = SetAuthenticationType(ticket),
                IsAuthenticated = SetIsAuthenticationType(ticket)

            };
            return Identity;
        }

        private bool SetIsAuthenticationType(FormsAuthenticationTicket ticket)
        {
            return true;
        }

        private string SetAuthenticationType(FormsAuthenticationTicket ticket)
        {
            return "Forms";
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            throw new NotImplementedException();
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] Data = ticket.UserData.Split('|');
            return Data[3];
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            string[] Data = ticket.UserData.Split('|');
            return Data[2];
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] Data = ticket.UserData.Split('|');
            string[] roles = Data[1].Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
            return roles;

        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            string[] Data = ticket.UserData.Split('|');
            return new Guid(Data[4]);
        }
    }
}
