using Microsoft.AspNetCore.Mvc;
using Users.DTOs;

namespace Users.Controllers
{
    /// <summary>
    /// Controller for managing user operations
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Retrieves all users
        /// </summary>
        /// <returns>A list of all users</returns>
        /// <response code="200">Returns the list of users</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            // Logic to retrieve users
            return Ok();
        }

        /// <summary>
        /// Retrieves a specific user by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the user</param>
        /// <returns>The user with the specified ID</returns>
        /// <response code="200">Returns the requested user</response>
        /// <response code="404">If the user is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserById(int id)
        {
            // Logic to retrieve a user by ID
            return Ok();
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The user data to create</param>
        /// <returns>The newly created user</returns>
        /// <response code="201">Returns the newly created user</response>
        /// <response code="400">If the user data is invalid</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            // Logic to create a new user
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="id">The unique identifier of the user to update</param>
        /// <param name="user">The updated user data</param>
        /// <returns>No content</returns>
        /// <response code="204">If the user was successfully updated</response>
        /// <response code="400">If the user data is invalid</response>
        /// <response code="404">If the user is not found</response>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO user)
        {
            // Logic to update an existing user
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific user
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete</param>
        /// <returns>No content</returns>
        /// <response code="204">If the user was successfully deleted</response>
        /// <response code="404">If the user is not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser(int id)
        {
            // Logic to delete a user
            return NoContent();
        }

        /// <summary>
        /// Searches for users by name or email
        /// </summary>
        /// <param name="name">Optional name to search for</param>
        /// <param name="email">Optional email to search for</param>
        /// <returns>A list of users matching the search criteria</returns>
        /// <response code="200">Returns the list of matching users</response>
        /// <response code="400">If the search parameters are invalid</response>
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SearchUsers([FromQuery] string? name, [FromQuery] string? email)
        {
            // Logic to search users by name or email
            return Ok();
        }
    }
}
