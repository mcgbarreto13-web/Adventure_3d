using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
   public class CollectableBase : MonoBehaviour
{
    public ItemType itemType;

    public string compareTag = "Player";
    public ParticleSystem particlesSystem;
    public float timeToHide = 1;
    public GameObject graphicItem;

    public Collider itemCollider;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (particlesSystem != null) particlesSystem.transform.SetParent(null);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if(itemCollider != null) itemCollider.enabled = false;
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollect();
    }
    private void HideObject()
    {
        gameObject.SetActive(false);

    }

protected virtual void OnCollect()
    {
        if(particlesSystem != null) particlesSystem.Play();
        if(audioSource != null) audioSource.Play();
        ItemManager.Instance.AddByType(itemType);
    }
} 
}

