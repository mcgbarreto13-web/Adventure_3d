using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothes
{
public class ClothItemSpeed : ClothItemBase
{
    public float targetSpeed = 50f;
    public override void Collect()
        {
            base.Collect();
            PlayerBase.Instance.ChangeSpeed(targetSpeed, duration);
        }
}  
}

