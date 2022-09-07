using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SC.App.Queues.Bill.Business.Enums;
using SC.App.Queues.Bill.Database.Models;
using SC.App.Queues.Bill.Lib.Extensions;
using SC.Services.Bank.Client;

namespace SC.App.Queues.Bill.Business.Helpers
{
    public class PaymentVerificationHelper
    {
        public static EnumPaymentVerificationStatus Get(VerifySlipStatus status)
        {
            if (status == null || status.Code.IsEmpty())
            {
                return EnumPaymentVerificationStatus.Unknown;
            }

            if (status.Code.Equals(EnumPaymentVerificationStatus.NotVerify.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.NotVerify;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.Unverifiable.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.Unverifiable;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.Duplicate.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.Duplicate;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.IncorrectBankAccountNumber.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.IncorrectBankAccountNumber;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.IncorrectBankAccountName.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.IncorrectBankAccountName;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.IncorrectAmount.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.IncorrectAmount;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.Verified.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.Verified;
            }

            return EnumPaymentVerificationStatus.Unknown;
        }

        public static EnumPaymentVerificationStatus Get(PaymentVerificationStatus status)
        {
            if (status == null || status.Code.IsEmpty())
            {
                return EnumPaymentVerificationStatus.Unknown;
            }

            if (status.Code.Equals(EnumPaymentVerificationStatus.NotVerify.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.NotVerify;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.Unverifiable.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.Unverifiable;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.Duplicate.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.Duplicate;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.IncorrectBankAccountNumber.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.IncorrectBankAccountNumber;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.IncorrectBankAccountName.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.IncorrectBankAccountName;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.IncorrectAmount.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.IncorrectAmount;
            }
            else if (status.Code.Equals(EnumPaymentVerificationStatus.Verified.GetDescription(), StringComparison.OrdinalIgnoreCase))
            {
                return EnumPaymentVerificationStatus.Verified;
            }

            return EnumPaymentVerificationStatus.Unknown;
        }

        public static bool IsProceed(EnumPaymentVerificationStatus status)
        {
            if (status == EnumPaymentVerificationStatus.NotVerify)
            {
                return false;
            }

            return true;
        }

        public static bool CanVerify(EnumPaymentVerificationStatus status)
        {
            if (status == EnumPaymentVerificationStatus.NotVerify)
            {
                return false;
            }

            return status != EnumPaymentVerificationStatus.Unverifiable;
        }

        public static bool IsUnique(EnumPaymentVerificationStatus status)
        {
            if (status == EnumPaymentVerificationStatus.NotVerify)
            {
                return false;
            }

            return status != EnumPaymentVerificationStatus.Duplicate;
        }

        public static bool IsCorrectBankAccountNumber(EnumPaymentVerificationStatus status)
        {
            if (status == EnumPaymentVerificationStatus.NotVerify)
            {
                return false;
            }

            return status != EnumPaymentVerificationStatus.IncorrectBankAccountNumber;
        }

        public static bool IsCorrectBankAccountName(EnumPaymentVerificationStatus status)
        {
            if (status == EnumPaymentVerificationStatus.NotVerify)
            {
                return false;
            }

            return status != EnumPaymentVerificationStatus.IncorrectBankAccountName;
        }

        public static bool IsCorrectAmount(EnumPaymentVerificationStatus status)
        {
            if (status == EnumPaymentVerificationStatus.NotVerify)
            {
                return false;
            }

            return status != EnumPaymentVerificationStatus.IncorrectAmount;
        }

        public static string GetRemark(EnumPaymentVerificationStatus status, string extended)
        {
            StringBuilder remark = new StringBuilder();

            switch (status)
            {
                case EnumPaymentVerificationStatus.NotVerify:
                    remark.Append("ไม่ทำการตรวจสอบ");
                    break;
                case EnumPaymentVerificationStatus.Unverifiable:
                    remark.Append("ไม่สามารถตรวจสอบได้");
                    break;
                case EnumPaymentVerificationStatus.Duplicate:
                    remark.Append("มีการใช้งานแล้ว");
                    break;
                case EnumPaymentVerificationStatus.IncorrectBankAccountNumber:
                    remark.Append("หมายเลขบัญชีไม่ถูกต้อง");
                    break;
                case EnumPaymentVerificationStatus.IncorrectBankAccountName:
                    remark.Append("ชื่อบัญชีไม่ถูกต้อง");
                    break;
                case EnumPaymentVerificationStatus.IncorrectAmount:
                    remark.Append("จำนวนเงินไม่ถูกต้อง");
                    break;
                case EnumPaymentVerificationStatus.Verified:
                    remark.Append("หลักฐานถูกต้อง");
                    break;
                default:
                    remark.Append("ไม่สามารถตรวจสอบได้");
                    break;
            }

            if (!extended.IsEmpty())
            {
                remark.AppendFormat(" ({0})", extended);
            }

            return remark.ToString();
        }

        public static List<VerifySlipBankAccount> Convert(ICollection<GetBankResponse> banks, ICollection<Setting.Database.Models.PaymentBankAccount> bankAccounts)
        {
            return bankAccounts
                .Select(bankAccount => Convert(banks, bankAccount))
                .ToList();
        }

        public static VerifySlipBankAccount Convert(ICollection<GetBankResponse> banks, Setting.Database.Models.PaymentBankAccount bankAccount)
        {
            if (bankAccount == null)
            {
                return null;
            }

            var bank = banks
                .FirstOrDefault(x => x.Id == bankAccount.BankId);
            if (bank == null)
            {
                return null;
            }

            return new VerifySlipBankAccount
            {
                Bank = new VerifySlipBank { Code = bank.Code },
                Number = bankAccount.Number,
                Name = bankAccount.Name
            };
        }
    }
}