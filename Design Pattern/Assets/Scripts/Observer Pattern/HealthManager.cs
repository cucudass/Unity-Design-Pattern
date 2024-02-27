using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//해당 클래스가 관찰자 역할
public class HealthManager : MonoBehaviour, IHealthObserver
{
    [SerializeField] Slider hpSlider;

    public void OnHealthChanged(float newHealth) {
        hpSlider.value = newHealth;
    }
}
