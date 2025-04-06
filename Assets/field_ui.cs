using UnityEngine;
using UnityEngine.UIElements;

public class AttachUIDocument : MonoBehaviour
{
    public UIDocument uiDocument;
    public GameObject targetObject;

    private VisualElement rootElement;

    void Start()
    {
        if (uiDocument != null)
        {
            rootElement = uiDocument.rootVisualElement;
        }
    }

    void Update()
    {
        if (targetObject != null && rootElement != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetObject.transform.position);
            rootElement.style.left = screenPosition.x - rootElement.Q("bg").resolvedStyle.width/2; // Centrer l'élément UI
            rootElement.style.top = Screen.height - screenPosition.y; // Inverser Y car l'origine est en bas à gauche
        }
        
    }
}
