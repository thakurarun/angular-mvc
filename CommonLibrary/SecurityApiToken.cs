using System;
using System.Data;
using System.IO;
using System.Text;
using JWT;
using System.Collections.Generic;

namespace CommonLibrary
{
    /// <summary>
    /// https://github.com/jwt-dotnet/jwt
    /// </summary>
    public class SecurityApiToken
    {
        private static readonly SecurityApiToken instance = new SecurityApiToken();

        private static readonly string _secretKey = "howwedoit";

        public static SecurityApiToken Instance
        {
            get
            {
                if (instance == null)
                    throw (new Exception("SecurityApiToken not initialized"));
                return instance;
            }
        }
        private SecurityApiToken()
        {

        }

        public string EncryptToString(string source)
        {
            var payload = new Dictionary<string, object>(){
                    { "token", source }
            };
            string token = JWT.JsonWebToken.Encode(payload, _secretKey, JWT.JwtHashAlgorithm.HS256);
            return token;
        }
        public string ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return null;
            try
            {
                string jsonPayload = JWT.JsonWebToken.Decode(token, _secretKey);
                return jsonPayload;
            }
            catch (JWT.SignatureVerificationException)
            {
                return null;
            }
        }
    }
}
