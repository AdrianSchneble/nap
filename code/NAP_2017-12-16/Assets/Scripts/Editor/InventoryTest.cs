using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class InventoryTest
{

	[Test]
	public void InventoryIsEmptyUponCreation()
	{
		GameObject go = new GameObject();
		go.AddComponent<InventoryController>();
		InventoryController inventoryController = go.GetComponent<InventoryController>();
		Assert.That(inventoryController.GetInventoryContents().Count == 0);
	}

	[Test]
	public void AddingAnItemCreatesEntryInInventory()
	{
		GameObject go = new GameObject();
		go.AddComponent<InventoryController>();
		InventoryController inventoryController = go.GetComponent<InventoryController>();
		ItemKey key = go.AddComponent<ItemKey>();
		inventoryController.AddItemToInventory(key);
		Assert.That(inventoryController.GetInventoryContents().Count == 1);
	}

	[Test]
	public void AddingAnAlreadyExistingItemIncreasesAmount()
	{
		GameObject go = new GameObject();
		go.AddComponent<InventoryController>();
		InventoryController inventoryController = go.GetComponent<InventoryController>();
		ItemKey keyA = go.AddComponent<ItemKey>();
		ItemKey keyB = go.AddComponent<ItemKey>();
		inventoryController.AddItemToInventory(keyA);
		inventoryController.AddItemToInventory(keyB);
		Assert.That(inventoryController.GetInventoryContents().Count == 1);
		Assert.That(inventoryController.GetInventoryContents()[0].amount == 2);
	}

	[Test]
	public void RemovingAnItemRemovesEntryFromInventory()
	{
		GameObject go = new GameObject();
		go.AddComponent<InventoryController>();
		InventoryController inventoryController = go.GetComponent<InventoryController>();
		ItemKey key = go.AddComponent<ItemKey>();
		inventoryController.AddItemToInventory(key);
		inventoryController.RemoveItemFromInventory(typeof(ItemKey));
		Assert.That(inventoryController.GetInventoryContents().Count == 0);
	}

	[Test]
	public void RemovingAnItemWithMultiplesDecresesAmountByOne()
	{
		GameObject go = new GameObject();
		go.AddComponent<InventoryController>();
		InventoryController inventoryController = go.GetComponent<InventoryController>();
		ItemKey keyA = go.AddComponent<ItemKey>();
		ItemKey keyB = go.AddComponent<ItemKey>();
		inventoryController.AddItemToInventory(keyA);
		inventoryController.AddItemToInventory(keyB);
		inventoryController.RemoveItemFromInventory(typeof(ItemKey));
		Assert.That(inventoryController.GetInventoryContents().Count == 1);
		Assert.That(inventoryController.GetInventoryContents()[0].amount == 1);
	}
}
