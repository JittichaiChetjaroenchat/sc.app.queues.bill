using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class LiveOption
    {
        [Key]
        [Column(Constants.LiveOption.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.LiveOption.Column.LiveId, TypeName = "varchar(36)")]
        public Guid LiveId { get; set; }

        [Column(Constants.LiveOption.Column.DuplicateOrderProtectionEnabled)]
        public bool DuplicateOrderProtectionEnabled { get; set; }

        [Column(Constants.LiveOption.Column.OfferFromPreviousEnabled)]
        public bool OfferFromPreviousEnabled { get; set; }

        [Column(Constants.LiveOption.Column.AutoNotifyBeforeCancelBillEnabled)]
        public bool AutoNotifyBeforeCancelBillEnabled { get; set; }

        [Column(Constants.LiveOption.Column.AutoNotifyBeforeCancelBillMinute)]
        public int? AutoNotifyBeforeCancelBillMinute { get; set; }

        [Column(Constants.LiveOption.Column.IsAutoNotifyBeforeCancelBillProcessed)]
        public bool IsAutoNotifyBeforeCancelBillProcessed { get; set; }

        [Column(Constants.LiveOption.Column.AutoNotifyBeforeCancelBillProcessedOn, TypeName = "datetime")]
        public DateTime? AutoNotifyBeforeCancelBillProcessedOn { get; set; }

        [Column(Constants.LiveOption.Column.AutoCancelBillEnabled)]
        public bool AutoCancelBillEnabled { get; set; }

        [Column(Constants.LiveOption.Column.AutoCancelBillOn, TypeName = "datetime")]
        public DateTime? AutoCancelBillOn { get; set; }

        [Column(Constants.LiveOption.Column.IsAutoCancelBillProcessed)]
        public bool IsAutoCancelBillProcessed { get; set; }

        [Column(Constants.LiveOption.Column.AutoCancelBillProcessedOn, TypeName = "datetime")]
        public DateTime? AutoCancelBillProcessedOn { get; set; }

        #region Relationships

        public virtual Live Live { get; set; }

        #endregion
    }
}