using System.Collections.Generic;
using UnityEngine;

//20 * 16
public class map : MonoBehaviour
{
    public GameObject[] items; //0: home, 1: wall, 2: barrier, 3: born, 4: river, 5: grass, 6: airwall

    private List<Vector3> existedPositions = new List<Vector3>();

    private void Awake()
    {

        InitMap();
    }

    private void InitMap()
    {
        // home
        CreateItem(items[0], new Vector3(0, -8, 0), Quaternion.identity);
        // home wall
        CreateItem(items[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(items[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = 0; i < 3; i++)
        {
            CreateItem(items[1], new Vector3(i - 1, -7, 0), Quaternion.identity);
        }
        //airwall
        for (int x = -10; x < 11; x++)
        {
            CreateItem(items[6], new Vector3(x, 9, 0), Quaternion.identity);
        }
        for (int x = -10; x < 11; x++)
        {
            CreateItem(items[6], new Vector3(x, -9, 0), Quaternion.identity);
        }
        for (int y = -8; y < 9; y++)
        {
            CreateItem(items[6], new Vector3(-11, y, 0), Quaternion.identity);
        }
        for (int y = -8; y < 9; y++)
        {
            CreateItem(items[6], new Vector3(11, y, 0), Quaternion.identity);
        }

        //player
        GameObject player = Instantiate(items[3], new Vector3(-2, -8, 0), Quaternion.identity);
        player.GetComponent<born>().isPlayer = true;

        //enemys
        CreateItem(items[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(items[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(items[3], new Vector3(10, 8, 0), Quaternion.identity);
        InvokeRepeating("CreateEnemy", 4, 5);

        // for each
        for (int i = 0; i < 50; i++)
        {
            CreateItem(items[1], CreateRandomPos(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(items[2], CreateRandomPos(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(items[4], CreateRandomPos(), Quaternion.identity);
        }
        for (int i = 0; i < 30; i++)
        {
            CreateItem(items[5], CreateRandomPos(), Quaternion.identity);
        }
    }

    private void CreateItem(GameObject item, Vector3 position, Quaternion rotation)
    {
        GameObject go = Instantiate(item, position, rotation);
        go.transform.SetParent(gameObject.transform);
        existedPositions.Add(position);
    }

    private Vector3 CreateRandomPos()
    {
        while (true)
        {
            Vector3 position = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!IsPositionExisted(position))
            {
                return position;
            }
        }
    }

    private bool IsPositionExisted(Vector3 position)
    {
        for (int i = 0; i < existedPositions.Count; i++)
        {
            if (position == existedPositions[i])
            {
                return true;
            }
        }
        return false;
    }

    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 enemyPositions = new Vector3();
        if (num == 0)
        {
            enemyPositions = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            enemyPositions = new Vector3(0, 8, 0);
        }
        else
        {
            enemyPositions = new Vector3(10, 8, 0);
        }
        CreateItem(items[3], enemyPositions, Quaternion.identity);

    }

    void Start()
    {

    }
    void Update()
    {

    }
}
