/*******************************************************************************************
Copyright © 2019 Xiippy.ai. All rights reserved. Australian patents awarded. PCT patent pending.

NOTES:

- No payment gateway SDK function is consumed directly. Interfaces are defined out of such interactions and then the interface is implemented for payment gateways. Design the interface with the most common members and data structures between different gateways. 
A proper factory or provider must instantiate an instance of the interface that is interacted with.
- Any major change made to SDKs should begin with the c# SDK with the mindset to keep the high-level syntax, structures and class names the same to minimise porting efforts to other languages. Do not use language specific features that don't exist in other languages. We are not in the business of doing the same thing from scratch multiple times in different forms.
- Pascal Case for naming conventions should be used for all languages
- No secret or passwords or keys must exist in the code when checked in

*******************************************************************************************/
//using SQLite;
using System.Collections.Generic;

namespace Xiippy.POSeComSDK.Light.Models
{

    public class ElectronicPaymentPersisted
    {

        public long ElectronicPaymentID { get; set; }

        public string RandomStatementID { get; set; }


        public string Bank { get; set; } = "";



        public string MerchantAccountOwnerDetail { get; set; } = "";



        public string Terminal { get; set; } = "";



        public string Reference { get; set; } = "";



        public string CardNO { get; set; } = "";



        public string AccountType { get; set; } = "";



        public string CardExpiry { get; set; } = "";



        public string Aid { get; set; } = "";



        public string Atc { get; set; } = "";



        public string Tvr { get; set; } = "";



        public string Csn { get; set; } = "";



        public string AuthNo { get; set; } = "";



        public string PosRefNo { get; set; } = "";



        public string MAccountNumber { get; set; } = "";



        public string Mrrn { get; set; } = "";



        public string Mauth { get; set; } = "";



        public string PaymentType { get; set; } = "";



        public string MLocationCode { get; set; } = "";



        public string MAccountType { get; set; } = "";



        public string Apsn { get; set; } = "";



        public string Arqc { get; set; } = "";



        public string CurrencyCode { get; set; } = "";



        public string ExtraInfo1 { get; set; } = "";



        public string ExtraInfo2 { get; set; } = "";



        public string ExtraInfo3 { get; set; } = "";



        public string ExtraInfo4 { get; set; } = "";



        public string ExtraInfo5 { get; set; } = "";



        public string ExtraInfo6 { get; set; } = "";



        public string ExtraInfo7 { get; set; } = "";



        public string ExtraInfo8 { get; set; } = "";



        public string ExtraInfo9 { get; set; } = "";



        public string ExtraInfo10 { get; set; } = "";


        public float Purchase { get; set; }


        public float Total { get; set; }



        public string TransactionType { get; set; } = "";



        public string StatusId { get; set; } = "";



        public string TxnStatusId { get; set; } = "";



        public string Complete { get; set; } = "";



        public string StatementText { get; set; } = "";


        public bool ApprovedFlag { get; set; }



        public string ExpectedSettlementDate { get; set; } = "";



        public string ExpectedSettlementDateTimeZone { get; set; } = "";



        public string DateOfTransaction { get; set; } = "";



        public string DateOfTransactionTimeZone { get; set; } = "";


        public string Stan { get; set; } = "";



        public string DpsBillingId { get; set; } = "";



        public string ResponseCode { get; set; } = "";



        public string ResponseText { get; set; } = "";


        public float AmtSurcgarge { get; set; }


        public float AmtTip { get; set; }


        public float AmtCashOut { get; set; }



        public string CardType { get; set; } = "";


        public Dictionary<string, string> MetaDataExtras { get; set; }
        public string Tsi { get; set; }
        public string DedicatedFileName { get; set; }
        public string Cvm { get; set; }
        public string AuthorizationCode { get; set; }
        public string ApplicationPreferredName { get; set; }
    }
}
