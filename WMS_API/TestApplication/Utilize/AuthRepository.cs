using EncryptDecryptAssembly;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using POMS.Entity;
using POMS.Repository.Masters;
using System;
using System.Threading.Tasks;
using TestApplication.Models;


public class AuthRepository : IDisposable
{
    private AuthContext authContext;
    private UserManager<IdentityUser> userManager;
    private EmployeeRepository EmployeeManager;

    public AuthRepository()
    {
        EmployeeManager = new EmployeeRepository();
        authContext = new AuthContext();
        userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(authContext));
    }

    public async Task<IdentityResult> RegisterUser(Employee userModel)
    {
        IdentityUser user = new IdentityUser
        {
            UserName = userModel.UserName
        };

        //var Employee = new Employee
        //{
        //    UserName = userModel.UserName
        //};

       
        EmployeeManager.EmployeeInsert(userModel);
        var result = await userManager.CreateAsync(user, userModel.Password);
        return result;
    }

    public async Task<IdentityUser> FindUser(string userName, string password)
    {
        return await userManager.FindAsync(userName, password);
    }

    public async Task<Employee>  FindEmployee(string UserName, string Password)
    {
        EncryptDecrypt objEncrypt = new EncryptDecrypt();
         Password = objEncrypt.Encrypt(Password, "");
        return EmployeeManager.LoginGet(UserName, Password)[0];
    }

    public void Dispose()
    {
        authContext.Dispose();
        userManager.Dispose();
    }
}