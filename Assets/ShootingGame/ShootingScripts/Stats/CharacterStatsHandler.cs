using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler :MonoBehaviour
{
    //기본스텟과 추가스텟을  계산해서 최종 스텟을 계산하는 로직이 있음
    //근데 지금은 그냥 기본 스텟만

    [SerializeField] private CharacterStats baseStat; //기본 능력치를 나타냄 

    public CharacterStats CurrentStat { get; private set; } //최종 능력치 저장 ->baseStat과 스탯 수정자를 적용하는 계산된 최종 능력치,private set은 외부에서 값을 변경하지 못하게 제한

    public List<CharacterStats> SstatModifiers = new List<CharacterStats>(); //버프들 들어가서 적용?

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        AttackS0 attackS0 = null;
        if(baseStat.attackS0 != null)
        {
            attackS0 = Instantiate(baseStat.attackS0);
        }

        CurrentStat = new CharacterStats { attackS0 = attackS0 };
        //TODO :: 지금은 기본 능력치만 적용되지만, 앞으로는 능력치강화기능이 적용된다.

        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}
