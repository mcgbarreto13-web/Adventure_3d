using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Ebac.StateMachine;
using UnityEngine;

namespace Boss
{
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK
    }
public class BossBase : MonoBehaviour
{
    [Header("animation")]
    public float startAnimationDuration =  .5f;
    public Ease startAnimationEase = Ease.OutBack;   
    public int attackAmount = 5;
    public float timeBetweenAttacks = .5f;

    public float speed = 5f;
    public List<Transform> wayPoints;

    public HealthBase healthBase;
    private StateMachine<BossAction> stateMachine;

    private void OnValidate()
    {
        if(healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        Init();
        OnValidate();
        healthBase.OnKill += BossKill;
    }

    private void Init()
    {
        stateMachine = new StateMachine<BossAction>();
        stateMachine.Init();

        stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
        stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());

    }
    #region WALK
  
    public void GoToRandomPoint()
        {
            StartCoroutine(GoToPointCoroutine(wayPoints[Random.Range(0, wayPoints.Count)]));
        }

    IEnumerator GoToPointCoroutine(Transform t)
        {
            while(Vector3.Distance(transform.position, t.position) > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }
        }
    #endregion

    #region STATE MACHINE
    public void SwitchState(BossAction state)
        {
            stateMachine.SwitchState(state, this);
        }
    #endregion

    #region DEBUG
    [NaughtyAttributes.Button]
    private void SwitchInit()
        {
            SwitchState(BossAction.INIT);
        }
        [NaughtyAttributes.Button]
    private void SwitchWalk()
        {
            SwitchState(BossAction.WALK);
        }
    #endregion

    #region ANIMATION
    public void StartInitAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }
    #endregion
}
}

