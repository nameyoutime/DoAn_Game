using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int enemyHP;
    private int currentHP;
    [SerializeField] private int score = 2;
    [SerializeField] private GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = enemyHP;
    }
    // Update is called once per frame
    void Update()
    {

        if (currentHP <= 0)
        {
            Destroy(transform.parent.gameObject);
            Destroy(Instantiate(effect, transform.parent.position, this.transform.parent.rotation), 0.5f);
            scoreCounter.Instance.PlusScore(score);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
}
