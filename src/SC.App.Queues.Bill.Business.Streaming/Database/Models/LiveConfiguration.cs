using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class LiveConfiguration
    {
        [Key]
        [Column(Constants.LiveConfiguration.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.LiveConfiguration.Column.LiveId, TypeName = "varchar(36)")]
        public Guid LiveId { get; set; }

        [Column(Constants.LiveConfiguration.Column.AutoCancelBillEnabled)]
        public bool AutoCancelBillEnabled { get; set; }

        [Column(Constants.LiveConfiguration.Column.AutoCancelBillTime, TypeName = "datetime")]
        public DateTime? AutoCancelBillTime { get; set; }

        #region Relationships

        public virtual Live Live { get; set; }

        #endregion
    }
}