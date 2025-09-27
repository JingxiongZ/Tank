using UnityEngine;

public class home : MonoBehaviour
{
    public Sprite brokenSprite;
    private SpriteRenderer sr;
    public GameObject explosionPrefab;
    public AudioClip dieAudio;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    public void Die()
    {
        sr.sprite = brokenSprite;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        playerManager.Instance.isDefeated = true;
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
    }
}
