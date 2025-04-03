using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int money = 0; // Argent du joueur
    public int score = 0; // Score du joueur

    void Awake()
    {
        // S'assurer qu'il n'y ait qu'un seul GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Garde ce GameObject actif entre les scènes
        }
        else
        {
            Destroy(gameObject); // Détruit les doublons
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