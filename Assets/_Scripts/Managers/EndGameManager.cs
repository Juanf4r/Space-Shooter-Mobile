using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager Instance;

    private PanelController _panelController;
    private TextMeshProUGUI _scoreTextComponenet;
    private PlayerStats _player;
    private RewardedAd _rewardAd;

    [HideInInspector] public string LvlUnlock = "LevelUnlock";
    public int _score;
    public bool gameOver;
    public bool possibleWin;

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

    public void UpdateScore(int addScore)
    {
        _score += addScore;
        _scoreTextComponenet.text = "Score: " + _score;
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
        if(possibleWin == true && gameOver == false)
        {
            WinGame();
        }
        else if(possibleWin == false && gameOver == true)
        {
            AdLoseGame();
        }
        else if(possibleWin == true && gameOver == true)
        { 
            LoseGame();
        }
    }

    public void WinGame()
    {
        _player.canTakeDmg = false;

        ScoreSet();
        _panelController.ActivateWin();
        int _nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(_nextLevel > PlayerPrefs.GetInt(LvlUnlock, 0))
        {
            PlayerPrefs.SetInt(LvlUnlock, _nextLevel);
        }
    }

    public void LoseGame()
    {
        ScoreSet();
        _panelController.ActivateLose();
    }

    public void AdLoseGame()
    {
        ScoreSet();
        if(_rewardAd.adNumber > 0 )
        {
            _rewardAd.adNumber -= 1;
            _panelController.ActivateAdLose();
        }
        else
        {
            _panelController.ActivateLose();
        }
    }

    private void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, _score);
        int _highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        if (_score > _highScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, _score);
        }

        _score = 0;
    }    

    public void RegisterPanelController(PanelController pC)
    {
        _panelController = pC;
    }

    public void RegisterScoreText(TextMeshProUGUI scoreTextComp)
    {
        _scoreTextComponenet = scoreTextComp;
    }

    public void RegisterPlayerStats(PlayerStats statsPlayer)
    {
        _player = statsPlayer;
    }

    public void RegisterRewardedAd(RewardedAd ad)
    {
        _rewardAd = ad;
    }
}
