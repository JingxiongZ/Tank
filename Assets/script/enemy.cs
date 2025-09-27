using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 5.0f;

    public Sprite[] tankSprite; //up right down left

    public GameObject bulletPrefab;

    public GameObject explosionPrefab;

    private Vector3 bulletEulerAngles;

    private float timeVal;
    private float directionTimeVal = 0;
    private float v = -1;
    private float h;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeVal >= 3)
        {
            Attack(); //player
        }
        else
        {
            timeVal += Time.deltaTime;
        }

    }

    public void FixedUpdate()
    {
        Move(); //player
    }

    private void Attack()
    {

        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
        timeVal = 0;

    }

    private void Move()
    {
        if (directionTimeVal >= 4)
        {
            int num = Random.Range(0, 8);
            if (num >= 5)
            {
                v = -1; h = 0;
            }
            else if (num == 0)
            {
                v = 1; h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                v = 0; h = 1;
            }
            else if (num > 2 && num <= 4)
            {
                v = 0; h = -1;
            }
            directionTimeVal = 0;
        }
        else
        {
            directionTimeVal += Time.fixedDeltaTime;
        }

        transform.Translate(Vector3.up * v * speed * Time.deltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2]; //down
            bulletEulerAngles = new Vector3(0, 0, -180);

        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0]; //up
            bulletEulerAngles = new Vector3(0, 0, 0);

        }

        if (v != 0)
        {
            return;
        }

        transform.Translate(Vector3.right * h * speed * Time.deltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3]; //left
            bulletEulerAngles = new Vector3(0, 0, 90);

        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1]; //right
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
    }

    private void Die()
    {
        playerManager.Instance.score += 1;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            directionTimeVal = 4;
        }
    }
}
