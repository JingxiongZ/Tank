using UnityEngine;

public class barrier : MonoBehaviour
{
    public AudioClip hitAudio;

    public void playAudio()
    {
        AudioSource.PlayClipAtPoint(hitAudio, transform.position);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
