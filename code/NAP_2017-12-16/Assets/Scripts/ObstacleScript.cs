using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

	public Rigidbody2D obstacle;
	private GameObject player;
	public float mass;
	public int health;
    public bool isMovable;
    public bool isDestructible;
    public bool canShootThrough;

	private bool entered;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player");
		Debug.Log(player);
		if (isMovable)
		{
			obstacle.mass = mass;
		}
		else
		{
			obstacle.mass = float.MaxValue;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && entered)
		{
			health -= player.GetComponent<PlayerController>().weaponOnHand.damage;
			Debug.Log("Meele; Obstacle Health: " + health);
			if (health <= 0)
			{
				Destroy(obstacle.gameObject);
			}
		}

		obstacle.rotation = 0;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (isDestructible)
		{

			if (player.GetComponent<PlayerController>().weaponOnHand.type == WeaponType.RANGED && collision.gameObject.tag == "Projectile")
			{
				health -= player.GetComponent<PlayerController>().weaponOnHand.damage;
				Debug.Log("Ranged; Obstacle Health: " + health);
				if (health <= 0)
				{
					Destroy(obstacle.gameObject);
				}
			}
			else if (player.GetComponent<PlayerController>().weaponOnHand.type == WeaponType.MELEE)
			{
				entered = true;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (isDestructible)
		{
			entered = false;
		}
	}
}
