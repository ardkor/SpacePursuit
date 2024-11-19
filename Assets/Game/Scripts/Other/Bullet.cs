using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _speed;

   /* private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
           enemy.ApplyDamage(_damage);
        }

        Die();
    }*/

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}
