using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviourRocket : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 1.5f;
    private float _leftTpPos = -14.5f;
    private float _rightTpPos = 14.5f;

    private float _leftBorder = -15f;
    private float _rightBorder = 15f;
    [SerializeField] private EnemyMover _enemyMover;
    private bool randomMove = true;
    private bool randomShoot;
    private bool randomTr;
    private float upDownTimer;
    private bool upDown = true;
    private Vector3 positionChanger;
    void Start()
    {
        _enemyMover = GetComponent<EnemyMover>();
        StartCoroutine(RandomizeEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        _enemyMover.TryStop();
        upDownTimer += Time.deltaTime;
            if (upDown) { 
                transform.Translate(Vector3.down * 0.7f * Time.deltaTime);
            }
            else{
                transform.Translate(Vector3.up * 0.7f * Time.deltaTime);
            }

        if (upDownTimer >= 2)
        {
            if (upDown) { upDown = false; } else { upDown = true; }
            upDownTimer = 0;
        }

        /*if (randomMove) 
        {*/
        if (randomTr)
            {
                transform.Translate(Vector3.right * _enemySpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * _enemySpeed * Time.deltaTime);
            }
        //}

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

    IEnumerator RandomizeEnemy()
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
