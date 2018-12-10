using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
//	Vector3 pointA = new Vector3(transform.position.x,transform.position.y,transform.position.z);
//	Vector3 pointB = new Vector3 (transform.position.x,transform.position.y,transform.position.z);


	void Update(){
		
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
//		transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));

	}
}
