using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskinApi.DAL
{
    public class Helper
    {
        private static readonly string url = "http://localhost:36244/api/Products";
        private static readonly string url1 = "http://localhost:36244/api/Products1";
        //This Method  is use for get Category
        public static async Task<String> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url + ""))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }

                    }
                }

            }
            return string.Empty;
        }
        //This Method is use for get products throug CategoryId
        public static async Task<String> GetbyId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url1 + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }

                    }
                }

            }
            return string.Empty;
        }
    }
}
