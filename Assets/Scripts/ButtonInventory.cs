using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInventory : MonoBehaviour
{
    [SerializeField] Image _iconItem;
    [SerializeField] TextMeshProUGUI _amount;

    public void Clean()
    {
        Color c = Color.white;
        c.a = 0;
        _iconItem.color = c;

        _amount.text = "00";
    }

    public void Set(Sprite icon, string amount)
    {
        _iconItem.sprite = icon;
        Color c = Color.white;
        _iconItem.color = c;

        _amount.text = amount;
    }
}
