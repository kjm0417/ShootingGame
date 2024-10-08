using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler :MonoBehaviour
{
    //�⺻���ݰ� �߰�������  ����ؼ� ���� ������ ����ϴ� ������ ����
    //�ٵ� ������ �׳� �⺻ ���ݸ�

    [SerializeField] private CharacterStats baseStat; //�⺻ �ɷ�ġ�� ��Ÿ�� 

    public CharacterStats CurrentStat { get; private set; } //���� �ɷ�ġ ���� ->baseStat�� ���� �����ڸ� �����ϴ� ���� ���� �ɷ�ġ,private set�� �ܺο��� ���� �������� ���ϰ� ����

    public List<CharacterStats> SstatModifiers = new List<CharacterStats>(); //������ ���� ����?

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
        //TODO :: ������ �⺻ �ɷ�ġ�� ���������, �����δ� �ɷ�ġ��ȭ����� ����ȴ�.

        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}
