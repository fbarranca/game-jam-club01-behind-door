using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    void Start()
    {
        if (resultText != null)
        {
            resultText.text = $"Thank you for playing!\n" +
                $"Score: {ScoreController.GetScore()}";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
