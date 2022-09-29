using API.Context;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext mycontext;

        public AccountRepository(MyContext myContext)
        {
            this.mycontext = myContext;
        }

        public ResponLogin Login(Login login)
        {
            var data = mycontext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Staff)
                .FirstOrDefault(x =>
                    x.User.Staff.Email.Equals(login.email) &&
                    x.User.Password.Equals(login.password));

            if (data != null)
            {
                ResponLogin responseLogin = new ResponLogin();
                {
                    responseLogin.Id = data.User.Id;
                    responseLogin.FullName = data.User.Staff.FullName;
                    responseLogin.Email = data.User.Staff.Email;
                    responseLogin.Role = data.Role.Name;
                };
                return responseLogin;
            }
            return null;
        }
    }
}
