using Microsoft.AspNetCore.Identity;

namespace quickhireup_api.Application.Services;

public class PolishIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError PasswordRequiresUpper() => new IdentityError
    {
        Code = nameof(PasswordRequiresUpper),
        Description = "Hasło musi zawierać co najmniej jedną wielką literę ('A'-'Z')."
    };

    public override IdentityError InvalidEmail(string email) => new IdentityError
    {
        Code = nameof(InvalidEmail),
        Description = $"Email '{email}' jest nieprawidłowy."
    };

    public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError
    {
        Code = nameof(PasswordRequiresNonAlphanumeric),
        Description = "Hasło musi zawierać co najmniej jeden znak niealfanumeryczny."
    };

    public override IdentityError DuplicateUserName(string userName) => new IdentityError
    {
        Code = nameof(DuplicateUserName),
        Description = $"Nazwa użytkownika '{userName}' jest już zajęta."
    };

    public override IdentityError PasswordMismatch() => new IdentityError
    {
        Code = nameof(PasswordMismatch),
        Description = "Niepoprawne hasło."
    };

    public override IdentityError UserAlreadyInRole(string role) => new IdentityError
    {
        Code = nameof(UserAlreadyInRole),
        Description = $"Użytkownik jest już w roli '{role}'."
    };

    public override IdentityError PasswordRequiresLower() => new IdentityError
    {
        Code = nameof(PasswordRequiresLower),
        Description = "Hasło musi zawierać co najmniej jedną małą literę ('a'-'z')."
    };

    public override IdentityError RecoveryCodeRedemptionFailed() => new IdentityError
    {
        Code = nameof(RecoveryCodeRedemptionFailed),
        Description = "Nie udało się użyć kodu odzyskiwania."
    };

    public override IdentityError DuplicateRoleName(string role) => new IdentityError
    {
        Code = nameof(DuplicateRoleName),
        Description = $"Rola '{role}' już istnieje."
    };

    public override IdentityError UserNotInRole(string role) => new IdentityError
    {
        Code = nameof(UserNotInRole),
        Description = $"Użytkownik nie jest w roli '{role}'."
    };

    public override IdentityError PasswordTooShort(int length) => new IdentityError
    {
        Code = nameof(PasswordTooShort),
        Description = $"Hasło musi mieć co najmniej {length} znaków."
    };

    public override IdentityError InvalidUserName(string userName) => new IdentityError
    {
        Code = nameof(InvalidUserName),
        Description = $"Nazwa użytkownika '{userName}' jest nieprawidłowa."
    };

    public override IdentityError UserLockoutNotEnabled() => new IdentityError
    {
        Code = nameof(UserLockoutNotEnabled),
        Description = "Blokada użytkownika nie jest włączona."
    };

    public override IdentityError LoginAlreadyAssociated() => new IdentityError
    {
        Code = nameof(LoginAlreadyAssociated),
        Description = "To konto jest już powiązane z tym logowaniem."
    };

    public override IdentityError UserAlreadyHasPassword() => new IdentityError
    {
        Code = nameof(UserAlreadyHasPassword),
        Description = "Użytkownik już posiada ustawione hasło."
    };

    public override IdentityError DefaultError() => new IdentityError
    {
        Code = nameof(DefaultError),
        Description = "Wystąpił nieznany błąd."
    };

    public override IdentityError PasswordRequiresDigit() => new IdentityError
    {
        Code = nameof(PasswordRequiresDigit),
        Description = "Hasło musi zawierać co najmniej jedną cyfrę ('0'-'9')."
    };

    public override IdentityError InvalidRoleName(string role) => new IdentityError
    {
        Code = nameof(InvalidRoleName),
        Description = $"Nazwa roli '{role}' jest nieprawidłowa."
    };

    public override IdentityError ConcurrencyFailure() => new IdentityError
    {
        Code = nameof(ConcurrencyFailure),
        Description = "Błąd współbieżności, spróbuj ponownie."
    };

    public override IdentityError InvalidToken() => new IdentityError
    {
        Code = nameof(InvalidToken),
        Description = "Niepoprawny token."
    };
}