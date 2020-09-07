using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    #region Fields
	[Header("Eneable/Disable")]
	[SerializeField]
    private Color colorOn;
    [SerializeField]
    private Color colorObjectOff;
    [SerializeField]
    private Color colorTextOff;

    [Header("Music")]
    [SerializeField]
    private Text textMusic;
    [SerializeField]
    private Image imageMusic;

    [Header("Sounds")]
    [SerializeField]
    private Text textSounds;
    [SerializeField]
    private Image imageSounds;

    [Header("Languaje")]
    [SerializeField]
    private Text textLanguaje;

    private AudioSource audioMusic;
    private AudioSource audioSpeakers;
    #endregion

    #region Public Methods
    public void Music()
    {
        ConfigurationUtils.Music = !ConfigurationUtils.Music;
        audioMusic.enabled = ConfigurationUtils.Music; 
        Activate(ConfigurationUtils.Music, textMusic, imageMusic);        
    }

    public void Sounds()
    {
        ConfigurationUtils.Sounds = !ConfigurationUtils.Sounds;
        audioSpeakers.enabled = ConfigurationUtils.Sounds;
        Activate(ConfigurationUtils.Sounds, textSounds, imageSounds);
    }

    public void Languaje()
    {
        int iLanguage = (int)ConfigurationUtils.Language;
        iLanguage = (ConfigurationUtils.Language == LanguageName.Spanish) ? 0 : iLanguage + 1;
        LanguageName language = (LanguageName)iLanguage;

        LanguageManager.instance.LoadLocalizedtext(language);
        ConfigurationUtils.Language = language;
        PlayerPrefs.SetString("Language", language.ToString());

        MenuManager.GoToMenu(MenuName.SettingsMenu);
    }

    public void Back()
    {
        PlayerPrefs.Save(); //OJO
        MenuManager.GoToMenu(MenuName.HomeMenu);
    }
    #endregion

    #region Private Methods
    private void Awake()
    {
        LanguageName language = ConfigurationUtils.Language;
        Activate(ConfigurationUtils.Music, textMusic, imageMusic);
        Activate(ConfigurationUtils.Sounds, textSounds, imageSounds);

        audioMusic = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        audioSpeakers = GameObject.FindGameObjectWithTag("Speakers").GetComponent<AudioSource>();
    }


    private void Activate(bool enabled, Text text, Image image)
    {
        if (enabled)
        {
            image.color = colorOn;
            text.color = colorOn;
        }
        else
        {
            image.color = colorObjectOff;
            text.color = colorTextOff;
        }
    }
    #endregion
}
