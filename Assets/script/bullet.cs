using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10.0f;

    public bool isPlayer;   //default: false
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        switch (collsion.tag)
        {
            case "tank":
                {
                    if (!isPlayer)
                    {
                        collsion.SendMessage("Die");

                        Destroy(gameObject);
                    }
                    break;
                }
            case "home":
                {
                    collsion.SendMessage("Die");
                    Destroy(gameObject);
                    break;
                }

            case "enemy":
                {
                    if (isPlayer)
                    {
                        collsion.SendMessage("Die");
                        Destroy(gameObject);
                    }
                    break;
                }

            case "wall":
                {
                    Destroy(collsion.gameObject);
                    Destroy(gameObject);
                    break;
                }
            case "barrier":
                {
                    if (isPlayer)
                    {
                        collsion.SendMessage("playAudio");
                    }
                    Destroy(gameObject);
                    break;
                }
            default:
                break;
        }
    }
}
