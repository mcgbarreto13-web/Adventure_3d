using System.Collections;
using System.Collections.Generic;
using Ebac.StateMachine;
using UnityEngine;

public class BossBase : MonoBehaviour
{
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

    }
}
