using System;
using System.Threading.Tasks;
using Refit;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace AutomationTests.Api;

public class ApiTest
{
    private readonly ITestOutputHelper _output;
    private const string BaseUrl = "https://reqres.in";
    
    public ApiTest(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    [Trait("Category", "API")]
    public async Task Validate_User_Creation_From_CreateUser_Call()
    {
        //Added due to API response was taking more time default was 100ms
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(BaseUrl),
            Timeout = TimeSpan.FromSeconds(180)
        };
        var api = RestService.For<IReqResApi>(httpClient);
        
        try
        {
            var newUser = new UserCreationRequest
            {
                name = "Nandeep",
                job = "Software Engineer"
            };
                    
            UserCreationResponse userResponse = await api.CreateUserAsync(newUser);
            Assert.True(userResponse.id.All(char.IsDigit));
            _output.WriteLine("created user id: "+userResponse.id);
            Assert.Equal(newUser.name, userResponse.name);
            _output.WriteLine("user name: "+newUser.name);
            Assert.Equal(newUser.job, userResponse.job);
            _output.WriteLine("user job: "+newUser.job);
            Assert.Contains(DateTime.Now.ToString("dd-MM-yyyy"), userResponse.createdAt.ToString());
        }
        catch (Exception ex)
        {
            _output.WriteLine("New user creation failed unexpected error occurred: "+ex.Message);
        }
    }
    
    [Fact]
    [Trait("Category", "API")]
    public async Task Validate_User_Detail_From_GetById_Call()
    {
        //Added due to API response was taking more time default was 100ms
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(BaseUrl),
            Timeout = TimeSpan.FromSeconds(180)
        };
        var api = RestService.For<IReqResApi>(httpClient);
        
        try
        {
            UserResponse userResponse = await api.GetUserByIdAsync(2);
            _output.WriteLine("user id: "+userResponse.data.id);
            _output.WriteLine("First Name: "+userResponse.data.first_name);
            _output.WriteLine("Last Name: "+userResponse.data.last_name);
            _output.WriteLine("Email: "+userResponse.data.email);
            _output.WriteLine("Avatar URL: "+userResponse.data.avatar);
            _output.WriteLine("Support URL: "+userResponse.support.url);
            _output.WriteLine("Support Text: "+userResponse.support.text);
        }
        catch (Exception ex)
        {
            _output.WriteLine("Getting user details failed unexpected error occurred: "+ex.Message);
        }
    }
    
    [Fact]
    [Trait("Category", "API")]
    public async Task Validate_User_Details_From_GetByList_Call()
    {
        //Added due to API response was taking more time default was 100ms
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(BaseUrl),
            Timeout = TimeSpan.FromSeconds(180)
        };
        var api = RestService.For<IReqResApi>(httpClient);
        
        try
        {
            UsersListResponse userResponse = await api.GetListOfUserAsync();
            foreach (var user in userResponse.data)
            {
                _output.WriteLine("user id: "+user.id);
                _output.WriteLine("First Name: "+user.first_name);
                _output.WriteLine("Last Name: "+user.last_name);
                _output.WriteLine("Email: "+user.email);
                _output.WriteLine("Avatar URL: "+user.avatar);
            }
            _output.WriteLine("Support URL: "+userResponse.Support.url);
            _output.WriteLine("Support Text: "+userResponse.Support.text);
        }
        catch (Exception ex)
        {
            _output.WriteLine("Getting user details failed unexpected error occurred: "+ex.Message);
        }
    }
    
    [Fact]
    [Trait("Category", "API")]
    public async Task Validate_User_Update_From_UpdateUser_Call()
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(BaseUrl),
            Timeout = TimeSpan.FromSeconds(180)
        };
        var api = RestService.For<IReqResApi>(httpClient);
        
        try
        {
            var updateUser = new UserCreationRequest
            {
                name = "Nandeep",
                job = "Senior Software Engineer"
            };
                    
            UserUpdateResponse userResponse = await api.UpdateUserAsync(2, updateUser);
            Assert.Equal(updateUser.name, userResponse.name);
            _output.WriteLine("after update user name displayed as : "+updateUser.name);
            Assert.Equal(updateUser.job, userResponse.job);
            _output.WriteLine("after update user job displayed as: "+updateUser.job);
            Assert.Contains(DateTime.Now.ToString("dd-MM-yyyy"), userResponse.createdAt.ToString());
        }
        catch (Exception ex)
        {
            _output.WriteLine("Update user call failed unexpected error occurred: "+ex.Message);
        }
    }
    
    [Fact]
    [Trait("Category", "API")]
    public async Task Validate_Delete_User_Detail_From_DeleteById_Call()
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(BaseUrl),
            Timeout = TimeSpan.FromSeconds(180)
        };
        var api = RestService.For<IReqResApi>(httpClient);
        
        try
        {
            int userId = 2;
            ApiResponse<object> response = await api.DeleteUserAsync(userId);
            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
            _output.WriteLine(userId+ " ID deleted successfully.");
        }
        catch (Exception ex)
        {
            _output.WriteLine("Delete user failed unexpected error occurred: "+ex.Message);
        }
    }
    
    [Fact]
    [Trait("Category", "API")]
    public async Task Validate_User_Registration_From_RegisterUser_Call()
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(BaseUrl),
            Timeout = TimeSpan.FromSeconds(180)
        };
        var api = RestService.For<IReqResApi>(httpClient);
        
        try
        {
            var registerUser = new UserRegisterRequest
            {
                email = "eve.holt@reqres.in",
                password = "natwest"
            };

            UserRegisterResponse regUserResponse = await api.RegisterUserAsync(registerUser);
            Assert.NotEmpty(regUserResponse.id.ToString());
            _output.WriteLine("registered user id displayed as: " + regUserResponse.id);
            Assert.NotEmpty(regUserResponse.token);
            _output.WriteLine("registered user token displayed as: "+regUserResponse.token);
        }
        catch (Exception ex)
        {
            _output.WriteLine("user registration failed unexpected error occurred: "+ex.Message);
        }
    }
}