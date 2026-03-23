using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestItemCoin : ChestItemBase
{
    public int coinNumber = 5;
    public GameObject coinObject;

    private List<GameObject> _items = new List<GameObject>();
    public override void ShowItem()
    {
        base.ShowItem();
        CreateItems();
    }

    private void CreateItems()
    {
        for(int i = 0; i < coinNumber; i++)
        {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position;
            item.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            _items.Add(item);
        }
    }
        
    
}
