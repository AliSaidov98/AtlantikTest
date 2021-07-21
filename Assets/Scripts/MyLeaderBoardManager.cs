using CarterGames.Assets.LeaderboardManager;
using UnityEngine;
using UnityEngine.UI;

public class MyLeaderBoardManager : MonoBehaviour
{
    [Header("Example Text Fields")]
    [Tooltip("The text field for the player name input")]
    public Text playerName;
    
    [Header("Display Script Reference")]
    [Tooltip("a reference to the display script on a gameObject in the scene somewhere.")]
    public LeaderboardDisplay displayScript;
    
    
    [Header("GameData Reference")]
    [Tooltip("a reference to the GameData on a gameObject in the scene.")]
    public GameData gameData;

    
    public void AddToLb()
    {
        LeaderboardManager.AddToLeaderboard(playerName.text, gameData.playerScore);
        gameData.leaderBoardPanel.SetActive(true);
        UpdateLbDisplay();
    }

    private void UpdateLbDisplay()
    {
        displayScript.UpdateLeaderboardDisplay();
    }
}
