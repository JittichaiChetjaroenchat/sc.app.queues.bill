using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Setting.Database.Models
{
    public class Preferences
    {
        [Key]
        [Column(Constants.Preferences.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Preferences.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [Column(Constants.Preferences.Column.IsComplete)]
        public bool IsComplete { get; set; }

        [Column(Constants.Preferences.Column.StatusId, TypeName = "varchar(36)")]
        public Guid StatusId { get; set; }

        [Column(Constants.Preferences.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.Preferences.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.Preferences.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.Preferences.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [Required]
        [MaxLength(2)]
        [Column(Constants.Preferences.Column.Language, TypeName = "varchar(2)")]
        public string Language { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(Constants.Preferences.Column.Currency, TypeName = "varchar(3)")]
        public string Currency { get; set; }

        #region Relationships

        public virtual Status Status { get; set; }

        #endregion
    }
}