using JWT;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Common
{
    public class AuthToken
    {

        internal static string Secret { get; } = "aG21MalfIU2l2NvcmK2Lamgkn02wkmeg09iasjet";

        public string Raw { get; set; }
        public bool Valid
        {
            get
            {
                return verifyToken();
            }
        }
        public User User
        {
            get
            {
                try
                {
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                    var tc = decoder.DecodeToObject<TokenContainer>(Raw, Secret, verify: true);
                    return tc.user;
                }
                catch (TokenExpiredException)
                {
                    return null;
                }
                catch (SignatureVerificationException)
                {
                    return null;
                }
            }
        }

        public AuthToken()
        {
        }

        public AuthToken(string rawToken)
        {
            this.Raw = rawToken;
        }

        private bool verifyToken()
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var tc = decoder.DecodeToObject<TokenContainer>(Raw, Secret, verify: true);
                return true;
            }
            catch (TokenExpiredException)
            {
                return false;
            }
            catch (SignatureVerificationException)
            {
                return false;
            }
        }

    }
}
