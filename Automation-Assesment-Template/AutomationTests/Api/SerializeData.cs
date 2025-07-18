using System;
using System.Collections.Generic;

namespace AutomationTests.Api;

public class UserData
{
    public int id { get; set; }
    public string email { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string avatar { get; set; }
}

public class SupportData
{
    public string url { get; set; }
    public string text { get; set; }
}

public class UserResponse
{
    public UserData data { get; set; }
    public SupportData support { get; set; }
}

public class UsersListResponse
{
    public int page { get; set; }
    public int per_pge { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public List<UserData> data { get; set; } // A list of UserData objects
    public SupportData Support { get; set; }
}

public class UserCreationRequest
{
    public string name { get; set; }
    public string job { get; set; }
}
    
public class UserCreationResponse
{
    public string name { get; set; }
    public string job { get; set; }
    public string id { get; set; }
    public DateTime createdAt { get; set; }
}

public class UserUpdateResponse
{
    public string name { get; set; }
    public string job { get; set; }
    public DateTime createdAt { get; set; }
}

public class UserRegisterRequest
{
    public string email { get; set; }
    public string password { get; set; }
}

public class UserRegisterResponse
{
    public int id { get; set; }
    public string token { get; set; }
}




