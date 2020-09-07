using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    #region Fields
    public static LanguageManager instance;
    private readonly string missingTextString = "Localized text not found";
    private string path = "Language/";
    private Dictionary<string, string> localizedText = new Dictionary<string, string>();
    private Dictionary<LanguageName, string> languages = new Dictionary<LanguageName, string>();
    private bool isReady = false;
    #endregion


    #region Properties
    public  Dictionary<LanguageName, string> Languages => languages;
    public bool IsReady => isReady;
    //public LanguageManager Instance => instance;
    #endregion


    #region Methods Privates

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {
        if (isReady) return;

        string fileName = "Languages";
        string filePath = path + fileName;
        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

        if (jsonFile != null)
        {
            //string dataAsJson = File.ReadAllText(filePath);
            FileLanguages languageData = JsonUtility.FromJson<FileLanguages>(jsonFile.text);

            for (int i = 0; i < languageData.items.Length; i++)
            {
                //Debug.LogFormat("key: {0} - value: {1}", (LanguageName)i, languageData.items[i].value);
                languages.Add((LanguageName)i, languageData.items[i].value);
            }

            Debug.Log($"Data loaded, dictionary contains {languages.Count} entries");
        }
        else
        {
            Debug.Log("cannot find file!");
        }
    }

    public void LoadLocalizedtext(LanguageName languageName)
    {   // Buscar el VALUE de languajeName en el diccionario
        string fileName = languages[languageName];
        string filePath = path + fileName;
        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

        // Verifica si exite la direccion
        if (jsonFile != null)
        {   // Lee todo el JSON
            //string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(jsonFile.text);
           
            for (int i = 0; i < loadedData.items.Length; i++)
            {
                //Debug.LogFormat("key: {0} - value: {1}", loadedData.items[i].key, loadedData.items[i].value);
                if (isReady)
                {
                    localizedText[loadedData.items[i].key] = loadedData.items[i].value; 
                } else
                {
                    localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
                }
            }

            Debug.Log($"Data loaded, dictionary contains {localizedText.Count} entries");
        } else
        {
            Debug.Log("cannot find file!");
        }

        isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }
    #endregion
}
