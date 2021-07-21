using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameBalance",menuName = "GameBalance", order = 1)]
public class GameBalance : ScriptableObject
{
    [Header("Elements")]
    public int numOfElements;
    public int addingElementsNum;
    
    [Header("Time")]
    public float time;
    public float subtractionTimeNum;
    
    [Header("Scores")]
    public float scoresToAdd;

    private static GameBalance _instance;

    public static GameBalance Instance
    {
        get
        {
            if (_instance == null)
            {
                GameBalance[] assets = Resources.LoadAll<GameBalance>("");
                
                if (assets == null || assets.Length < 1)
                    throw new Exception("Could not find GameBalance");
                else if(assets.Length > 1)
                    Debug.LogWarning("There is more GameBalance assets than 1");
                
                _instance = assets[0];

            }
            
            return _instance;
        }
    }

    
}
