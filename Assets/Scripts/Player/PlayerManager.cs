using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public UnityEvent UpdateHealth, UpdateMana, UpdateAmmo;

        public int maxHealth;
        public int currentHealth;
        public int maxMana;
        public int currentMana;
        public int maxAmmo;
        public int currentAmmo;

        private void Awake()
        {
            instance = this;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            currentHealth = maxHealth;
            currentMana = maxMana;
            currentAmmo = maxAmmo;
            UpdateHealth?.Invoke();
            UpdateMana?.Invoke();
            UpdateAmmo?.Invoke();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
            UpdateHealth?.Invoke();
        }

        private void Die()
        {
            // Destroy(gameObject);
        }

	    public void ReloadAmmo()
        {
            currentAmmo = maxAmmo;
            UpdateAmmo?.Invoke();
        }

        public void UseMana(int manaCost)
        {
            currentMana -= manaCost;
            UpdateMana?.Invoke();
        }

        public void UseAmmo(int ammoCost)
        {
            currentAmmo -= ammoCost;
            UpdateAmmo?.Invoke();
        }

        public void Heal(int heal)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            UpdateHealth?.Invoke();
        }

        public void RestoreMana(int mana)
        {
            currentMana += mana;
            if (currentMana > maxMana)
            {
                currentMana = maxMana;
            }
            UpdateMana?.Invoke();
        }
    }
}
