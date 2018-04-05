﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour {

	public float speed = .2f;
	public float strength = 9f;

	private float randomOffset;

	
	void Start () {
		randomOffset = Random.Range(0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z = Mathf.Sin(Time.time * speed + randomOffset) * strength;
		transform.position = pos;
	}
}
