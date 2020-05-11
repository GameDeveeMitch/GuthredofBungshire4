using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float posionTimer = 15f;
    public float posionDamage = 5f;
    public enum StatusEffect
    {
        Poisoned,
        Sleepy,
        None,
    }
    public StatusEffect enemyStatusEffect = new StatusEffect();

    private float curPosionTimer;
    private bool checkForStatus = false;

    private void Start()
    {
        curPosionTimer = posionTimer;
        checkForStatus = true;
    }
    private void Update()
    {
        if (checkForStatus)
            ImplementStatusEffect();
    }
    public void SwitchStats(StatusEffect status)
    {
        enemyStatusEffect = status;
    }
    private void ImplementStatusEffect()
    {
        switch (enemyStatusEffect)
        {
            case StatusEffect.None:

                break;
            case StatusEffect.Poisoned:
                if (!PosionTimerMethod())
                {
                    ResetPosionTimer();
                    enemyStatusEffect = StatusEffect.None;
                }
                break;
            case StatusEffect.Sleepy:

                break;
        }
    }
    private bool PosionTimerMethod()
    {
        if (curPosionTimer > 0 && enemyHealth > 0)
        {
            curPosionTimer -= Time.deltaTime;
            TakeDamage(posionDamage);
            return true;
        }
        else if(enemyHealth <= 0)
        {
            Die();
            return false;
        }
        return false;
    }
    private void ResetPosionTimer()
    {
        curPosionTimer = posionTimer;
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
            Die();
    }
    private void Die()
    {
        this.gameObject.SetActive(false);
    }
}
