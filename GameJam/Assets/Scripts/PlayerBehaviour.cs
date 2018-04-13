using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

	public Rigidbody2D rb;
	public BoxCollider2D boxC;

	public Sprite sprite;
	public float speed;
	private bool isOnGround;

	public bool isMovingSide;

	// Use this for initialization
	void Start () {
		Setup(new Vector2(0,10));
	}

	void Setup(Vector2 spawn_position){
		rb = this.GetComponent<Rigidbody2D>();
		boxC = this.GetComponent<BoxCollider2D>();
		sprite = this.GetComponent<SpriteRenderer>().sprite;
		isOnGround = false;
		rb.position = spawn_position;
	}
	
	void Update ()
    {
		if(!isOnGround){
        	rb.velocity += new Vector2(0f, -9.81f)*Time.deltaTime;
		}
		KeyPressed();
    }

	void KeyPressed(){

		if(Input.GetButtonDown("Fire2")){
			print("jump");
			if(isOnGround){
				rb.velocity += new Vector2(0f, 7f);
				isOnGround = false;
			}
		}

		if(Input.GetButtonDown("Fire1")){
			Die();
		}

		float horizontal = Input.GetAxisRaw("Horizontal");
		rb.velocity += new Vector2(horizontal*speed*Time.deltaTime,0f);
		if(horizontal == 0 && isOnGround){
			rb.velocity = new Vector2(0f, rb.velocity.y);
		}
	}
	void OnTriggerEnter2D(Collider2D collision){
		print("Collision");
		if(!isOnGround){
			rb.velocity-= new Vector2(0f,rb.velocity.y);
			isOnGround = true;
		}
	}


	void Die(){
		print("YOU LOST");
		Reset();
		
	}

	void Reset(){
		Application.LoadLevel("Game");
	}
}
