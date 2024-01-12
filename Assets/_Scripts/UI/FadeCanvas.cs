using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas Instance;

    [SerializeField] private CanvasGroup _cGroup;
    [SerializeField] private float changevalue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOutString(levelName));
    }

    public void FaderLoadInt(int levelIndex)
    {
        StartCoroutine(FadeOutInt(levelIndex));
    }

    private IEnumerator FadeIn()
    {
        fadeStarted = false;

        while(_cGroup.alpha > 0)
        {
            _cGroup.alpha -= changevalue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator FadeOutString(string levelName)
    {
        if (fadeStarted)
            yield break;

        fadeStarted = true;

        while (_cGroup.alpha < 1)
        {
            _cGroup.alpha += changevalue;
            yield return new WaitForSeconds(waitTime);
        }
        SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOutInt(int levelIndex)
    {
        if (fadeStarted)
            yield break;

        fadeStarted = true;

        while (_cGroup.alpha < 1)
        {
            _cGroup.alpha += changevalue;
            yield return new WaitForSeconds(waitTime);
        }
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeIn());
    }
}
