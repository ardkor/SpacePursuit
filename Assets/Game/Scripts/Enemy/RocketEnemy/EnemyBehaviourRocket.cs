using System.Collections;
using UnityEngine;

public class EnemyBehaviourRocket : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 1.5f;
    [SerializeField] private EnemyMover _enemyMover;

    private float _leftTpPos = -14.5f;
    private float _rightTpPos = 14.5f;

    private float _leftBorder = -15f;
    private float _rightBorder = 15f;
    private float _yDisplacementTimer;

    private bool _randomShoot;
    private bool _randomDirection;
    private bool _upDown = true;

    private Vector3 _positionChanger;

    private void Start()
    {
        _enemyMover = GetComponent<EnemyMover>();
        StartCoroutine(RandomizeEnemy());
    }

    private void Update()
    {
        _enemyMover.TryStop();
        _yDisplacementTimer += Time.deltaTime;

        if (_upDown) { 
            transform.Translate(0.7f * Time.deltaTime * Vector3.down);
        }
        else{
            transform.Translate(0.7f * Time.deltaTime * Vector3.up);
        }

        if (_yDisplacementTimer >= 2)
        {
            if (_upDown) { _upDown = false; } 
            else { _upDown = true; }
            _yDisplacementTimer = 0;
        }

        if (_randomDirection)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }
        else
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }

        if (transform.position.x > _rightBorder)
        {
            _positionChanger = transform.position;
            _positionChanger.x = _leftTpPos;
            transform.position = _positionChanger;
        }
        else if (transform.position.x < _leftBorder)
        {
            _positionChanger = transform.position;
            _positionChanger.x = _rightTpPos;
            transform.position = _positionChanger;
        }

        if(_randomShoot)
        {
            //shooting
        }
    }

    private IEnumerator RandomizeEnemy()
    {
        while (true)
        {
            _enemySpeed = Random.Range(1f, 2f);
            //randomMove = UnityEngine.Random.Range(0,2) == 1;
            _randomShoot = Random.Range(0, 2) == 1;
            _randomDirection = Random.Range(0, 2) == 1;


            yield return new WaitForSeconds(1);
        }
    }
}
