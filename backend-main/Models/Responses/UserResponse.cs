using System.ComponentModel.DataAnnotations;

namespace backend_main.Models.Responses
{
	public class UserResponse
	{
		public int Id { get; set; } = -1;
		public string Username { get; set; }
		public string Token { get; set; }

		public UserResponse()
		{}

		public UserResponse(int id, string username, string token)
		{
			Id = id;
			Username = username;
			Token = token;
		}
	}
}
