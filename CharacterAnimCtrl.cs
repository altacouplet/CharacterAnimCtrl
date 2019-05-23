using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimCtrl : MonoBehaviour
{
    private Animator anim;
    private Vector3 oldPos;

    public float WaitTime;
    public float ElaspedTime;    // 経過時間

    public int randomMotion;

    public AudioClip Sound01;
    public AudioClip Sound02;

    public AudioSource audiosource;

    void Start()
    {
        // 音量設定
        AudioSource[] audioSources = GetComponents<AudioSource>();

        audiosource = GetComponent<AudioSource>();
        audiosource.loop = false;
        audiosource.playOnAwake = false;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // タイマー作動
        ElaspedTime += 1 * Time.deltaTime;

        // 前回位置と現在位置が異なるとき
        if (oldPos != transform.position)
        {
            // 歩行モーション
            anim.SetBool("Sleep", false);
            anim.SetBool("Play", false);

            anim.SetBool("Walk", true);
        }
        else
        {
            // 待機モーション
            anim.SetBool("Walk", false);

            // タイマーが切れたら
            if (ElaspedTime > WaitTime)
            {
                // ランダムで分岐
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

                ElaspedTime = 0;
            }
        }

        // 前回位置の記録
        oldPos = transform.position;
    }

    // AnimationEvent発生時に効果音再生
    void Event01()
    {
        audiosource.clip = Sound01;
        audiosource.Play();
    }

    void Event02()
    {
        audiosource.clip = Sound02;
        audiosource.Play();
    }
}