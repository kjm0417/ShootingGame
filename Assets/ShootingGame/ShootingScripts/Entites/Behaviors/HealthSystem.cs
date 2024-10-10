using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;

    private CharacterStatsHandler statHandler;
    private float timeSincelastChange = float.MaxValue;
    private bool isAttacked = false;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth {  get; private set; } //프로퍼티는 대문자
    public float MaxHealth => statHandler.CurrentStat.maxHealth;


    private void Awake()
    {
        statHandler = GetComponent<CharacterStatsHandler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacked && timeSincelastChange < healthChangeDelay)
        {
            timeSincelastChange += Time.deltaTime;
            if(timeSincelastChange > healthChangeDelay )
            {
                OnInvincibilityEnd?.Invoke();
                isAttacked = false;

            }
        }

    }

    public bool ChangeHealth(float change)
    {
        if(timeSincelastChange < healthChangeDelay)
        {
            //공격을 하지 않고 끝나는 상황
            return false;
        }

        timeSincelastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth,0,MaxHealth);

        if(CurrentHealth <=0f)
        {
            CallDeath();
            return true;
        }
        if(change>=0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
            isAttacked = true;
        }

        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
