using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public Rigidbody2D rb;
	public GameObject player;
	public float speed;
	public Weapon weaponOnHand;

	private bool entered;
	private float lastAttacked = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public void FixedUpdate()
	{
		rb.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));
		if (entered)
		{
			lastAttacked += Time.deltaTime;
			if (lastAttacked >= 1)
			{
				attack();
				lastAttacked = 0;
			}
		}
		else if (weaponOnHand.type == WeaponType.RANGED)
		{
			lastAttacked += Time.deltaTime;
			if (lastAttacked >= 1)
			{
				attack();
				lastAttacked = 0;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == player)
		{
			entered = true;
		}
	}

	private void attack()
	{
		if (weaponOnHand.type == WeaponType.MELEE)
		{
			player.GetComponent<PlayerController>().hit(weaponOnHand.damage);
			Debug.Log(player.GetComponent<PlayerController>().hp);
		}
		else if (weaponOnHand.type == WeaponType.RANGED)
		{
			GameObject projectileShot = Instantiate(weaponOnHand.projectile, this.transform.position, new Quaternion());
			Vector2 projectileDirection = player.transform.position - this.transform.position;
			projectileDirection.Normalize();
			projectileShot.GetComponent<Rigidbody2D>().AddForce(projectileDirection * weaponOnHand.projectileSpeed);
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject == player)
		{
			entered = false;
		}
	}
}
