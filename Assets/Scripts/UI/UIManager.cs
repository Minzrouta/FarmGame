using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument uiDocument; 
    private Button tomatoButton;

    void Start()
    {
        var root = uiDocument.rootVisualElement;
        tomatoButton = root.Q<Button>("Shop_tomato_seed_button");
        tomatoButton.clicked += OnButtonClick;
    }

    void OnButtonClick()
    {
        Debug.Log("Bouton cliqué !");
        GameManager.Instance.AddMoney(-10);
    }
}