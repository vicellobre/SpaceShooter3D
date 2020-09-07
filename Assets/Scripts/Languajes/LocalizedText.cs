using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{

    #region Fields
    [SerializeField]
    private string key;

    [SerializeField]
    private Text text;
    #endregion


    #region Private Methods

    private void Start()
    {
        //Text text = GetComponent<Text>();
        text.text = LanguageManager.instance.GetLocalizedValue(key);
    }
    #endregion
}
