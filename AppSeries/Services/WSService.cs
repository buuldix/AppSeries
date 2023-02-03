using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;

using System.Threading.Tasks;
using AppSeries.Models;
using System.Net.Http.Json;

namespace AppSeries.Services
{
    internal class WSService
    {
        private HttpClient client;


        public WSService(string uri)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        public async Task<List<Serie>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<Serie> GetDeviseAsync(string nomControleur, int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Serie>($"{nomControleur}/{id}");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string nomControleur, Serie serie)
        {
            try
            {
                return await client.PostAsJsonAsync($"{nomControleur}",serie);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string nomControleur, Serie serie)
        {
            try
            {
                return await client.PutAsJsonAsync($"{nomControleur}", serie);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string nomControleur, int id)
        {
            try
            {
                return await client.DeleteAsync($"{nomControleur}/{id}");
            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}
