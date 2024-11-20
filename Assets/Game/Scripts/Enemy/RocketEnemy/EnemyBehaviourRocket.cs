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
    private float upDownTimer;

    private bool randomShoot;
    private bool randomTr;
    private bool upDown = true;
    private Vector3 positionChanger;
    private void Start()
    {
        _enemyMover = GetComponent<EnemyMover>();
        StartCoroutine(RandomizeEnemy());
    }

    private void Update()
    {
        _enemyMover.TryStop();
        upDownTimer += Time.deltaTime;
            if (upDown) { 
                transform.Translate(0.7f * Time.deltaTime * Vector3.down);
            }
            else{
                transform.Translate(0.7f * Time.deltaTime * Vector3.up);
            }

        if (upDownTimer >= 2)
        {
            if (upDown) { upDown = false; } else { upDown = true; }
            upDownTimer = 0;
        }

        if (randomTr)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }
        else
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }

        if(transform.position.x > _rightBorder)
        {
            positionChanger = transform.position;
            positionChanger.x = _leftTpPos;
            transform.position = positionChanger;
        }
        else if (transform.position.x < _leftBorder)
        {
            positionChanger = transform.position;
            positionChanger.x = _rightTpPos;
            transform.position = positionChanger;
        }

        if(randomShoot)
        {
            //shooting
        }
    }

    private IEnumerator RandomizeEnemy()
    {
        while (true)
        {
            //randomMove = UnityEngine.Random.Range(0,2) == 1;
            randomShoot = UnityEngine.Random.Range(0, 2) == 1;
            randomTr = UnityEngine.Random.Range(0, 2) == 1;


            yield return new WaitForSeconds(1);
        }
    }
}
