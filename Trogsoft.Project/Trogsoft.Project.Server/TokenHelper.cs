using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trogsoft.Project.Common;

namespace Trogsoft.Project.Server
{
    public class TokenHelper
    {

        internal static string Secret { get; } = "aG21MalfIU2l2NvcmK2Lamgkn02wkmeg09iasjet";

        public static AuthToken Create(User user)
        {

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            IDateTimeProvider provider = new UtcDateTimeProvider();

            var now = provider.GetNow().AddHours(2);
            var unixEpoch = JwtValidator.UnixEpoch; 
            var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);

            TokenContainer tokenContainer = new TokenContainer();
            tokenContainer.user = user;
            tokenContainer.exp = secondsSinceEpoch;

            var tk = new AuthToken(encoder.Encode(tokenContainer, Secret));
            return tk;

        }
    }
}
