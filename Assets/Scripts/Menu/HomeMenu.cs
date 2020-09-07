using UnityEngine;

public class HomeMenu : MonoBehaviour
{
    #region Public Methods
    public void GamePlay()
    {
        MenuManager.GoToMenu(MenuName.Gameplay);
    }

    public void ScoreMenu()
    {
        MenuManager.GoToMenu(MenuName.HighScoreMenu);
    }

    public void SettingsMenu()
    {
        MenuManager.GoToMenu(MenuName.SettingsMenu);
    }

    public void CreditsMenu()
    {
        MenuManager.GoToMenu(MenuName.CreditsMenu);
    }

    public void LoadMenu(MenuName name)
    {
        MenuManager.GoToMenu(name);
    }

    public void Exit()
    {
        Application.Quit();
    }
    #endregion
}
