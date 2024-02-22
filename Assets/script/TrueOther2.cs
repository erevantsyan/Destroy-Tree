using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueOther2 : MonoBehaviour
{
    public Transform SpawnTr;
    public Transform checkDestroy;
    public float checkRadius1 = 0.1f;
    public LayerMask CD;
    public bool checkedDestroy;
    public GameObject Board;
    public Transform PlayerG;
    public int count = 1;
    public Animator anim;
    public GameObject But1;
    public GameObject But2;
    public GameObject ImageDle;
    [SerializeField] private int sec = 0;
    [SerializeField] private int delta = 1;
    public Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckingDestroy();
        if (PlayerG.position.x == 3.2f && count == 1)
        {
            DestroyMechanics1();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DestroyMechanics();
        }
        if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            DestroyMechanics1();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(checkDestroy.position, checkRadius1);
    }

    void CheckingDestroy(){
        checkedDestroy = Physics2D.OverlapPoint(checkDestroy.position, CD);
    }

    void DestroyMechanics(){
        if (checkedDestroy && count == 1){
            Player.points += 1;
            PlayerG.position = new Vector2(-2.5f, -7.5f);
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 180;
            PlayerG.rotation = Quaternion.Euler(rotate);
            Player.animBoard4 = true;
            anim.SetBool("B4", Player.animBoard4);
            Player.punchPlayer = true;
            animPlayer.SetBool("Punch", Player.punchPlayer);
            Pickup();
            count = 0;
            Destroy(gameObject);
        }
    }

    void DestroyMechanics1(){
        if (checkedDestroy && count == 1){
            PlayerG.position = new Vector2(3.2f, -7.5f);
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            PlayerG.rotation = Quaternion.Euler(rotate);
            Player.deathPlayer = true;
            animPlayer.SetBool("Death", Player.deathPlayer);
            count = 0;
            StartCoroutine(ITimer());
        }
    }

    public void Pickup()
    {
        Instantiate(Board, SpawnTr.position, SpawnTr.rotation);
    }

    IEnumerator ITimer()
    {
        while (true)
        {
            sec += delta;
            if (sec == 2)
            {
                sec = 0;
                SceneManager.LoadScene(2);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
