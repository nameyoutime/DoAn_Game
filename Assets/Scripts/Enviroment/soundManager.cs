using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance;

    static AudioSource sound;
    public static AudioClip Jump, Gem, Course_clear;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        Jump = Resources.Load<AudioClip>("sounds/jump");
        Gem = Resources.Load<AudioClip>("sounds/gem");
        Course_clear = Resources.Load<AudioClip>("sounds/course_clear");

        sound = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "jump":
                sound.PlayOneShot(Jump, 0.5f);
                break;
            case "gems":
                sound.PlayOneShot(Gem, 0.5f);
                break;
            case "course_clear":
                sound.PlayOneShot(Course_clear, 1f);
                break;
            default:
                break;
        }
    }
}
