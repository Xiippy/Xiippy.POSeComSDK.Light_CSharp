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
using System;

namespace Xiippy.POSeComSDK.Light.Models
{


    public class StatementItem

    {


        //public string StatementItemID { get; set; }
        public int StatementItemID { get; set; }


        //[Indexed] // foreign key from IssuerStatementRecordPersisted
        public string RandomStatementID { get; set; }

        public string Description { get; set; } = "";



        public string Identifier { get; set; } = "";



        public string Url { get; set; } = "";


        public float Quantity { get; set; }


        public float UnitPrice { get; set; }


        public float TotalPrice { get; set; }


        public float Tax { get; set; }



        public string ExtraInfo1 { get; set; } = "";



        public string ExtraInfo2 { get; set; } = "";



        public string ExtraInfo3 { get; set; } = "";



        public string ExtraInfo4 { get; set; } = "";



        public string ExtraInfo6 { get; set; } = "";



        public string ExtraInfo5 { get; set; } = "";



        public string UnitTitle { get; set; } = "";


        public float UnitLoyaltyPoint { get; set; }


        public float LoyaltyPoint { get; set; }



        public string ItemClsassification { get; set; } = "";



        public string ItemCategoryID { get; set; } = "";



        public string ItemCategoryTitle { get; set; } = "";









        /// <summary>
        /// Defines what moment this item has been added to the bill. Combined with a charge's OnlyAppliesOnceWithinMinutes, the engine can determine if a row can be added to a bill or not!
        /// </summary>
        public DateTimeOffset AddedMoment { get; set; }


        public string WarrantyExpiryMomentISO8601 { get; set; }
        public string LoyaltyPointsExpiryMomentISO8601 { get; set; }
    }
}
