using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument uiDocument; 
    private Button _tomatoButton;
    private Label _moneyLabel;
    private Label _inventoryLabel;

    void Awake()
    {
        var root = uiDocument.rootVisualElement;
        _tomatoButton = root.Q<Button>("Shop_tomato_seed_button");
        _tomatoButton.clicked += OnTomatoButtonClick;
		_moneyLabel = root.Q<Label>("Money");
        _inventoryLabel = root.Q<Label>("Inventory");
    }

    void Update()
    {
		_moneyLabel.text = "Money: " + GameManager.Instance.money;
        string oe = "Inventory :\n";
        foreach (var item in GameManager.Instance.inventory)
        {
            oe += item.Key + " x " + item.Value;
        }

        _inventoryLabel.text = oe;
    }

    void OnTomatoButtonClick()
    {
		if (GameManager.Instance.money >= 10)
		{
            GameManager.Instance.AddToInventory("Tomato Seed", 1);
            GameManager.Instance.AddMoney(-10);
        }
        else
        {
            Debug.Log("Pas assez d'argent !");
        }
    }
}