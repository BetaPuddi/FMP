using System;
using Player;
using UnityEngine;
using TMPro;

public class HUDStats : MonoBehaviour
{
    public TextMeshProUGUI healthValue;
    public TextMeshProUGUI manaValue;
    public TextMeshProUGUI ammoValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        UpdateHealth();
        UpdateMana();
        UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        healthValue.text = PlayerManager.instance.currentHealth.ToString();
    }

    public void UpdateMana()
    {
        manaValue.text = PlayerManager.instance.currentMana.ToString();
    }

    public void UpdateAmmo()
    {
        ammoValue.text = PlayerManager.instance.currentAmmo.ToString();
    }
}
