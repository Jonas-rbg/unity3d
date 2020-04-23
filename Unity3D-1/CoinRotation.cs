using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour {
    public float speed = 5;
    public int RandomNumber;
	// Use this for initialization
	void Start () {
        RandomNumber = Random.Range(1, (int)speed);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.up * (RandomNumber * 1.0f));
		
	}
}
