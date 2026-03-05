using System.ComponentModel.DataAnnotations;

namespace Users.DTOs
{
    /// <summary>
    /// Represents a user data transfer object
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user
        /// </summary>
        public string Email { get; set; }
    }
}
