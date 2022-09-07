using System.ComponentModel;

namespace SC.App.Queues.Bill.Business.Enums
{
    public enum EnumPaymentVerificationStatus
    {
        [Description("unknown")]
        Unknown,

        [Description("not_verify")]
        NotVerify,

        [Description("unverifiable")]
        Unverifiable,

        [Description("duplicate")]
        Duplicate,

        [Description("incorrect_bank_account_number")]
        IncorrectBankAccountNumber,

        [Description("incorrect_bank_account_name")]
        IncorrectBankAccountName,

        [Description("incorrect_amount")]
        IncorrectAmount,

        [Description("verified")]
        Verified
    }
}