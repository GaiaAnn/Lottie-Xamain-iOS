using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TableCell;

namespace Lottie_Test.Services
{
	public class ApiService
	{
		public ApiService()
		{
		}
		//private static HttpClient GetApiHttpClient()
		//{
		//  var client = new HttpClient(new NativeMessageHandler());
		//  client.DefaultRequestHeaders.Clear();
		//  return client;
		//}

		public async static Task<List<CellContent.Info>> LoadAnimalData()
		{
			#region BK Code
			string Host = "http://data.taipei/opendata/datalist/";
			string Method = "apiAccess?scope=resourceAquire&rid=f4a75ba9-7721-4363-884d-c3820b0b917c";

			using (HttpClient client = new HttpClient(new NativeMessageHandler()))
			{
				// Set Host URL
				client.BaseAddress = new Uri(Host);

				// Http Get
				HttpResponseMessage responseMessage = client.GetAsync(Method).Result;

				if (!responseMessage.IsSuccessStatusCode)
				{
					throw new HttpRequestException(responseMessage.StatusCode.ToString());
				}
				var responseText = responseMessage.Content.ReadAsStringAsync().Result;

				JObject result = JsonConvert.DeserializeObject<JObject>(responseText);
				string jsonString = result["result"]["results"].ToString();
				List<CellContent.Info> animals = JsonConvert.DeserializeObject<List<CellContent.Info>>(jsonString);
				return animals;
			}
			#endregion

			//List<CellContent.Info> animals = new List<CellContent.Info>();
			////Do Http Get
			//string Host = "http://data.taipei/opendata/datalist/";
			//string Method = "apiAccess?scope=resourceAquire&rid=f4a75ba9-7721-4363-884d-c3820b0b917c";
			//try
			//{
			//  using (var client = new HttpClient(new NativeMessageHandler()))
			//  {
			//      client.BaseAddress = new Uri(Host);
			//      HttpResponseMessage responseMsg = new HttpResponseMessage();
			//      responseMsg = client.GetAsync(Method).Result;
			//      if (!responseMsg.IsSuccessStatusCode)
			//      {
			//          throw new HttpRequestException(responseMsg.StatusCode.ToString());
			//      }
			//      var responseText = responseMsg.Content.ReadAsStringAsync().Result;
			//      JObject result = JsonConvert.DeserializeObject<JObject>(responseText);
			//      string jsonString = result["result"]["results"].ToString();
			//      animals = JsonConvert.DeserializeObject<List<CellContent.Info>>(jsonString);            
			//  }
			//}
			//catch (Exception ex)
			//{
			//  Console.WriteLine("Error !!!!! " + ex.ToString());
			//}
			//return animals;

		}
	}
}
