using System;
using System.ComponentModel.DataAnnotations;

namespace DataMergeEditor_Restfull_API.Models.EntityModels.User
{
    public class Users
    {
        /// <summary>
        /// The user id
        /// </summary>
        [Key]
        public int UserID { get; set; }

        [Required]
        /// <summary>
        /// The username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The date created
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// The date closed
        /// </summary>
        public DateTime Closed { get; set; }

    }
}
