using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int money = 0; 
    public int score = 0; 

    void Awake()
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

    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Argent : " + money);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score : " + score);
    }
}