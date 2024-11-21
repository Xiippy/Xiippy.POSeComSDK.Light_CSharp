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
    public class IssuerStatementRecord
    {

        public string RandomStatementID { get; set; }

        // optional nullable foreign key 
        /*         public long? PaymentProcessingRequestID { get; set; }
          public PaymentProcessingRequestPersisted PaymentProcessingRequest { get; set; }
         public PaymentNameAddressResponsePersisted PaymentNameAddressResponse { get; set; }

         public List<InitiatePaymentResponsePersisted> InitiatePaymentResponses { get; set; }
         public Shift? Sift { get; set; }*/


        public List<StatementItem> StatementItems { get; set; }
        public List<ElectronicPaymentPersisted> ElectronicPayments { get; set; }
        public List<CashPaymentPersisted> CashPayments { get; set; }

        public List<TotalBillVariation> TotalBillVariations { get; set; }



        // foreign key to the Shift table
        public string ShiftID { get; set; }





        public string StatementTimeStamp { get; set; } = "";

        #region IssuerStatementRecord


        public Dictionary<string, string> IssuersPrivateMetadata { get; set; }



        /*
                public string IssuerDigitalSingatureKeyId { get; set; }

                public string TransactionMarker { get; set; }  // set when saving the statement from the session state record
                public string RecipientDigitalSignature { get; set; }
                public string StatementTransferRequestSignature { get; set; }

                public string IssuersDigitalSingatureInBase58AsSent { get; set; }

                /// <summary>
                /// The agreed upon encryption key used to encrypt the statement between issuer and recipient, needed for purchase proof validation
                /// </summary>
                public byte[] RecipientDigitalSignatureMACKey { get; set; }

                /// <summary>
                /// The EC key used by the recipient to receive the statement. Needed for purchase proof validation in future while other keys are disposed of.
                /// </summary>
                public byte[] PublicMessageTransferKey { get; set; }

                public string POSMachineID { get; set; }
        */


        #endregion IssuerStatementRecord







        #region Statement


        // should be set internally by SDK when converting this into an internal type

        //public uint ProtocolVersion { get; set; } = 1;


        // public uint StatementRecordVersion { get; set; } = 1;



        public string ShortStatementID { get; set; } = "";





        // should be set internally by SDK when converting this into an internal type
        // public string RetailerCognitoID { get; set; } = "";



        public string StatementCreationDate { get; set; } = "";



        public string StatementText { get; set; } = "";



        public string Description { get; set; } = "";







        public string PersonResponsible { get; set; } = "";



        public string IssuerLogoUrl { get; set; } = "";



        public string DetailsInHeader { get; set; } = "";


        public float TotalAmount { get; set; }


        public float TotalTaxAmount { get; set; }




        public string DetailsInBodyBeforeItems { get; set; } = "";



        public string DetailsInBodyAfterItems { get; set; } = "";



        public string DetailsInFooter { get; set; } = "";



        public string StatementIdentifier { get; set; } = "";



        public string StatementIdentifier2 { get; set; } = "";



        public string StatementIdentifier3 { get; set; } = "";





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


        public byte[] AttachmentPageTop { get; set; }



        public string AttachmentPageTopMimeType { get; set; } = "";


        public byte[] AttachmentItemsTop { get; set; }



        public string AttachmentItemsTopMimeType { get; set; } = "";


        public byte[] AttachmentItemsBottom { get; set; }



        public string AttachmentItemsBottomMimeType { get; set; } = "";


        public byte[] AttachmentPageBottom { get; set; }



        public string AttachmentPageBottomMimeType { get; set; } = "";


        public float TotalLoyaltyPoints { get; set; }


        public uint PaymentProcessingResult { get; set; }



        public string PaymentProcessingMsg { get; set; } = "";



        public string UniqueStatementID { get; set; } = "";



        public PaymentNameAddressRequest PaymentNameAddressRequestObject { get; set; }




        public string RetailerGroupID { get; set; } = "";









        public Dictionary<string, string> MetaDataExtras { get; set; }




        // new fields
        // should be set internally by SDK when converting this into an internal type

        //public string RetailerID { get; set; }


        /// <summary>
        /// Logical cluster PaymentRecordCustomerAddressID for the issuer/merchant/payee/retailer (e.g. Shopping Centre 1), used to help identify a buyer for a Shopping Center in a privacy-preserving fashion
        /// </summary>
        // should be set internally by SDK when converting this into an internal type

        //public string ClusterID1 { get; set; }
        /// <summary>
        /// Logical cluster ID2 for the issuer/merchant/payee/retailer (e.g. All super markets), used to help identify a buyer for a Shopping Center in a privacy-preserving fashion
        /// </summary>
        // should be set internally by SDK when converting this into an internal type

        //public string ClusterID2 { get; set; }
        /// <summary>
        /// Logical cluster ID3 for the issuer/merchant/payee/retailer (e.g. Shopping Centre 2), used to help identify a buyer for a Shopping Center in a privacy-preserving fashion
        /// </summary>
        // should be set internally by SDK when converting this into an internal type

        //        public string ClusterID3 { get; set; }
        /// <summary>
        /// Logical cluster ID4 for the issuer/merchant/payee/retailer (e.g. Shopping Centre 3), used to help identify a buyer for a Shopping Center in a privacy-preserving fashion
        /// </summary>
        // should be set internally by SDK when converting this into an internal type

        //public string ClusterID4 { get; set; }
        /// <summary>
        /// Logical cluster ID5 for the issuer/merchant/payee/retailer (e.g. Shopping Centre 4), used to help identify a buyer for a Shopping Center in a privacy-preserving fashion
        /// </summary>
        // should be set internally by SDK when converting this into an internal type

        //public string ClusterID5 { get; set; }
        // should be set internally by SDK when converting this into an internal type

        //public int LevelInHierarchy { get; set; }
        // should be set internally by SDK when converting this into an internal type

        //public string RetailerSubgroupID { get; set; } // franchise or chain cognito id


        // should be set internally by SDK when converting this into an internal type

        //public string RetailerCardID { get; set; }  // the retailer's private identifier of the cards    

        // should be set internally by SDK when converting this into an internal type

        //public string RetailerNodeID { get; set; }  // the retailer's private identifier of the cards    


        // should be set internally by SDK when converting this into an internal type

        // public bool IsTest { get; set; }




        #endregion Statement

    }




}
