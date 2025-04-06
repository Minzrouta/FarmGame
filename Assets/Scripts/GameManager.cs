using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int money = 0; 
	public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public GameObject selectedSeedPrefab;
    public Seed selectedSeed;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            selectedSeed = selectedSeedPrefab.GetComponent<Seed>();
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
    }
}