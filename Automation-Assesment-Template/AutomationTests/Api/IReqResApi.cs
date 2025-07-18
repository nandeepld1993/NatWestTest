using Refit;
using System.Threading.Tasks;
using AutomationTests.Api;

public interface IReqResApi
{
        [Get("/api/users")]
        [Headers("x-api-key: reqres-free-v1")]
        Task<UsersListResponse> GetListOfUserAsync();
    
        [Get("/api/users/{id}")] 
        [Headers("x-api-key: reqres-free-v1")]
        Task<UserResponse> GetUserByIdAsync(int id);
        
        [Post("/api/users")]
        [Headers("x-api-key: reqres-free-v1")]
        Task<UserCreationResponse> CreateUserAsync([Body] UserCreationRequest user);
    
        [Put("/api/users/{id}")]
        [Headers("x-api-key: reqres-free-v1")]
        Task<UserUpdateResponse> UpdateUserAsync(int id,[Body] UserCreationRequest user);
    
        [Delete("/api/users/{id}")]
        [Headers("x-api-key: reqres-free-v1")]
        Task<ApiResponse<object>> DeleteUserAsync(int id);
        
        [Post("/api/register")]
        [Headers("x-api-key: reqres-free-v1")]
        Task<UserRegisterResponse> RegisterUserAsync([Body] UserRegisterRequest user);
}
