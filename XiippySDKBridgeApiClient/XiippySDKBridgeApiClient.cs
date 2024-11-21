// *******************************************************************************************
// Copyright © 2019 Xiippy.ai. All rights reserved. Australian patents awarded. PCT patent pending.
//
// NOTES:
//
// - No payment gateway SDK function is consumed directly. Interfaces are defined out of such interactions and then the interface is implemented for payment gateways. Design the interface with the most common members and data structures between different gateways. 
// - A proper factory or provider must instantiate an instance of the interface that is interacted with.
// - Any major change made to SDKs should begin with the c sharp SDK with the mindset to keep the high-level syntax, structures and class names the same to minimise porting efforts to other languages. Do not use language specific features that do not exist in other languages. We are not in the business of doing the same thing from scratch multiple times in different forms.
// - Pascal Case for naming conventions should be used for all languages
// - No secret or passwords or keys must exist in the code when checked in
//
// *******************************************************************************************

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xiippy.POSeComSDK.Light.Models;
using Xiippy.POSeComSDK.Light.Utils;

namespace Xiippy.POSeComSDK.Light.XiippySDKBridgeApiClient
{
    public class XiippySDKBridgeApiClient
    {
        public const string XiippyReqSignatureHeader = "XIIPPY-API-SIG-V1";
        public const string XiippyReqMomentHeader = "XIIPPY-MOMENT-V1";


        private const string ApplicationJson = "application/json";
        private string BridgeBaseUrl = "https://localhost:19019";
        public readonly HttpClient client = new HttpClient();
        bool IsTest;
        string BridgeAPIKey;
        string MerchantID;
        string MerchantGroupID;

        public XiippySDKBridgeApiClient(bool _IsTest, string _BridgeAPIKey, string _BridgeBaseUrl, string _MerchantID, string _MerchantGroupID)
        {
            BridgeAPIKey = _BridgeAPIKey;
            BridgeBaseUrl = _BridgeBaseUrl;
            IsTest = _IsTest;
            MerchantID = _MerchantID;
            MerchantGroupID = _MerchantGroupID;
            /*if (IsTest)
            {
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                    {
                        return true;
                    };

                client = new HttpClient(handler);

            }*/
        }


        /// <summary>
        /// Initiates a payment request by receiving an instance of PaymentProcessingRequest
        /// </summary>
        /// <param name="req"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<PaymentProcessingResponse> InitiateXiippyPayment(PaymentProcessingRequest req, CancellationToken cancellationToken = default)
        {
            var resInStr = JsonConvert.SerializeObject(req, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var httpContent = new StringContent(resInStr, Encoding.UTF8, ApplicationJson);

            // deal with headers
            client.DefaultRequestHeaders.Remove("Accept");
            // this is critical!
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(ApplicationJson);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));


            // add the authentication signature headers
            XiippySigv1Util.AddXiippyV1RequestSignatureToClient(resInStr, client, BridgeAPIKey);

            var response = await client.SendAsync(
                 new HttpRequestMessage(HttpMethod.Post, $"{BridgeBaseUrl}{Constants.InitiateXiippyPaymentPath}")
                 {
                    // Version = HttpVersion.Version20,
                     Content= httpContent
                 },  cancellationToken);

           
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Response Code: {response.StatusCode} Body: {responseString}");
            }

            var returnedObj = JsonConvert.DeserializeObject<PaymentProcessingResponse>(responseString);


            return returnedObj;
        }






        public async Task<RefundCardPaymentResponse> RefundCardPayment(RefundCardPaymentRequest req, CancellationToken cancellationToken = default)
        {
            var resInStr = JsonConvert.SerializeObject(req, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var httpContent = new StringContent(resInStr, Encoding.UTF8, ApplicationJson);

            // deal with headers
            client.DefaultRequestHeaders.Remove("Accept");
            // this is critical!
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(ApplicationJson);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));


            // add the authentication signature headers
            XiippySigv1Util.AddXiippyV1RequestSignatureToClient(resInStr, client, BridgeAPIKey);

            var response = await client.SendAsync(
                 new HttpRequestMessage(HttpMethod.Post, $"{BridgeBaseUrl}{Constants.RefundCardPaymentPath}")
                 {
                     // Version = HttpVersion.Version20,
                     Content = httpContent
                 }, cancellationToken);


            var responseString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Response Code: {response.StatusCode} Body: {responseString}");
            }

            var returnedObj = JsonConvert.DeserializeObject<RefundCardPaymentResponse>(responseString);


            return returnedObj;
        }

    }
}
