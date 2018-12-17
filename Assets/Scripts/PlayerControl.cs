using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private int count;
	public float jumpForce;
	public Text countText;
	public Text wintext;
	public float disToGround = 0.5f;
	Vector3 Startpos;
	void Start (){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		//SetCountText();
		wintext.text = "";
		Startpos = transform.position;
	}

	void FixedUpdate(){

		//Debug.Log (isGrounded());
		if (transform.position.y < -10) {
			transform.position = Startpos + new Vector3 (0, 10, 0);
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		}

		if (Input.GetKey(KeyCode.Space)&& isGrounded()) {
			rb.AddForce (0,jumpForce, 0);
		}



		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
		}
	}
	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			wintext.text = "You Win";
		}
	}
	bool isGrounded(){
		return Physics.Raycast (transform.position, Vector3.down, disToGround);

	
	}
}

