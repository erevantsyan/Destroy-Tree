using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _playerInfoText;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _playerInfoText.text = Player.points + "";
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ButHome()
    {
        SceneManager.LoadScene(0);
    }
}
