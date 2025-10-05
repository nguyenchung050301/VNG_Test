using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int damage;
    [SerializeField] private float knockbackForce;
    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            collision.transform.Translate((collision.transform.position - transform.position).normalized * knockbackForce * Time.deltaTime, Space.World);

            if (collision.TryGetComponent<CharacterHealth>(out var characterHealth))
            {
                characterHealth.TakeDamage(damage);
            }
        }
    }
}
