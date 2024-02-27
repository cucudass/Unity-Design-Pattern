using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Health HP = new Health();
    private HealthManager healthManager;
    private SettingDatas settingDatas = new SettingDatas();

    private float currentHP;
    private float maxHP;

    void Start()
    {
        PlayerInit();
    }

    void PlayerInit() {
        maxHP = settingDatas.playerMaxHp;
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
