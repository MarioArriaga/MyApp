using System;
using System.Web.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Collections.Generic;
using DAL.Entities;
namespace MyApp
{
    public partial class _Default : Page
    {
        private static HttpClient client;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void RecordData_ClickAsync(object sender, EventArgs e)
        {
            var person = new Person()
            {
                Name = Name.Text,
                Address = Address.Text,
                Telephone = Telephone.Text
            };
            
            try
            {
                using (client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:35796/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsJsonAsync("api/People", person);

                    if(response.IsSuccessStatusCode)
                    {
                        HttpMessageTextBox.Text = await response.Content.ReadAsStringAsync();
                    }
                   
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}