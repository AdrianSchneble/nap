using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory {

	GameObject enemy;
	
	public static EnemyFactory create()
	{
		return new EnemyFactory();
	}

	public EnemyFactory()
	{
		this.enemy = new GameObject();
		enemy.AddComponent<EnemyScript>();
	}

	public EnemyFactory withSprite(string pathToSprite)
	{
		enemy.AddComponent<SpriteRenderer>();
		enemy.GetComponent<SpriteRenderer>().sprite = Resources.Load(pathToSprite) as Sprite;
		return this;
	}

	public EnemyFactory withSpeed(float speed)
	{
		enemy.GetComponent<EnemyScript>().speed = speed;
		return this;
	}

	public EnemyFactory withWeapon(AbstractWeapon weapon)
	{
		enemy.GetComponent<EnemyScript>().weaponOnHand = weapon;
		return this;
	}

	public EnemyFactory atPosition(Vector2 position)
	{
		enemy.transform.position = position;
		return this;
	}

	public GameObject get()
	{
		return enemy;
	}
}
