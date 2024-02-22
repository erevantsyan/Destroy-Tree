using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class ButtonsMain : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _playerInfoText;
    public int record;

    public GameObject ButtonSoundOn;
    public GameObject ButtonSoundOff;

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public void PlayButtons()
    {
        Player.points = 0;
        SceneManager.LoadScene(1);
    }

    public void SoundButtonOn()
    {
        ButtonSoundOn.SetActive (false);
        ButtonSoundOff.SetActive (true);
        Player.musicEff = false;
    }

    public void SoundButtonOff()
    {
        ButtonSoundOn.SetActive (true);
        ButtonSoundOff.SetActive (false);
        Player.musicEff = true;
    }

    void Start(){
        ShowAdv();
        record = Player.points;
        if (PlayerPrefs.GetInt("HighScoreText") < record)
        {
            PlayerPrefs.SetInt("HighScoreText", record);
        }
        _playerInfoText.text = PlayerPrefs.GetInt("HighScoreText") + "";
        if (Player.musicEff) {
            ButtonSoundOn.SetActive (true);
            ButtonSoundOff.SetActive (false);
        }
        else {
            ButtonSoundOn.SetActive (false);
            ButtonSoundOff.SetActive (true);
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Player.points = 0;
            SceneManager.LoadScene(1);
        }
    }
}
