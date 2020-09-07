using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
        if (LanguageManager.instance.IsReady) return;
        //EventManager.Initialize();
        LanguageManager.instance.Initialize();
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
    }
}