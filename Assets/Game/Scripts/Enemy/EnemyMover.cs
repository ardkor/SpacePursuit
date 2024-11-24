using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private void Update()
    {
        Vector3 movement = _speed * Time.deltaTime * Vector3.down;

        float newYPos = Mathf.Clamp(transform.position.y + movement.y, _minHeight, _maxHeight);
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
    }
    public void TryStop()
    {
        if (transform.position.y - _range <= _minHeight)
        {
            enabled = false;
        }
    }
}
