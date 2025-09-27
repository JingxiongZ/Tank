using System.Xml.Serialization;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour
{

    private int select = 1;
    public Transform pos1;
    public Transform pos2;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            select = 1;
            transform.position = pos1.position;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            select = 2;
            transform.position = pos2.position;
        }

        if (select == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
