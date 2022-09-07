using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class LiveCommentor
    {
        [Key]
        [Column(Constants.LiveCommentor.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.LiveCommentor.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [MaxLength(32)]
        [Column(Constants.LiveCommentor.Column.ClientId, TypeName = "varchar(32)")]
        public string ClientId { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.LiveCommentor.Column.Name, TypeName = "varchar(128)")]
        public string Name { get; set; }

        [MaxLength(1024)]
        [Column(Constants.LiveCommentor.Column.PictureUrl, TypeName = "varchar(1024)")]
        public string PictureUrl { get; set; }

        #region Relationships

        public virtual ICollection<LiveComment> LiveComments { get; set; }

        #endregion
    }
}