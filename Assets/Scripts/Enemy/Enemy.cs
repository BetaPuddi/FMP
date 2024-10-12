using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;
        public int maxMana;
        public int currentMana;
        public int damage;
        public int movementSpeed;

        [SerializeField] private Material material;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            material = GetComponent<MeshRenderer>().material;

            currentHealth = maxHealth;
            currentMana = maxMana;
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
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
