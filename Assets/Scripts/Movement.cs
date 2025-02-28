﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 moveing = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce(moveing);	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Cube points"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();

		}
	}
	void SetCountText()
	{
		countText.text = "count: " + count.ToString ();
		if (count >=20)
		{
			winText.text = "You Win";
		}
	}
}
