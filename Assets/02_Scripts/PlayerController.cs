using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform[] playerPosList = new Transform[5];
    public int playerCurPos;
    // public float limitX = 2.5f;
    private int playerHP = 5;
    public int PlayerHP
    {
        get
        {
            return playerHP;
        }
        set
        {
            playerHP = value;
            UpdateHPUI();
        }
    }
    public int playerMaxHP = 5;
    private float curFuelAmount;
    public float CurFuelAmount
    {
        get 
        {
            return curFuelAmount;
        }
        set
        {
            curFuelAmount = value;
            if (curFuelAmount > 100)
                curFuelAmount = 100;
            if (curFuelAmount <= 0)
            {
                curFuelAmount = 0;
            }
            fuelSlider.value = CurFuelAmount / maxFuelAmount;
        }
    }
    public float fuelConsumeAmount;
    public float maxFuelAmount = 100f;
    float temp;
    float fuelConsumeInterval = 0.02f;

    public GameObject hitEffect;
    public GameObject itemGainEffect;
    public Slider fuelSlider;
    public Transform hpBar;

    public GameObject groundParent;
    public List<GroundScrolling> groundScrollings = new();
    public bool isAlive;
    public TimeChecker timeChecker;

    private void Start()
    {
        playerCurPos = 2;
        AdjustFuelAmount(maxFuelAmount);

        InitGroundScrollings();
        isAlive = true;
    }

    void InitGroundScrollings()
    {
        for (int i = 0; i < groundParent.transform.childCount; ++i)
        {
            groundScrollings.Add(groundParent.transform.GetChild(i).GetComponent<GroundScrolling>());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangePosition(-1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangePosition(1);
        }

        Move(playerCurPos);

        ConsumeFuelConsistently();
    }

    #region 捞悼 包访
    void ChangePosition(int amount)
    {
        if (!isAlive) return;
        playerCurPos = Mathf.Clamp(playerCurPos += amount, 0, playerPosList.Length - 1);
    }

    void Move(int idx)
    {
        if (!isAlive) return;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, playerPosList[idx].position, Time.deltaTime * moveSpeed);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ETag.Enemy.ToString())
        {
            Debug.Log(other.gameObject + "客 面倒");
            GetDamage(other.gameObject.GetComponent<Enemy>().damage);
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == ETag.Item.ToString())
        {
            Debug.Log(other.gameObject + "客 面倒");
            other.gameObject.GetComponent<Item>().OnItemAcquired(this);

            Instantiate(itemGainEffect, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }

    void GetDamage(int amount)
    {
        if (PlayerHP <= 0)
            return;
        PlayerHP -= amount;

        if (playerHP <= 0)
        {
            PlayerHP = 0;
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        Debug.Log("########### GAMEOVER ###########");
        isAlive = false;
        timeChecker.SetMaxTime();
    }

    void KillPlayerDueToFuel()
    {
        Debug.Log("out of fuel");
        isAlive = false;
        StartCoroutine(StopCor());
    }

    IEnumerator StopCor()
    {
        int count = groundScrollings.Count;
        while (count != 0)
        {
            foreach (var groundScrolling in groundScrollings)
            {
                if (groundScrolling.speedZ > 0)
                {
                    groundScrolling.speedZ -= 1;
                    if (groundScrolling.speedZ <= 0)
                    {
                        groundScrolling.speedZ = 0;
                        count++;
                    }
                }
                yield return new WaitForSeconds(0.025f);
            }
        }
        
    }

    public void Heal(int amount = 1)
    {
        if (PlayerHP >= playerMaxHP)
            return;
        Debug.Log("Heal");
        ++PlayerHP;
    }

    public void ConsumeFuelConsistently()
    {
        if (curFuelAmount <= 0)
            return;

        temp += Time.deltaTime;
        if (temp > fuelConsumeInterval)
        {
            AdjustFuelAmount(-0.1f * fuelConsumeAmount);

            temp = 0;
        }

        if (curFuelAmount <= 0)
        {
            KillPlayerDueToFuel();
        }
    }

    public void AdjustFuelAmount(float amount)
    {
        CurFuelAmount += amount;
    }

    void UpdateHPUI()
    {
        hpBar.localScale = new Vector3((float)PlayerHP/playerMaxHP, 1, 1);
    }
}
