using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeNull : MonoBehaviour
{
    public Transform SpawnTr;
    public Transform checkDestroy;
    public float checkRadius1 = 0.1f;
    public LayerMask CD;
    public bool checkedDestroy;
    public int randomCount;
    public List<GameObject> Board = new List<GameObject> (){ };
    public Transform PlayerG;
    public int count = 1;
    public Animator anim;
    public Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckingDestroy();
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
            Player.animBoard = true;
            anim.SetBool("B", Player.animBoard);
            Player.punchPlayer = true;
            animPlayer.SetBool("Punch", Player.punchPlayer);
            Pickup();
            count = 0;
            Destroy(gameObject);
        }
    }

    void DestroyMechanics1(){
        if (checkedDestroy && count == 1){
            Player.points += 1;
            PlayerG.position = new Vector2(3.2f, -7.5f);
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            PlayerG.rotation = Quaternion.Euler(rotate);
            Player.animBoard1 = true;
            anim.SetBool("BR", Player.animBoard1);
            Player.punchPlayer = true;
            animPlayer.SetBool("Punch", Player.punchPlayer);
            Pickup();
            count = 0;
            Destroy(gameObject);
        }
    }

    public void Pickup()
    {
        randomCount = Random.Range(1, 4);
        Instantiate(Board[randomCount], SpawnTr.position, SpawnTr.rotation);
    }

    // void Update() {
    //     if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    //     {
    //         count -= 1;
    //         if (count == 0)
    //         {
    //             Player.position = new Vector2(-3.3f, -7.5f);
    //             Pickup();
    //             Destroy(gameObject);
    //             count = 7;
    //         }
    //     }
    //     if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))
    //     {
    //         count -= 1;
    //         if (count == 0)
    //         {
    //             Player.position = new Vector2(-3.3f, -7.5f);
    //             Pickup();
    //             Destroy(gameObject);
    //             count = 7;
    //         }
    //     }
    // }
}
