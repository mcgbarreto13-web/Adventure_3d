using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public List<UIGunUpdater> uIGunUpdaters;
   public float maxShoot = 5;
   public float timeToRecharge = 1f;

   private float _currentShots;
   private bool _recharging = false;

    private void Awake()
    {
        GetAllUis();
    }

    protected override IEnumerator StartShoot()
    {
        if(_recharging) yield break;
        while (true)
        {
            if(_currentShots < maxShoot)
            {
                Shoot();
                _currentShots ++;
                CheckRecharge();
                UpdateUI();
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }
    }

    private void CheckRecharge()
    {
        if(_currentShots >= maxShoot)
        {
            StopShooting();
            StartRecharge();    
        }
    }
    private void StartRecharge()
    {
        _recharging = true;
        StartCoroutine(RechargeCoroutine());

    }

    IEnumerator RechargeCoroutine()
    {
        float time = 0;
        while (time < timeToRecharge)
        {
            time += Time.deltaTime;
            uIGunUpdaters.ForEach(i => i.UpdateValue(time/timeToRecharge));
            yield return new WaitForEndOfFrame();
        }
        _currentShots = 0;
        _recharging = false;
    }
    private void UpdateUI()
    {
        uIGunUpdaters.ForEach(i => i.UpdateValue(maxShoot, _currentShots));
    }

    [System.Obsolete]
    private void GetAllUis()
    {
        uIGunUpdaters = GameObject.FindObjectsByType<UIGunUpdater>().ToList();
        //eu não sei o que acontece, o chat diz que não há erro e eu copiei o vídeo passo a passo mas ainda aparece um CS1501 para esta linha ;-;
    }
}
