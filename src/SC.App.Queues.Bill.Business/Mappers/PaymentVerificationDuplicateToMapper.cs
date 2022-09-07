using System.Collections.Generic;
using System.Linq;
using SC.App.Queues.Bill.Database.Models;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Mappers
{
    public class PaymentVerificationDuplicateToMapper
    {
        public static string Map(List<BillRecipient> duplicateTos)
        {
            if (duplicateTos.IsEmpty())
            {
                return null;
            }

            var aliasNames = duplicateTos
                .Select(x => x.AliasName)
                .ToArray();

            return string.Join(", ", aliasNames);
        }
    }
}