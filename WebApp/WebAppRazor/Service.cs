using System.Net;
using ApiTest.Entity;
using System;
using System.CodeDom;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using Microsoft.Extensions.ObjectPool;

namespace WebAppRazor
{
    public class Service
    {
        // Change URL according to API used (ApiTest or WebApp)
        private readonly string BaseUrl = "https://localhost:7097/";
        private readonly HttpClient client;
        public Service(HttpClient client)
        {
            this.client = client;
            client.DefaultRequestHeaders.Add("X-API-Key", "6CBxzdYcEgNDrRhMbDpkBF7e4d4Kib46dwL9ZE5egiL0iL5Y3dzREUBSUYVUwUkN");
        }

       

        public string GetBaseUrl()
        {
            return BaseUrl;
        }
        

        // GET
        public async Task<List<TodoItem>> GetTodos()
        {
            var response = await client.GetAsync(GetBaseUrl() + "api/TodoItems");

            var todos = JsonConvert.DeserializeObject<List<TodoItem>>(await response.Content.ReadAsStringAsync());
            return todos ?? new();
        }


        // GETBYID
        public async Task<TodoItem> GetTodo(long? id)
        {
            var response = await client.GetAsync(GetBaseUrl() + "api/TodoItems/" + id);

            var todo = JsonConvert.DeserializeObject<TodoItem>(await response.Content.ReadAsStringAsync());
            return todo ?? new();
        }


        // POST
        public async Task PostTodo(TodoItem todo)
        {
            var todoItemJson = new StringContent(
            JsonConvert.SerializeObject(todo),
            Encoding.UTF8,
            Application.Json);

            using var httpResponseMessage =
                await client.PostAsync(GetBaseUrl() + "api/TodoItems/", todoItemJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }


        // PUT
        public async Task PutTodo(long? id, TodoItem todo)
        {
            var todoItemJson = new StringContent(
            JsonConvert.SerializeObject(todo),
            Encoding.UTF8,
            Application.Json);

            using var httpResponseMessage =
                await client.PutAsync(GetBaseUrl() + "api/TodoItems/" + id, todoItemJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }


        // DELETE
        public async Task<HttpStatusCode> DeleteItemAsync(long? id)
        {
            HttpResponseMessage response = await client.DeleteAsync(GetBaseUrl() + "api/TodoItems/" + id);
            return response.StatusCode;
        }
    }
}
