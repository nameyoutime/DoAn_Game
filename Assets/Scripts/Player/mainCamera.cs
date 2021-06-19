using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    // public Transform target;
    // public Vector3 offset;
    // public static mainCamera Instance;
    // Transform CamTransform;
    // AudioSource m_MyAudioSource;
    // public static float volume;
    // public Transform Player;

    public Transform target;
    public Vector3 offset;
    public float smoothFactor = 3;

    private void Awake()
    {
        // volume = 0.003f;
    }
    void Start()
    {

        // CamTransform = Camera.main.transform;
        // m_MyAudioSource = GetComponent<AudioSource>();
        // m_MyAudioSource.Play();
    }
    private void Update()
    {
        // m_MyAudioSource.volume = volume;
    }
    private void FixedUpdate()
    {
        if (!target)
            return;

        // this.transform.position.x = player.transform.position.x + offsetX
        // transform.position = target.position + offset;
        Vector3 targetPos = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;

        // transform.LookAt(target);    
    }
}
