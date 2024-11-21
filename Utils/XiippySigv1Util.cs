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
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace Xiippy.POSeComSDK.Light.Utils
{
    public class XiippySigv1Util
    {
        public static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }
        public static void AddXiippyV1RequestSignatureToClient(string content, HttpClient httpClient, string ApiKey)
        {

            if (!string.IsNullOrEmpty(ApiKey))
            {
                var Key = Convert.FromBase64String(ApiKey);

                var Now = DateTimeOffset.Now.ToUnixTimeMilliseconds();


                var StringToSign = $"{content}_{Now}";


                var SigBytes = HashHMAC(Key, Encoding.UTF8.GetBytes(StringToSign));
                var SignatureHeaderValue = Convert.ToBase64String(SigBytes);

                // add the moment header
                httpClient.DefaultRequestHeaders.Remove(XiippySDKBridgeApiClient.XiippySDKBridgeApiClient.XiippyReqMomentHeader);
                httpClient.DefaultRequestHeaders.Add(XiippySDKBridgeApiClient.XiippySDKBridgeApiClient.XiippyReqMomentHeader, Now.ToString());

                httpClient.DefaultRequestHeaders.Remove(XiippySDKBridgeApiClient.XiippySDKBridgeApiClient.XiippyReqSignatureHeader);
                httpClient.DefaultRequestHeaders.Add(XiippySDKBridgeApiClient.XiippySDKBridgeApiClient.XiippyReqSignatureHeader, SignatureHeaderValue);

            }


        }




        public static bool VerifyXiippyV1RequestSignature(string content, long Moment, string signature, string ApiKey)
        {
            if (!string.IsNullOrEmpty(ApiKey))
            {
                var Key = Convert.FromBase64String(ApiKey);

                var Now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                if (Now - Moment > 20000) // allow a 20-second window of validity
                {
                    return false;
                }

                var StringToSign = $"{content}_{Moment}";


                var SigBytes = HashHMAC(Key, Encoding.UTF8.GetBytes(StringToSign));
                var SigBytesPassed = Convert.FromBase64String(signature);
                return SigBytes.SequenceEqual(SigBytesPassed);

            }
            else return false;


        }
    }
}
