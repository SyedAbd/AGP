using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionPanel : MonoBehaviour
{
    [SerializeField]
    private Image itemDesImage;
    [SerializeField]
    private TMP_Text itemDesName;
    [SerializeField]
    private TMP_Text itemDesDescription;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDescriptionOf(string itemName , Sprite itemSprite, string itemDescription)
    {

        itemDesName.text = itemName;
        itemDesImage.sprite = itemSprite;
        itemDesDescription.text = itemDescription;

    }
}
