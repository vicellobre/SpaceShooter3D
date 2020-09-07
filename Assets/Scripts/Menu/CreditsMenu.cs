using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    #region Public Methods
    public void Back()
    {
        MenuManager.GoToMenu(MenuName.HomeMenu);
    }

    public void Red(string url)
    {
        Application.OpenURL(url);
    }
    #endregion
}
