using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3(target.transform.position.x + 20, target.transform.position.y + 15, target.transform.position.z);
	}
}
