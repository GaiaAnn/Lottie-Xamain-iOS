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
		private static string jsonData = "[{\"_id\": \"10703261002010\",\"animal_subid\": \"10702060015\",\"animal_area_pkid\": 10,\"animal_shelter_pkid\": 67,\"animal_place\": \"\u5357\u5C6F\u5712\u5340\",\"Type\": \"\u72D7\",\"Sex\": \"F\",\"animal_bodytype\": \"MEDIUM\",\"animal_colour\": \"\u9ED1\u8272\",\"animal_age\": \"ADULT\",\"animal_sterilization\": \"T\",\"animal_bacterin\": \"N\",\"animal_foundplace\": \"\",\"animal_title\": \"\",\"animal_status\": \"OPEN\",\"Note\": \"\u5DE6\u5F8C\u80A2\u7591\u53D7\u50B7\u7121\u6CD5\u8457\u5730\uFF0C\u9700\u81F3\u91AB\u9662\u505A\u8A73\u7D30\u7684\u6AA2\u67E5\uFF0C\u76EE\u524D\u4ECD\u5F88\u6709\u6D3B\u529B\u7684\u611B\u8DF3\u8DF3\u6492\u5B0C\u3002\",\"animal_caption\": \"\",\"animal_opendate\": \"2018-03-26\",\"animal_closeddate\": \"2999-12-31\",\"animal_update\": \"2018-03-29 22:22:26\",\"animal_createtime\": \"2018-03-26 20:04:19\",\"shelter_name\": \"\u81FA\u4E2D\u5E02\u52D5\u7269\u4E4B\u5BB6\u5357\u5C6F\u5712\u5340\",\"album_name\": null,\"ImageName\": \"http://animal-adoption.coa.gov.tw/uploads/animal_album/67/5c8c9bebc8c3b88f0ee62cff3436dfd5.png\",\"album_base64\": null,\"album_update\": null,\"cDate\": \"2018-03-29T22:29:26.387\",\"Resettlement\": \"\u81FA\u4E2D\u5E02\u5357\u5C6F\u5340\u4E2D\u53F0\u8DEF601\u865F\",\"shelter_tel\": \"04-23850976\"},{\"_id\": \"10601050501002\",\"animal_subid\": \"1051802\",\"animal_area_pkid\": 5,\"animal_shelter_pkid\": 78,\"animal_place\": \"\u5B9C\u862D\u7E23\u6D41\u6D6A\u52D5\u7269\u4E2D\u9014\u4E4B\u5BB6\",\"Type\": \"\u72D7\",\"Sex\": \"M\",\"animal_bodytype\": \"SMALL\",\"animal_colour\": \"\u767D\",\"animal_age\": \"CHILD\",\"animal_sterilization\": \"N\",\"animal_bacterin\": \"N\",\"animal_foundplace\": \"\u58EF\u570D\u53E4\u7D50\u8DEF\",\"animal_title\": \"\",\"animal_status\": \"OPEN\",\"Note\": \"\",\"animal_caption\": \"\",\"animal_opendate\": \"2017-01-05\",\"animal_closeddate\": \"2999-12-31\",\"animal_update\": \"2018-03-29 22:22:17\",\"animal_createtime\": \"2017-01-05 23:39:28\",\"shelter_name\": \"\u5B9C\u862D\u7E23\u6D41\u6D6A\u52D5\u7269\u4E2D\u9014\u4E4B\u5BB6\",\"album_name\": null,\"ImageName\": \"http://animal-adoption.coa.gov.tw/uploads/animal_album/78/3c2c3ecfd635108cde9b37533e67398f.jpg\",\"album_base64\": null,\"album_update\": null,\"cDate\": \"2018-03-29T22:27:11.703\",\"Resettlement\": \"\u5B9C\u862D\u7E23\u4E94\u7D50\u9109\u6210\u8208\u6751\u5229\u5BF6\u8DEF60\u865F\",\"shelter_tel\": \"039-602350\"},{\"_id\": \"10608040501002\",\"animal_subid\": \"1060905\",\"animal_area_pkid\": 5,\"animal_shelter_pkid\": 78,\"animal_place\": \"\u5B9C\u862D\u7E23\u6D41\u6D6A\u52D5\u7269\u4E2D\u9014\u4E4B\u5BB6\",\"Type\": \"\u72D7\",\"Sex\": \"M\",\"animal_bodytype\": \"BIG\",\"animal_colour\": \"\u7C73\u9EC3\",\"animal_age\": \"ADULT\",\"animal_sterilization\": \"N\",\"animal_bacterin\": \"N\",\"animal_foundplace\": \"\u5B9C\u862D\u5EFA\u862D\u5357\u8DEF\",\"animal_title\": \"\",\"animal_status\": \"OPEN\",\"Note\": \"\",\"animal_caption\": \"\",\"animal_opendate\": \"2017-08-04\",\"animal_closeddate\": \"2999-12-31\",\"animal_update\": \"2018-03-29 22:22:12\",\"animal_createtime\": \"2017-08-04 09:45:30\",\"shelter_name\": \"\u5B9C\u862D\u7E23\u6D41\u6D6A\u52D5\u7269\u4E2D\u9014\u4E4B\u5BB6\",\"album_name\": null,\"ImageName\": \"http://animal-adoption.coa.gov.tw/uploads/animal_album/78/62ce3a1f18cafdff77b5bcf69ec99edc.jpg\",\"album_base64\": null,\"album_update\": null,\"cDate\": \"2018-03-29T22:28:20.157\",\"Resettlement\": \"\u5B9C\u862D\u7E23\u4E94\u7D50\u9109\u6210\u8208\u6751\u5229\u5BF6\u8DEF60\u865F\",\"shelter_tel\": \"039-602350\"},{\"_id\": \"10402160201004\",\"animal_subid\": \"104021608\",\"animal_area_pkid\": 2,\"animal_shelter_pkid\": 49,\"animal_place\": \"\u81FA\u5317\u5E02\",\"Type\": \"\u72D7\",\"Sex\": \"M\",\"animal_bodytype\": \"SMALL\",\"animal_colour\": \"\u68D5\u9ED1\",\"animal_age\": \"CHILD\",\"animal_sterilization\": \"F\",\"animal_bacterin\": \"N\",\"animal_foundplace\": \"\u6606\u660E\u8857\u6D3E\u51FA\u6240\",\"animal_title\": \"\",\"animal_status\": \"OPEN\",\"Note\": \"\",\"animal_caption\": \"15433\",\"animal_opendate\": \"2015-03-18\",\"animal_closeddate\": \"2999-12-31\",\"animal_update\": \"2018-03-29 22:21:51\",\"animal_createtime\": \"2015-02-16 14:35:01\",\"shelter_name\": \"\u81FA\u5317\u5E02\u52D5\u7269\u4E4B\u5BB6\",\"album_name\": null,\"ImageName\": \"http://animal-adoption.coa.gov.tw/uploads/animal_album/49/f5fd6c4e51cfe7d66854e7d0f1794bd3.jpg\",\"album_base64\": null,\"album_update\": null,\"cDate\": \"2018-03-29T22:24:01.477\",\"Resettlement\": \"\u81FA\u5317\u5E02\u5167\u6E56\u5340\u6F6D\u7F8E\u8857852\u865F\",\"shelter_tel\": \"02-87913254;02-87913255\"}]";
		public ApiService()
		{
		}
	
		public async static Task<List<CellContent.Info>> LoadAnimalData()
		{
			#region BK Code
			//string Host = "http://data.taipei/opendata/datalist/";
			//string Method = "apiAccess?scope=resourceAquire&rid=f4a75ba9-7721-4363-884d-c3820b0b917c";
			string Host = "http://data.coa.gov.tw/Service/OpenData/AnimalOpenData.aspx";
			string Method = string.Empty;
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

				//get result from API
				//JObject result = JsonConvert.DeserializeObject<JObject>(responseText);
				//string jsonString = result["result"]["results"].ToString();
				//test data
				List<CellContent.Info> animals = JsonConvert.DeserializeObject<List<CellContent.Info>>(jsonData);
				return animals;
			}
			#endregion

	
		}
	}
}
