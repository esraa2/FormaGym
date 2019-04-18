using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Forma_Gym.FaceBook
{
	public class FacebookBackCannelHandler :HttpClientHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			//because fb v2.4 is different to v2.3
			if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
			{
				request.RequestUri = new Uri(request.RequestUri.AbsolutePath.Replace("?access_token", "&access_token"));
			}
			return await base.SendAsync(request, cancellationToken);
		}
	}
}