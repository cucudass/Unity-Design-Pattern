using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Health HP = new Health();
    private HealthManager healthManager;
    private SettingDatas settingDatas = new SettingDatas();

    private float currentHP;
    private float maxHP;
    [SerializeField] float sumHP;

    void Start() {
        EnemyInit();
    }

    void EnemyInit() {
        maxHP = settingDatas.EnemyMaxHp + sumHP;
        currentHP = maxHP;

        healthManager = GetComponent<HealthManager>();
        //������ ���
        HP.RegisterObserver(healthManager);

        //����� �� ����
        HP.ModifyHealth(currentHP, maxHP);
    }

    public void HPButton() {
        currentHP -= 1;
        HP.ModifyHealth(currentHP, maxHP);
    }
}
