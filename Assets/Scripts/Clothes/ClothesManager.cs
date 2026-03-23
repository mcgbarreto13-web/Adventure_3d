using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

namespace Clothes
{
    
public enum ClothType
    {
        SPEED,
        STRONG
    }
public class ClothesManager : Singleton<ClothesManager>
{
  public List<ClothesSetup> clothesSetups;

  public ClothesSetup GetSetupByType(ClothType clothType)
        {
            return clothesSetups.Find(i => i.clothType == clothType);
        }
}

public class ClothesSetup
    {
        public ClothType clothType;
        public Texture2D text;
    }
}
