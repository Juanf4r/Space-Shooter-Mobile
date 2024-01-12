using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string levelName)
    {
        FadeCanvas.Instance.FaderLoadString(levelName);
    }

    public void LoadLevelInt(int levelIndex)
    {
        FadeCanvas.Instance.FaderLoadInt(levelIndex);
    }

    public void RestartLevel()
    {
        FadeCanvas.Instance.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);
    }
}
