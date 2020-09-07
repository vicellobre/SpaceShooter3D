public enum LanguageName
{
    English,
    Spanish
}

[System.Serializable]
public class FileLanguages
{
    public DataLanguage[] items;
}


[System.Serializable]
public class DataLanguage
{
    public LanguageName key;
    public string value;
}