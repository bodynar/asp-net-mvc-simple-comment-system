namespace AspNetMvc.SimpleCommentSystem.Models
{
    #region References
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    #endregion

    // add more options to display

    public class NewsAddViewModel
    {
        public string Subject { get; set; }
        public string Text { get; set; }
    }

    public class NewsDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }

        public int CommentsCount { get; set; }

        public virtual ApplicationUser User { get; set; }
    }

    public class CommentAddViewModel
    {
        public string Topic { get; set; }
        public string Message { get; set; }

        public Guid NewsId { get; set; }
    }

    public class CommentDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Topic { get; set; }
        [Required]
        public string Message { get; set; }

        [Required]
        public virtual News News { get; set; }

        public Guid NewsId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}