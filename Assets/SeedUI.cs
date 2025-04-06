using UnityEngine;

public class SeedUI : MonoBehaviour
{
    void LateUpdate() {
        transform.forward = Camera.main.transform.forward; // Toujours face caméra
    }

}
