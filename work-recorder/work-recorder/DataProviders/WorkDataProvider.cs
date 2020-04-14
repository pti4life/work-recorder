using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using work_recorder.Modells;

namespace work_recorder.DataProviders
{
    class WorkDataProvider
    {
        private static string _URL = "http://localhost:1154/api/work";

        public static IList<Work> GetAll() 
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_URL).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var works = JsonConvert.DeserializeObject<List<Work>>(rawData);
                    return works;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void CreateWork(Work work)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(work);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_URL, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateWork(Work work)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(work);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_URL, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteWork(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(_URL + "/" + id).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
