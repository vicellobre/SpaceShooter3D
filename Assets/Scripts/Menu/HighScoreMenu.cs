using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    #region  Fields
    [SerializeField]
    private Text _scoreText;
    #endregion

    #region Private Methods
    private void Start()
    {
        _scoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    #endregion

    #region Public Methods
    public void Back()
    {
        MenuManager.GoToMenu(MenuName.HomeMenu);
    }
    #endregion
}