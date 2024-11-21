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

namespace Xiippy.POSeComSDK.Light.Models
{
    public class XiippyRefund
    {
        public string XiippyPaymentContextID { get; set; }
        public string XiippyPaymentChargeID { get; set; }

        public string Id { get; set; }
        public string Object { get; set; }
        public long Amount { get; set; }
        public string BalanceTransaction { get; set; }
        public string Charge { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Currency { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string PaymentIntent { get; set; }
        public string Reason { get; set; }
        public string ReceiptNumber { get; set; }
        public string SourceTransferReversal { get; set; }
        public string Status { get; set; }
        public string TransferReversal { get; set; }
    }
}
