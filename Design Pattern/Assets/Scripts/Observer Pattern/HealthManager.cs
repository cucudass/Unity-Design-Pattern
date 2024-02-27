using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�ش� Ŭ������ ������ ����
public class HealthManager : MonoBehaviour, IHealthObserver
{
    [SerializeField] Slider hpSlider;

    public void OnHealthChanged(float newHealth) {
        hpSlider.value = newHealth;
    }
}
