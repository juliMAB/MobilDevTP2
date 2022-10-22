using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour {

	public float speed;
	private int fromside, direction;
	public GameObject scriptmanager;

	void Start()
	{
		speed = 2;
		if(transform.position.z == 27)
		{
			fromside = 1;
			direction = -1;
		} 
		if(transform.position.z == -27)
		{
			fromside = 1;
			direction = 1;
		}
		if(transform.position.x == 27)
		{
			fromside = 2;
			direction = -1;
		}
		if(transform.position.x == -27)
		{
			fromside = 2;
			direction = 1;
		}
	}
	void Update()
	{
		transform.Rotate(new Vector3(1, 1, -1));
		if(fromside == 2) transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + direction, 11, transform.position.z), speed * Time.deltaTime);
		if(fromside == 1) transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 11, transform.position.z + direction), speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == "check") Destroy(this.gameObject);
	}
}
