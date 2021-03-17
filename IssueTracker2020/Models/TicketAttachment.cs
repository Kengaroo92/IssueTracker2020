using IssueTracker2020.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IssueTracker2020.Models

{
    public class TicketAttachment

    {

        public int Id { get; set; }

        [Display(Name = "Select Image")]
        [NotMapped]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".pdf" })]
        public IFormFile FormFile { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public byte[] FileData { get; set; }

        public string ContentType { get; set; }

        public string Description { get; set; }

        public DateTimeOffset Created { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public string UserId { get; set; }

        public virtual BTUser User { get; set; }

    }

}
