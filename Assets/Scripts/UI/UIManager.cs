using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument uiDocument; 
    private Button tomatoButton;

    void Start()
    {
        var root = uiDocument.rootVisualElement;
        myButton = root.Q<Button>("Shop_tomato_seed_button");
        myButton.clicked += OnButtonClick;
    }

    void OnButtonClick()
    {
        Debug.Log("Bouton cliqué !");
    }
}