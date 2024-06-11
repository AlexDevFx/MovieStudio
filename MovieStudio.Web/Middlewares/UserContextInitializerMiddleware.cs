using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using MovieStudio.Contacts.Users;

namespace MovieStudio.Middlewares;

public class UserContextInitializerMiddleware
{
    private readonly RequestDelegate _next;

	public UserContextInitializerMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IAuthorizedUser authorizedUser)
	{
		var endpoint = context.GetEndpoint();
		if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
		{
			await _next(context);
			return;
		}

		if (context.User.Identity?.IsAuthenticated == true)
		{
			authorizedUser.Init(GetClaimValue<int>(context.User.Identity, WebAppConsts.TokenClaims.UserId),
				GetClaimIntValue(context.User.Identity, WebAppConsts.TokenClaims.DirectorId),
				GetClaimIntValue(context.User.Identity, WebAppConsts.TokenClaims.ActorId),
				WebAppConsts.RolesFromString(GetClaimValue<string>(context.User.Identity, WebAppConsts.TokenClaims.Roles)));
		}

		await _next(context);
	}

	private static T GetClaimValue<T>(IIdentity identity, string type) where T : IConvertible
	{
		if (identity == null)
			throw new ArgumentNullException(nameof (identity));
		if (identity is ClaimsIdentity identity1)
		{
			string? firstValue = identity1.FindFirst(type)?.Value;
			if (firstValue != null)
				return (T) Convert.ChangeType(firstValue, typeof (T), CultureInfo.InvariantCulture);
		}
		return default;
	}

	private static int? GetClaimIntValue(IIdentity identity, string type)
	{
		if (identity == null)
			throw new ArgumentNullException(nameof (identity));
		if (identity is ClaimsIdentity identity1)
		{
			string? firstValue = identity1.FindFirst(type)?.Value;
			if (firstValue != null && int.TryParse(firstValue, out int parsed))
				return parsed;
		}
		return null;
	}
}