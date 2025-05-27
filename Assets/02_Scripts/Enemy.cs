using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] cars;
    public int damage;
    EnemyController enemyController;
    public EnemyInfo[] enemyInfoSO;


    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        PickRandomCar();
        Debug.Log("cars.Length: " + cars.Length);
    }

    void SetInfo(int idx)
    {
        EnemyInfo info = enemyInfoSO[idx];
        enemyController.moveSpeed = info.speed;
        damage = info.damage;
    }

    void PickRandomCar()
    {
        int rand = Random.Range(0, cars.Length);
        Debug.Log(rand);
        cars[rand].SetActive(true);
        SetInfo(rand);
    }
}
