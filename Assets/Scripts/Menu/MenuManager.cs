using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.HomeMenu:
            case MenuName.CreditsMenu:
            case MenuName.SettingsMenu:
            case MenuName.HighScoreMenu:
                SceneManager.LoadScene( name.ToString() );
                break;

            case MenuName.Gameplay:
                //ConfigurationUtils.GameOver = false;
                SceneManager.LoadScene("Gameplay");
                break;

            case MenuName.GameOverMenu:
                Object.Instantiate(
                    Resources.Load("Prefabs/GameOver"),
                    Vector3.zero + GameObject.FindGameObjectWithTag("HUD").transform.position,
                    Quaternion.identity,
                    GameObject.FindGameObjectWithTag("HUD").transform);
                break;

            
        }
    }
}