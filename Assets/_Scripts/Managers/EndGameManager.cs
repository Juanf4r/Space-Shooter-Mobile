using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager Instance;

    private PanelController _panelController;
    public bool gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartResolveFunction()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }

    public IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();
    }

    public void ResolveGame()
    {
        if(gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        _panelController.ActivateWin();
    }

    public void LoseGame()
    {
        _panelController.ActivateLose();
    }

    public void RegisterPanelController(PanelController pC)
    {
        _panelController = pC;
    }
}
