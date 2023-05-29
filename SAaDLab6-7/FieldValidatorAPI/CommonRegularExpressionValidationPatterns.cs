namespace FieldValidatorAPI;
public static class CommonRegularExpressionValidationPatterns
{
    public const string Email_Address_RegEx_Pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    public const string UA_PhoneNumber_RegEx_Pattern = @"^+380[\s]?\(?93|63|50|67|98|66\)?[\s]?[\d]{3}[\s]?[\d]{2}[\s]?[\d]{2}$";

    public const string FirstLastName_RegEx_Pattern = @"^[a-zA-Z]+$";
}
