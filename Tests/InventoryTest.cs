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

    [Test]
    public void EquipPutsWeaponInPlayersHand()
    {
        GameObject go = new GameObject();
        go.AddComponent<InventoryController>();
        go.AddComponent<PlayerController>();
        InventoryController inventoryController = go.GetComponent<InventoryController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        inventoryController.PlayerController = playerController;
        WeaponLongsword weapon = go.AddComponent<WeaponLongsword>();
        inventoryController.AddItemToInventory(weapon);
        inventoryController.Equip(weapon);
        Assert.IsInstanceOf(typeof(WeaponLongsword), playerController.weaponOnHand);
    }

    [Test]
    public void EquippingRemovesItemFromInventory()
    {
        GameObject go = new GameObject();
        go.AddComponent<InventoryController>();
        go.AddComponent<PlayerController>();
        InventoryController inventoryController = go.GetComponent<InventoryController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        inventoryController.PlayerController = playerController;
        WeaponLongsword weapon = go.AddComponent<WeaponLongsword>();
        inventoryController.AddItemToInventory(weapon);
        inventoryController.Equip(weapon);
        Assert.That(inventoryController.GetInventoryContents().Count == 0);
    }

    [Test]
    public void EqippingOverridesCurrentlyEquippedWeapon()
    {
        GameObject go = new GameObject();
        go.AddComponent<InventoryController>();
        go.AddComponent<PlayerController>();
        InventoryController inventoryController = go.GetComponent<InventoryController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        inventoryController.PlayerController = playerController;
        WeaponLongsword longsword = go.AddComponent<WeaponLongsword>();
        WeaponBattleAxe battleAxe = go.AddComponent<WeaponBattleAxe>();
        inventoryController.AddItemToInventory(longsword);
        inventoryController.AddItemToInventory(battleAxe);
        inventoryController.Equip(longsword);
        inventoryController.Equip(battleAxe);
        Assert.IsInstanceOf(typeof(WeaponBattleAxe), playerController.weaponOnHand);
    }

    [Test]
    public void AutomaticallyUnequippedWeaponIsAddedToInventory()
    {
        GameObject go = new GameObject();
        go.AddComponent<InventoryController>();
        go.AddComponent<PlayerController>();
        InventoryController inventoryController = go.GetComponent<InventoryController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        inventoryController.PlayerController = playerController;
        WeaponLongsword longsword = go.AddComponent<WeaponLongsword>();
        WeaponBattleAxe battleAxe = go.AddComponent<WeaponBattleAxe>();
        inventoryController.AddItemToInventory(longsword);
        inventoryController.AddItemToInventory(battleAxe);
        inventoryController.Equip(longsword);
        inventoryController.Equip(battleAxe);
        Assert.That(inventoryController.GetInventoryContents().Count == 1);
        Assert.IsInstanceOf(typeof(WeaponLongsword), inventoryController.GetInventoryContents()[0].item);
    }

    [Test]
    public void UnequipRemovesWeaponFromPlayer()
    {
        GameObject go = new GameObject();
        go.AddComponent<InventoryController>();
        go.AddComponent<PlayerController>();
        InventoryController inventoryController = go.GetComponent<InventoryController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        inventoryController.PlayerController = playerController;
        WeaponLongsword longsword = go.AddComponent<WeaponLongsword>();
        inventoryController.AddItemToInventory(longsword);
        inventoryController.Equip(longsword);
        inventoryController.Unequip();
        Assert.IsNull(playerController.weaponOnHand);
    }

    [Test]
    public void ManualUnequipReturnWeaponToInventory()
    {
        GameObject go = new GameObject();
        go.AddComponent<InventoryController>();
        go.AddComponent<PlayerController>();
        InventoryController inventoryController = go.GetComponent<InventoryController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        inventoryController.PlayerController = playerController;
        WeaponLongsword longsword = go.AddComponent<WeaponLongsword>();
        inventoryController.AddItemToInventory(longsword);
        inventoryController.Equip(longsword);
        inventoryController.Unequip();
        Assert.That(inventoryController.GetInventoryContents().Count == 1);
    }

    [Test]
    public void UneqipWithoutEquippedWeaponDoesNothing()
    {
        GameObject go = new GameObject();
        go.AddComponent<InventoryController>();
        go.AddComponent<PlayerController>();
        InventoryController inventoryController = go.GetComponent<InventoryController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        inventoryController.PlayerController = playerController;
        inventoryController.Unequip();
        Assert.IsNull(playerController.weaponOnHand);
    }

}
