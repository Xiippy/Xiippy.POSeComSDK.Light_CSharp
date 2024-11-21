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
using System.Text;

namespace Xiippy.POSeComSDK.Light.Models
{
    public class PaymentNameAddressRequest
    {
        // new fields for payment processing request: only included IF we need the client to also process payment. Otherwise null
        public float PaymentRequest_Amount { get; set; } // this could be negative for a REFUND!
        public string PaymentRequest_Currency { get; set; }
        public List<string> allowedCardNetworks { get; set; }  // allowed card networks

        public string PaymentRecordClientAuthenticator { get; set; }


        // new fields for online payments: if set, the mobile client will inform user and get confirmation before including these in response. If multiple options are available, the user is given option to select (like PayPal)
        public bool IncludePhoneNumberInResponse { get; set; }
        public bool IncludeNameInResponse { get; set; }
        public bool IncludeEmailAddressInResponse { get; set; }
        public bool IncludeBillingAddressInResponse { get; set; }
        public bool IncludeShippingAddressInResponse { get; set; }
        public bool IsViaTerminal { get; set; }

        // new field for scheduled or future payments!
        public bool AllowFuturePayments { get; set; }
    }
}
