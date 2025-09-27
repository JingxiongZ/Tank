using Unity.Mathematics;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5.0f;

    public Sprite[] tankSprite; //up right down left

    public GameObject bulletPrefab;

    public GameObject explosionPrefab;
    public GameObject protectedPrefab;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private Vector3 bulletEulerAngles;

    private float timeVal;

    private SpriteRenderer sr;

    private bool isProtected = true;
    private float protectedTime = 3.0f;

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
        if (isProtected)
        {
            protectedPrefab.SetActive(true);
            protectedTime -= Time.deltaTime;
            if (protectedTime <= 0)
            {
                isProtected = false;
                protectedPrefab.SetActive(false);
            }
        }

        if (timeVal >= 0.4f)
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
        if (playerManager.Instance.isDefeated)
        {
            return;
        }
        Move(); //player
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
            timeVal = 0;
        }
    }

    private void Move()
    {
        float v = Input.GetAxis("Vertical");
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

        if (Mathf.Abs(v) > 0.05f)
        {
            audioSource.clip = audioClips[1];
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }
        }

        if (v != 0)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
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

        if (Mathf.Abs(h) > 0.05f)
        {
            audioSource.clip = audioClips[1];
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }
        }
        else
        {
            audioSource.clip = audioClips[0];
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }
        }
    }

    private void Die()
    {
        if (isProtected) { return; }
        playerManager.Instance.isHit = true;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
