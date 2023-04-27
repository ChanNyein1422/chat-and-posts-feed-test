using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Infra.Helper
{
    public class ApiRequest<T, U>
    {
        public static async Task<string> PostGetString(string url, T entity, bool isCompressed = true)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                using (var content = new StringContent(JsonConvert.SerializeObject(entity), UTF8Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            return objsJsonString;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

            }
        }

        public static async Task<U> PostDiffRequest(string url, T entity, bool isCompressed = true)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                using (var content = new StringContent(JsonConvert.SerializeObject(entity), UTF8Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<U>(objsJsonString);

                            //var jsonContent = System.Text.Json.JsonSerializer.Deserialize<U>(objsJsonString);

                            return jsonContent;
                        }
                        else
                        {
                            return default(U);

                        }
                    }
                }
            }
        }
    }

    public class ApiRequest<T>
    {


        public static async Task<T> GetRequest(string url, bool isCompressed = false, string rootUrl = null)
        {
            try
            {
                if (isCompressed)
                {
                    using (var client = new HttpClient())
                    {
                        //client.DefaultRequestHeaders.Add("Authorization",string.Format("Bearer {0}",accessToken));
                        client.BaseAddress = new Uri(url);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
                        using (var response = await client.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var objsJsonString = await response.Content.ReadAsStringAsync();
                                var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                                return jsonContent;
                            }
                            else
                            {
                                return default(T);
                            }
                        }
                    }
                }
                else
                {
                    using (var client = new HttpClient())
                    {

                        //client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                        client.BaseAddress = new Uri(url);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        using (var response = await client.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var objsJsonString = await response.Content.ReadAsStringAsync();
                                var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                                return jsonContent;
                            }
                            else
                            {
                                var objsJsonString = await response.Content.ReadAsStringAsync();
                                return default(T);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var x = ex;
                return default(T);
            }
        }
        public static async Task<T> DeleteRequest(string url)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await client.DeleteAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                            return jsonContent;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
            catch
            {
                return default(T);
            }
        }
        public static async Task<T> PostRequest(string url, T entity, string rootUrl = null)
        {

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                //client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
                using (var content = new StringContent(JsonConvert.SerializeObject(entity), UTF8Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                            return jsonContent;
                        }
                        else
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            return default(T);
                        }
                    }
                }
            }
        }

        internal static Task PostRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}
