using System.Text.RegularExpressions;

namespace FieldValidatorAPI;

public delegate bool RequiredValidDel(string fieldVal);
public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
public delegate bool PatternMatchValidDel(string fieldVal, string pattern);

public class CommonFieldValidatorFunctions
{
    private static RequiredValidDel _requiredValidDel = null;
    private static DateValidDel _dateValidDel = null;
    private static PatternMatchValidDel _patternMatchValidDel = null;

    public static RequiredValidDel RequiredFieldValidDel
    {
        get
        {
            if(_requiredValidDel == null)
                _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

            return _requiredValidDel;
        }
    }
    public static DateValidDel DateFieldValidDel
    {
        get
        {
            if(_dateValidDel == null)
                _dateValidDel = new DateValidDel(DateFieldCorrect);

            return _dateValidDel;
        }
    }
    public static PatternMatchValidDel PatternMatchValidDel
    {
        get
        {
            if(_patternMatchValidDel == null)
                _patternMatchValidDel = new PatternMatchValidDel(FieldPatternValid);

            return _patternMatchValidDel;
        }
    }

    private static bool RequiredFieldValid(string fieldVal)
    {
        if(!string.IsNullOrEmpty(fieldVal))
            return true;

        return false;

    }
    private static bool DateFieldCorrect(string dateTime, out DateTime validDateTime)
    {
        if(DateTime.TryParse(dateTime, out validDateTime))
            return validDateTime > DateTime.Now;

        return false;
    }
    private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
    {
        Regex regex = new Regex(regularExpressionPattern);

        if(regex.IsMatch(fieldVal))
            return true;

        return false;

    }
}
