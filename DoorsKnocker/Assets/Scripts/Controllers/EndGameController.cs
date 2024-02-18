using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    void Start()
    {
        resultText.text = $"Thank you for playing!\n" +
            $"Score: {ScoreController.GetScore()}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
