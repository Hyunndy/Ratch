using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIImage : MonoBehaviour
{

    public Sprite[] ItemUI = new Sprite[2];


    private new SpriteRenderer renderer;

    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = ItemUI[0];
    }

    public void ItemUI0_Change()
    {
        gameObject.GetComponent<Image>().sprite = ItemUI[1];
    }
    public void ItemUI1_Change()
    {
        gameObject.GetComponent<Image>().sprite = ItemUI[2];
    }
    public void ItemUI2_Change()
    {
        gameObject.GetComponent<Image>().sprite = ItemUI[3];
    }


 
        // Update is called once per frame
        
}
