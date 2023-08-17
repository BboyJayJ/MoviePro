using Microsoft.AspNetCore.Identity;

namespace MoviePro.Data.Services
{
	public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
	{
		public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
		{
			if (!password.Any(char.IsUpper))
			{
				return Task.FromResult(IdentityResult.Failed(new IdentityError
				{
					Code = "PasswordRequiresUpper",
					Description = "密碼必須包含至少一個大寫字母。"
				}));
			}

			return Task.FromResult(IdentityResult.Success);
		}
	}
}
