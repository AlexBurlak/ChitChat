using System.ComponentModel.DataAnnotations;

namespace ChitChat.API.Models.Requests;

public class RegisterRequest
{
    [Required]
    public string Login { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string PasswordConfirm { get; set; }
}