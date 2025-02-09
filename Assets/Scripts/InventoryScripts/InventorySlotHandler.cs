using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string itemName;
    public string ItemName
    {
        get { return itemName; }
    }


    public int maxQuantity;

    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    public GameObject selectedSlot;
    public bool isSeletctedPanel;


    [SerializeField] private ItemDescriptionPanel itemDescriptionPanel;

    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image spritePlace;

    private InventoryManager inventoryManager;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        itemDescriptionPanel = GameObject.Find("ItemDescriptionPanel").GetComponent<ItemDescriptionPanel>();
        
    }

    public void AddItem(string itemName, int maxQuantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.maxQuantity = maxQuantity;
        this.itemSprite = itemSprite;
        this.nameText.text = itemName;
        this.itemDescription = itemDescription;
        
        isFull = true;

        quantityText.text = maxQuantity.ToString();
        if (spritePlace == null)
        {
            Debug.LogError("spritePlace is not assigned!");
        }
        else
        {
            spritePlace.sprite = itemSprite;
        }
        //spritePlace.sprite = itemSprite;
    }
    public void AddItem(int maxQuantity) 
    {
        this.maxQuantity += maxQuantity;
        Debug.Log("New quantity " + this.maxQuantity);
        this.quantityText.text = this.maxQuantity.ToString();
        //quantityText.text = maxQuantity.ToString();
        //Remember to put in a check for max amount of items

    }
    
    public void OnLeftClick()
    {
        if (isSeletctedPanel)
        {
            Debug.Log("the item is selected and use is called ");
            inventoryManager.UseItem(itemName);
        }
            
        inventoryManager.UnSelectAllSlots();
        selectedSlot.SetActive(true);
        this.isSeletctedPanel = true;
        itemDescriptionPanel.ShowDescriptionOf(itemName,itemSprite,itemDescription);

    }
    public void OnRightClick()
    {

    }
    public void UpdateUI()
    {
        quantityText.text = maxQuantity > 0 ? maxQuantity.ToString() : "";  // Clear text if empty
        spritePlace.sprite = itemSprite;
        nameText.text = !string.IsNullOrEmpty(itemName) ? itemName : ""; // Clear name if empty
    }
    public void UseItem()
    {
        maxQuantity--;

        if (maxQuantity <= 0)
        {
            ClearSlot();
        }
        else
        {
            UpdateUI();
        }
    }

    private void ClearSlot()
    {
        itemName = string.Empty;
        maxQuantity = 0;
        itemSprite = null;
        itemDescription = string.Empty;
        isFull = false;

        UpdateUI();
        //gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
}
