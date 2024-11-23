using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private SoundsPlayer _damagingPlayer;
    private string _soundName = "взрыв";
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    
    private float heartHP = 5f;
    private void Start()
    {
        HealthChanged?.Invoke((int)(_health / heartHP));
    }
    public void ApplyDamage(int damage)
    {
        _health -= damage;
        _damagingPlayer.Play(_soundName);
        HealthChanged?.Invoke((int)(_health / heartHP));
        if (_health <= 0)
            Die();
    }
    public void Die()
    {
        Died?.Invoke();
    }

}
