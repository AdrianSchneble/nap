using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0.1f;
    public int hp = 10;
    public int maxHp = 10;
    public bool slowedDown = false;
    public Rigidbody2D rb2d;
	public Weapon weaponOnHand;
    public GameObject inventory;

	// Use this for initialization
	void Start () {

	}

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

		if (Input.GetKeyDown("space") && weaponOnHand.type == WeaponType.RANGED)
		{
			attack(x, y);
		}

        if (Input.GetKeyDown("tab"))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
        rb2d.MovePosition(rb2d.position + new Vector2(x * speed, y * speed));
    }

	private void attack(float x, float y)
	{
		GameObject projectileShot = Instantiate(weaponOnHand.projectile, this.transform.position, new Quaternion());
		projectileShot.GetComponent<Rigidbody2D>().AddForce(new Vector2(x * weaponOnHand.projectileSpeed, y * weaponOnHand.projectileSpeed));
	}

	public void hit(int damage)
	{
		hp -= damage;
	}
}
