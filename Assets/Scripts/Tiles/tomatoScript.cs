using UnityEngine;

public class TomatoScript : MonoBehaviour
{
	public bool isHarvested = false;

	private void OnMouseDown()
    {
    	Debug.Log("Tomato clicked: " + this.gameObject.name);
        GameManager.Instance.AddMoney(10);
		isHarvested = true;
		
    }
}