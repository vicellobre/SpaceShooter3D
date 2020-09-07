using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private AudioClipName audio;

    private void Start() {
        AudioManager.Play(audio);
        Destroy(gameObject, lifeTime);
    }
}
