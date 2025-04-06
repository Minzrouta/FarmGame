using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument uiDocument; 
    private Button _tomatoButton;
	private Label _moneyLabel;

    void Awake()
    {
        var root = uiDocument.rootVisualElement;
        _tomatoButton = root.Q<Button>("Shop_tomato_seed_button");
        _tomatoButton.clicked += OnTomatoButtonClick;
		_moneyLabel = root.Q<Label>("Money");
    }

    void Update()
    {
		_moneyLabel.text = "Money: " + GameManager.Instance.money;
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