using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    [SerializeField] private ElementsCreator _elementsCreator;
    [SerializeField] private Text _playerScoreText;
    [SerializeField] private Text _timerText;

    public GameObject saveBoardPanel;
    public GameObject leaderBoardPanel;

    public float playerScore;

    private float _timer;
    private bool _gameOver;
    private bool _win;
    private int _linkedElements;
    
    private int _numOfElements;
    private float _time;
    
    private void Awake()
    {
        _time = GameBalance.Instance.time;
        _numOfElements = GameBalance.Instance.numOfElements;
       
        CreateGame();
    }

    private void ResetTimer()
    {
        _timer = _time;
    }

    private void CreateGame()
    {
        _win = false;
        _elementsCreator.numOfElements = _numOfElements;
        _elementsCreator.CreateElements();
        _linkedElements = 0;
        ResetTimer();
    }

    public void CorrectLink()
    {
        _linkedElements++;
        
        if(_linkedElements != _elementsCreator.rightSide.childCount) return;
        
        Win();
    }
    
    private void AddScore()
    {
        playerScore += GameBalance.Instance.scoresToAdd;
        _playerScoreText.text = "Score: " + playerScore;
    }

    private void Update()
    {
        if(_gameOver || _win) return;
        
        _timer -= Time.deltaTime;
        _timerText.text = "0:" + Mathf.Round(_timer).ToString(CultureInfo.CurrentCulture);
        
        if(_timer > 0) return;
        
        GameOver();
    }
    
    private void Win()
    {
        _win = true;
        Debug.Log("Win");
        
        AddScore();
        
        _numOfElements += GameBalance.Instance.addingElementsNum;
        
        if(_time - GameBalance.Instance.subtractionTimeNum > 2)
            _time -= GameBalance.Instance.subtractionTimeNum;
        
        _elementsCreator.RemoveElements();
        CreateGame();
    }
    
    private void GameOver()
    {
        _gameOver = true;
        saveBoardPanel.SetActive(true);
        Debug.Log("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
