using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 10;
    public float gravity = 10;
    public float maxVelocityChange = 10;
    public string Name;
    public int Attack;
    public float AttackSpeed;
    public int health;
    public float JumpHeight = 2;
    public int Points = 0;


    private bool dead;
    private bool grounded;
    private Transform PlayerTransform;
    private Rigidbody _rigidbody;
    private GameObject Enemy;
	// Use this for initialization
	void Start () {
        PlayerTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.freezeRotation = true;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PlayerTransform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        Vector3 targetVelocity = new Vector3(0, 0, Input.GetAxis("Vertical"));
        targetVelocity = PlayerTransform.TransformDirection(targetVelocity);
        targetVelocity = targetVelocity * speed;

        Vector3 velocity = _rigidbody.velocity;
        Vector3 velocityChange = targetVelocity - velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        print(_rigidbody.velocity);
        if (Input.GetButton("Jump") && grounded == true)
        {
            _rigidbody.velocity = new Vector3(velocity.x, CalculateJump(), velocity.z);
        }

        _rigidbody.AddForce(new Vector3(0, -gravity * _rigidbody.mass, 0));

        grounded = false;



        
    }

    void Update() {
        if (health < 1) {
            Application.LoadLevel("Taso");

        }


    }



    float CalculateJump() {
        float Jump = Mathf.Sqrt(2 * JumpHeight * gravity);
        return Jump;
    }

    void OnCollisionStay() {

        grounded = true;
    }
    void OnTriggerEnter(Collider Coin) {
        if(Coin.tag == "Acoin") {
            Points = Points + 1;
            Destroy(Coin.gameObject);

        }


    }





}
