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
        //관찰자 등록
        HP.RegisterObserver(healthManager);

        //변경된 값 전달
        HP.ModifyHealth(currentHP, maxHP);
    }

    public void HPButton() {
        currentHP -= 1;
        HP.ModifyHealth(currentHP, maxHP);
    }
}
