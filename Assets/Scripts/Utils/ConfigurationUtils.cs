//using System.Security.Policy;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    private static bool _MUSIC = true;
    private static bool _SOUNDS = true;
    private static bool _GAME_OVER = false;
    private static LanguageName _LANGUAGE;
    private const LanguageName _LANGUAGE_DEFAULT = LanguageName.English;

    #region Properties
    public static bool Music { get => _MUSIC; set => _MUSIC = value; }
    public static bool Sounds { get => _SOUNDS; set => _SOUNDS = value; }
    public static bool GameOver { get => _GAME_OVER; set => _GAME_OVER = value; }
    public static LanguageName Language { get => _LANGUAGE; set => _LANGUAGE = value; }

    #endregion Properties

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        string field = PlayerPrefs.GetString("Language", _LANGUAGE_DEFAULT.ToString());
        _LANGUAGE = (LanguageName)System.Enum.Parse(typeof(LanguageName), field);
        
        LanguageManager.instance.LoadLocalizedtext(_LANGUAGE);
    }
}
