using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    public int life = 3;
    public int score = 0;

    public bool isHit;

    public GameObject bornPrefab;

    public bool isDefeated;

    public Text lifeText;
    public Text scoreText;

    public GameObject isDefeatedImg;

    private static playerManager instance;
    public static playerManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if (isDefeated)
        {
            isDefeatedImg.SetActive(true);
            Invoke("returnToEntryScene", 3);
            return;
        }
        if (isHit)
        {
            ReBorn();
        }
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();

    }

    private void ReBorn()
    {
        if (life <= 0)
        {
            isDefeated = true;
            Invoke("returnToEntryScene", 3);
        }
        else
        {
            life--;
            GameObject player = Instantiate(bornPrefab, new Vector3(-2, -8, 0), Quaternion.identity);
            player.GetComponent<born>().isPlayer = true;
            isHit = false;
        }
    }

    private void returnToEntryScene()
    {
        SceneManager.LoadScene(0);
    }
}
