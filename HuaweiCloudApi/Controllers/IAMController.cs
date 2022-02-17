using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using HuaweiCloud.SDK.Core;
using HuaweiCloud.SDK.Core.Auth;
using HuaweiCloud.SDK.Iam;
using HuaweiCloud.SDK.Iam.V3;
using HuaweiCloud.SDK.Iam.V3.Model;
using HuaweiCloudApi.Models;

namespace HuaweiCloudApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IAMController : Controller
    {
        public IAMController()
        {

        }
        /// <summary>
        /// get token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public MobileBaseResponseData<CreateTemporaryAccessKeyByTokenResponse> GetToken()
        {
            var res = new MobileBaseResponseData<CreateTemporaryAccessKeyByTokenResponse>();
            const string ak = "XP4H5VOL8STTN6PKUMRP";
            const string sk = "V2oO5T03aFtCVSZlvD8hfSpTGd5PCAIN9wIAv9OU";
            var config = HttpConfig.GetDefaultConfig();
            config.IgnoreSslVerification = true;
            var auth = new GlobalCredentials(ak, sk);

            var client = IamClient.NewBuilder()
                    .WithCredential(auth)
                    .WithRegion(IamRegion.ValueOf("cn-east-2"))
                    .WithHttpConfig(config)
                    .Build();
            var req = new CreateTemporaryAccessKeyByTokenRequest
            {
            };
            List<TokenAuthIdentity.MethodsEnum> listTokenAuthIdentityMethods = new List<TokenAuthIdentity.MethodsEnum>();
            listTokenAuthIdentityMethods.Add(TokenAuthIdentity.MethodsEnum.FromValue("token"));
            TokenAuthIdentity identityAuth = new TokenAuthIdentity()
            {
                Methods = listTokenAuthIdentityMethods
            };
            TokenAuth authbody = new TokenAuth()
            {
                Identity = identityAuth
            };
            req.Body = new CreateTemporaryAccessKeyByTokenRequestBody()
            {
                Auth = authbody
            };
            CreateTemporaryAccessKeyByTokenResponse resp = new CreateTemporaryAccessKeyByTokenResponse();
            try
            {
                resp = client.CreateTemporaryAccessKeyByToken(req);
                res.Status = EReponseCode.Success;
                res.Message = "操作成功";
                res.Data = resp;
            }
            catch (RequestTimeoutException requestTimeoutException)
            {
                Console.WriteLine(requestTimeoutException.ErrorMessage);
                res.Status = EReponseCode.BusinessError;
                res.Message = requestTimeoutException.ErrorMessage;
            }
            catch (ServiceResponseException clientRequestException)
            {
                Console.WriteLine(clientRequestException.HttpStatusCode);
                Console.WriteLine(clientRequestException.ErrorCode);
                Console.WriteLine(clientRequestException.ErrorMsg);
                res.Status = EReponseCode.BusinessError;
                res.Message = clientRequestException.ErrorMsg;
            }
            catch (ConnectionException connectionException)
            {
                Console.WriteLine(connectionException.ErrorMessage);
                res.Status = EReponseCode.BusinessError;
                res.Message = connectionException.ErrorMessage;
            }
            return res;
        }
    }
}
