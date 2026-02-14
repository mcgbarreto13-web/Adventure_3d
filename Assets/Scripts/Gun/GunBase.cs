using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunBase : MonoBehaviour
{
   public ProjectileBase prefabProjectile;

   public Transform positionToShoot;
   public float timeBetweenShots = .3f;
   public float speed = 50f;

   private Coroutine _currentCoroutine;

    protected virtual IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
    public virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speed = speed;

    }
    public void StartShooting()
    {
        StopShooting();
        _currentCoroutine = StartCoroutine(StartShoot());
        
    }
    public void StopShooting()
    {
        if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }

}
