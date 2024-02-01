using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRegistration : MonoBehaviour
{
    
    void Start()
    {
        TextMeshProUGUI textForRegistration = GetComponent<TextMeshProUGUI>();
        EndGameManager.Instance.RegisterScoreText(textForRegistration);
        textForRegistration.text = "Score: 0";
    }

    
}
