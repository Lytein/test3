using StoreManagementBlazorApp.Entities;
using System.Net.Http.Json;

namespace StoreManagementBlazorApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        public ApiService(HttpClient http) => _http = http;

        // ======= USER / AUTH =======
        public async Task<UserDto?> LoginAsync(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("api/user/login",
                new { username, password });

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        public async Task<bool> RegisterAsync(string fullName, string username, string password)
        {
            var payload = new
            {
                full_name = fullName,
                username,
                password,
                role = 1 // default user
            };

            var response = await _http.PostAsJsonAsync("api/user/register", payload);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/user");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<UserDto>>() ?? new List<UserDto>();
            }
            catch
            {
                return new List<UserDto>();
            }
        }

        // ======= CUSTOMER =======
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _http.GetFromJsonAsync<List<Customer>>("api/customer") ?? new List<Customer>();
        }

        public async Task<Customer?> AddCustomerAsync(Customer customer)
        {
            var response = await _http.PostAsJsonAsync("api/customer", customer);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var response = await _http.PutAsJsonAsync($"api/customer/{customer.customer_id}", customer);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/customer/{id}");
            return response.IsSuccessStatusCode;
        }

        // ======= GENERIC GET / POST / PUT / DELETE =======
        public async Task<List<T>> GetListAsync<T>(string route)
        {
            return await _http.GetFromJsonAsync<List<T>>(route) ?? new List<T>();
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string route, TRequest obj)
        {
            var response = await _http.PostAsJsonAsync(route, obj);
            if (!response.IsSuccessStatusCode) return default;
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<bool> PutAsync<T>(string route, T obj)
        {
            var response = await _http.PutAsJsonAsync(route, obj);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string route)
        {
            var response = await _http.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }
    }
}
