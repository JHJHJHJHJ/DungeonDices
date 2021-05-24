using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] ProceduralImage hpBar = null;
    [SerializeField] TextMeshProUGUI hpText = null;

    Health health;

    private void Awake() 
    {
        health = FindObjectOfType<Player>().GetComponent<Health>();    
    }

    private void Start() 
    {
        UpdateDisplay();
    }

    private void Update() 
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        hpBar.fillAmount = (float)health.GetCurrentHealth() / (float)health.GetMaxHealth();
        hpText.text = health.GetCurrentHealth().ToString() + " / " + health.GetMaxHealth().ToString();
    }
}
