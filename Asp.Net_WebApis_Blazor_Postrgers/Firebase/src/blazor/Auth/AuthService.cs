using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace blazor.Auth
{
  public class AuthService : IAuthService
  {

    private readonly HttpClient httpClient;
    private readonly AuthenticationStateProvider authenticationStateProvider;
    private readonly ILocalStorageService localStorage;


    public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
    {
      this.httpClient = httpClient;
      this.authenticationStateProvider = authenticationStateProvider;
      this.localStorage = localStorage;
    }


    public async Task<string> Login(LoginModel loginModel)
    {
      var loginAsJson = JsonSerializer.Serialize(loginModel);
      var response = await httpClient.PostAsync("api/Usuario/login",
            new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

      if(!response.IsSuccessStatusCode)
      {
        return null!;
      }

      var loginResult = await response.Content.ReadAsStringAsync();
      await localStorage.SetItemAsStringAsync("authToken", loginResult);
      ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email!);
      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",loginResult);

      return loginResult;
    }

    public async Task Logout()
    {
      await localStorage.RemoveItemAsync("authToken");
      ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
      httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<string> Register(RegisterModel registerModel)
    {
       var registerAsJson = JsonSerializer.Serialize(registerModel);

       var response = await httpClient.PostAsync("api/Usuario/register", 
                new StringContent(registerAsJson, Encoding.UTF8, "application/json"));

      if (!response.IsSuccessStatusCode)
      {
        return null!;
      }

      var registerResult = await response.Content.ReadAsStringAsync();
      return registerResult;

    }
  }
}