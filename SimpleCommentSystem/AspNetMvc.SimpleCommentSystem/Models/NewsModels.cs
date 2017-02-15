namespace AspNetMvc.SimpleCommentSystem.Models
{
    #region References
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    public class News
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }

        public virtual IList<Comment> Comments { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public News()
        {
            Comments = new List<Comment>();
        }
    }

    public class Comment
    {
        public Guid Id { get; set; }

        public string Topic { get; set; }
        [Required]
        public string Message { get; set; }

        public virtual News News { get; set; }

        [ForeignKey("News")]
        public Guid NewsId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

    }
}