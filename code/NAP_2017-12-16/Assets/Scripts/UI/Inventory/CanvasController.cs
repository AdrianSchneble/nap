using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    private const int MAX_COLUMS = 5;
    private const int MAX_ROWS = 11;
    private const float SLOT_SIDE = 80;
    private const float START_X = -419;
    private const float START_Y = 151;
    public GameObject inventorySlot;
    public GameObject[] inventorySlots = new GameObject[MAX_COLUMS * MAX_ROWS];


    void Start()
    {
        //creates the Inventory Slots

        for(int i = 0; i < MAX_COLUMS; i++)
        {
            for (int j = 0; j < MAX_ROWS; j++)
            {
             Vector3 vector = new Vector3(START_X + (SLOT_SIDE * j), START_Y - (SLOT_SIDE * i), 1);
             GameObject newSlot = Instantiate(inventorySlot, vector, new Quaternion());
             newSlot.transform.SetParent(this.gameObject.transform, false);
             newSlot.transform.name = ("Button " + i + "," + j);
             inventorySlots[(i + 1) * (j + 1) - 1] = newSlot;
            }
        }
    }

    void OnEnable()
    {
        RefreshInventory();
    }

    public void CloseInventory()
    {
        GameObject.Find("InventoryCanvas").SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void RefreshInventory()
    {
        int count = 0;
        foreach (InventoryEntry entry in GameObject.Find("Player").GetComponent<InventoryController>().GetInventoryContents())
        {
            Debug.Log(GameObject.Find("Player").GetComponent<InventoryController>().GetInventoryContents().Count);
            //TODO: Remove after multiple pages are implemented
            if (count < 55)
            {
                inventorySlots[count].GetComponent<InventorySlotController>().SetItem(entry.item);
                count++;
            }
        }
    }
}
