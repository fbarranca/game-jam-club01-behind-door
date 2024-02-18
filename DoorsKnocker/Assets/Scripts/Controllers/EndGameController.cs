using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    void Start()
    {
        resultText.text = $"Thank you for playing!\n" +
            $"Score: {ScoreController.GetScore()}";
    }

}
