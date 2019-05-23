using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimCtrl : MonoBehaviour
{
    private Animator anim;

    private Vector3 oldPos;

    public AudioClip sound01;
    public AudioClip sound02;

    public AudioSource audiosource;

    public float WaitTime;
    private float WaitElaspedTime;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        audiosource = GetComponent<AudioSource>();
        audiosource.loop = false;
        audiosource.playOnAwake = false;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 前回位置と現在位置が異なるとき
        if (oldPos != transform.position)
        {
            // 歩行モーション
            anim.SetBool("Walk", true);
        }
        else
        {
            // 待機モーション
            anim.SetBool("Walk", false);


            // 待機中、一定時間経過したら
            if (WaitElaspedTime > WaitTime)
            {
                randomMotion = Random.Range(1, 3);

                switch (randomMotion)
                {
                    // 遊ぶモーション
                    case 1:
                        anim.SetBool("Play", true);
                        break;

                    // 睡眠モーション
                    case 2:
                        anim.SetBool("Sleep", true);
                        break;
                }

                WaitElaspedTime = 0;
            }

            // 前回位置の記録
            oldPos = transform.position;

        }
    }

    // AnimationEvent発生時に効果音再生
    void Sound01()
    {
        audiosource.clip = sound01;
        audiosource.Play();
    }

    void Sound02()
    {
        audiosource.clip = sound02;
        audiosource.Play();
    }
}
