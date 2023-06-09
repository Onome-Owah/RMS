
using Xunit;
using RMS.Data.Entities;
using RMS.Data.Services;

namespace RMS.Test;

// ==================== UserService Tests =============================
[Collection("Sequential")]
public class UserServiceTests
{
    private readonly IUserService svc;

    public UserServiceTests()
    {
        // general arrangement
        svc = new UserServiceDb();
        
        // ensure data source is empty before each test
        svc.Initialise();
    }

    // ========================== User Tests =========================

    [Fact] // --- Register Valid User test
    public void User_Register_WhenValid_ShouldReturnUser()
    {
        // arrange 
        var reg = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
        
        // act
        var user = svc.GetUserByEmail(reg.Email);
        
        // assert
        Assert.NotNull(reg);
        Assert.NotNull(user);
    } 

    [Fact] // --- Register Duplicate Test
    public void User_Register_WhenDuplicateEmail_ShouldReturnNull()
    {
        // arrange 
        var u1 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
        
        // act
        var u2 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);

        // assert
        Assert.NotNull(u1);
        Assert.Null(u2);
    } 

    [Fact] // --- Authenticate Invalid Test
    public void User_Authenticate_WhenInValidCredentials_ShouldReturnNull()
    {
        // arrange 
        var u = svc.Register("XXX", "xxx@email.com", "password", Role.admin);
    
        // act
        var user = svc.Authenticate("xxx@email.com", "junkpassword");
        // assert
        Assert.Null(user);

    } 

    [Fact] // --- Authenticate Valid Test
    public void User_Authenticate_WhenValidCredentials_ShouldReturnUser()
    {
        // arrange 
        var u = svc.Register("XXX", "xxx@email.com", "password", Role.admin);
    
        // act
        var user = svc.Authenticate("xxx@email.com", "password");
        
        // assert
        Assert.NotNull(user);
    } 
 
    [Fact] // --- GetUserById Valid Test
    public void User_GetUser_WhenExists_ShouldReturnUser()
    {
        // arrange 
        var u = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
    
        // act
        var user = svc.GetUser(u.Id);
        
        // assert
        Assert.NotNull(user);
    } 

    [Fact] // --- GetUserById InValid Test
    public void User_GetUser_WhenDoesntExist_ShouldReturnNull()
    {
        // arrange 
      
        // act
        var user = svc.GetUser(1);
        
        // assert
        Assert.Null(user);
    } 

    [Fact] // --- GetUserById Valid Test
    public void User_GetUserByEmail_WhenExists_ShouldReturnUser()
    {
        // arrange 
        var u = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
    
        // act
        var user = svc.GetUserByEmail(u.Email);
        
        // assert
        Assert.NotNull(user);
    } 

    [Fact] // --- GetUserById InValid Test
    public void User_GetUserByEmail_WhenInvalidEmailOrDoesntExist_ShouldReturnNull()
    {
        // arrange 
         
        // act
        var user = svc.GetUserByEmail("junkemail");
        
        // assert
        Assert.Null(user);
    } 
}
