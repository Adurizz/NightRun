using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public float curTime;
    public float coolTime = 2f;
    public int itemGenProbability;
    public GameObject enemyPrefab;
    public GameObject[] itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomCool();
    }

    void SetRandomCool()
    {
        coolTime = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > coolTime)
        {
            GenRandomObj();
            curTime = 0;
            SetRandomCool();
        }
    }

    void GenRandomObj()
    {
        int random = Random.Range(0, 100);
        if (random > itemGenProbability)
            GenEnemy();
        else
            GenItem();
    }

    void GenEnemy()
    {
        Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);

    }

    void GenItem()
    {
        int random = Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[random], transform.position, transform.rotation);
    }
}
