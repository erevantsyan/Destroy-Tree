using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnTree : MonoBehaviour
{
    public TMP_Text textResult;
    public Animator anim;
    public Animator animPlayer;
    [SerializeField] private float sec = 0;
    [SerializeField] private float delta = 1f;
    public Image Bar;
    private int count = 0;
    public AudioSource SoundEff;
    

    void Start(){
        if (Player.musicEff) {SoundEff.enabled = true;}
        else {SoundEff.enabled = false;}
    }

    void Update(){
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && count == 0)
        {
            TimeStartFunc();
        }
        textResult.text = Player.points + "";
        if (Player.animBoard)
        {
            sec -= 0.25f;
            Player.animBoard = false;
            anim.SetBool("B", Player.animBoard);
        }

        if (Player.animBoard1)
        {
            sec -= 0.25f;
            Player.animBoard1 = false;
            anim.SetBool("BR", Player.animBoard1);
        }

        if (Player.animBoard2)
        {
            sec -= 0.25f;
            Player.animBoard2 = false;
            anim.SetBool("B2", Player.animBoard2);
        }

        if (Player.animBoard3)
        {
            sec -= 0.25f;
            Player.animBoard3 = false;
            anim.SetBool("B3", Player.animBoard3);
        }

        if (Player.animBoard4)
        {
            sec -= 0.25f;
            Player.animBoard4 = false;
            anim.SetBool("B4", Player.animBoard4);
        }

        if (Player.animBoard5)
        {
            sec -= 0.25f;
            Player.animBoard5 = false;
            anim.SetBool("B5", Player.animBoard5);
        }

        if (Player.punchPlayer)
        {
            Player.punchPlayer = false;
            animPlayer.SetBool("Punch", Player.punchPlayer);
        }

        if (Player.deathPlayer)
        {
            Player.deathPlayer = false;
            animPlayer.SetBool("Death", Player.deathPlayer);
        }
        
        if (sec > 100f) sec = 100f;
        Bar.fillAmount = (100f - sec) / 100f;
    }

    void TimeStartFunc(){
        if (count == 0)
        {
            count = 1;
            StartCoroutine(ITimer());
        }
    }

    IEnumerator ITimer()
    {
        while (true)
        {
            sec += delta;
            if (sec >= 100f)
            {
                sec = 0;
                SceneManager.LoadScene(2);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
