using UnityEngine;
using System.Collections;

public class MouseWheelZoom : MonoBehaviour {

	private float maxHeight = 2f; //How high can you get
	private float minHeight = -20f; // How low can you get

	void LateUpdate ()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && transform.localPosition.y > minHeight) //Scroll up - zoom in with boundaries
		{ 
			GetComponent<Transform> ().position = new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z + 0);
            transform.Rotate(-.5f, 0, 0);
		} else {
			//doesn't do nothin
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && transform.localPosition.y < maxHeight) //Scroll down - zoom out with boundaries
		{ 
			GetComponent<Transform> ().position = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z - 0);
            transform.Rotate(.5f, 0, 0);
		} else 
		{
			//doesn't do nothin
		}
	}
}