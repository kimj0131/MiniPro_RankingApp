using Newtonsoft.Json;
using SharedData.Models;
using System.Text;

namespace RankingApp.Data.Services
{
	// [C <->S] <-> [S] - DB
	public class RankingService
	{
		HttpClient _httpClient;


		public RankingService(HttpClient client)
		{
			_httpClient = client;
		}

		// ** CRUD **

		// Create
		public async Task<GameResult> AddGameResult(GameResult gameResult)
		{
			// Json방식으로 변환하여 데이터를 송신
			string jsonStr = JsonConvert.SerializeObject(gameResult);
			var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

			var result = await _httpClient.PostAsync("api/ranking", content);

			if (result.IsSuccessStatusCode == false)
				throw new Exception("AddGameResult Failed");

			var resultContent = await result.Content.ReadAsStringAsync();
			// 받아온 string을 gameResult로 변환
			GameResult resGameResult = JsonConvert.DeserializeObject<GameResult>(resultContent);

			return resGameResult;
		}

		// Read
		public async Task<List<GameResult>> GetGameResultsAsync()
		{
			var result = await _httpClient.GetAsync("api/ranking");

			var resultContent = await result.Content.ReadAsStringAsync();
			List<GameResult> resGameResults = JsonConvert.DeserializeObject<List<GameResult>>(resultContent);

			return resGameResults;
		}

		// Update
		public async Task<bool> UpdateGameResult(GameResult gameResult)
		{
			// Json방식으로 변환하여 데이터를 송신
			string jsonStr = JsonConvert.SerializeObject(gameResult);
			var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

			var result = await _httpClient.PutAsync("api/ranking", content);

			if (result.IsSuccessStatusCode == false)
				throw new Exception("UpdateGameResult Failed");

			return true;
		}

		// Delete
		public async Task<bool> DeleteGameResult(GameResult gameResult)
		{
			var result = await _httpClient.DeleteAsync($"api/ranking/{gameResult.Id}");

			if (result.IsSuccessStatusCode == false)
				throw new Exception("UpdateGameResult Failed");

			return true;
		}
	}
}
