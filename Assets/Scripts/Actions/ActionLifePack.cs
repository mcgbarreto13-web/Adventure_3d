using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class ActionLifePack : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.L;
   public SOInt soInt;

   private void Start()
    {
        soInt = ItemManager.Instance.GetItemByType(ItemType.LIFE_PACK).sOInt;
    }

    private void RecoverLife()
    {
        if(soInt.Value > 0)
        {
            ItemManager.Instance.RemoveByType(ItemType.LIFE_PACK);
            PlayerBase.Instance.healthBase.ResetLife();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            RecoverLife();
        }
    }
}
