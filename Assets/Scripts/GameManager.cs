using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int money = 0; 
    public int score = 0; 
	public Dictionary<string, int> inventory = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
			money = 50;
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

    public void AddToInventory(string itemName, int quantity)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName] += quantity;
        }
        else
        {
            inventory[itemName] = quantity;
        }
        Debug.Log("Inventaire : " + itemName + " x" + inventory[itemName]);
    }

	public void RemoveFromInventory(string itemName, int quantity)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName] -= quantity;
            if (inventory[itemName] <= 0)
            {
                inventory.Remove(itemName);
            }
        }
        Debug.Log("Inventaire : " + itemName + " x" + inventory[itemName]);
    }
}