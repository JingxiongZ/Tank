using UnityEngine;

public class born : MonoBehaviour
{
    public GameObject playerPrefab;

    public GameObject[] enemyPrefabList;

    public bool isPlayer;

    void Start()
    {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
    }

    void Update()
    {

    }

    private void BornTank()
    {
        if (isPlayer)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);
        }
    }
}
