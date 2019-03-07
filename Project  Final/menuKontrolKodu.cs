using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuKontrolKodu : MonoBehaviour {


    //Lighting den skybox un ambiant ini realtime dan baked yaptım
    // ve realtime global Iı yi kapadm açıktı önceden
    public Text yıldızSayısıText;
    AudioSource []aSource;
    public Text playText;
    public Text shipText;

    void Start()
    {
        yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1")+"";
        aSource = GetComponents<AudioSource>();
       // DontDestroyOnLoad(this.gameObject);
    }

    public  void Buttonlwl_1()
    {
        SceneManager.LoadScene(3);
        //oyunahakimimkodu.lwlnum = 0;
        aSource[0].Play();
    }
  public void Buttonlwl_2()
    {
        SceneManager.LoadScene(4);
        // oyunahakimimkodu.lwlnum = 1;
        aSource[0].Play();
    }
   public  void Buttonlwl_3()
    {
        SceneManager.LoadScene(5);
        // SceneManager.LoadScene(1);
        // oyunahakimimkodu.lwlnum = 2;
        aSource[0].Play();
    }
  public  void Buttonlwl_4()
    {
        SceneManager.LoadScene(6);
        aSource[0].Play();
    }
    public void Buttonlwl_5()
    {
        SceneManager.LoadScene(7);
        aSource[0].Play();
    }
    public void Buttonlwl_6()
    {
        SceneManager.LoadScene(8);
        aSource[0].Play();
    }
    public void Buttonlwl_7()
    {
        SceneManager.LoadScene(9);
        aSource[0].Play();
    }
    public void Buttonlwl_8()
    {
        SceneManager.LoadScene(10);
        aSource[0].Play();
    }
    public void Buttonlwl_9()
    {
        SceneManager.LoadScene(11);
        aSource[0].Play();
    }
    public void Buttonlwl_10()
    {
        SceneManager.LoadScene(12);
        aSource[0].Play();
    }

    public void playButton()
    {
        // SceneManager.LoadScene(1);
        Invoke("playButtonİnvoke", 1f);
        aSource[0].Play();
        playText.fontSize = playText.fontSize - 10;
    }
    public void shipsMenüButton()
    {
        //  SceneManager.LoadScene(2);
        Invoke("shipButtotnİnvoke", 1f);
        aSource[0].Play();
        shipText.fontSize = shipText.fontSize - 10;
    }
    public void gemi1seçimi()
    {
        
        PlayerPrefs.SetInt("gemiplayerİndex", 0);
        aSource[0].Play();
    }
    public void gemi2seçimi()
    {
        if (PlayerPrefs.GetInt("yıldızSayısı1") >=10)
        {
            PlayerPrefs.SetInt("gemiplayerİndex", 1);
            PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 10);
            yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
            aSource[0].Play();
        }
            
    }
    public void gemi3seçimi()
    {
        if (PlayerPrefs.GetInt("yıldızSayısı1") >= 50)
        {
            PlayerPrefs.SetInt("gemiplayerİndex", 2);
            PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 50);
            yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
            aSource[0].Play();
        }

       
       // PlayerPrefs.SetInt("gemiplayerİndex", 2);
    }
    public void AnaMenüReturnButton()
    {
        SceneManager.LoadScene(0);
        aSource[0].Play();
    }
    void playButtonİnvoke()
    {
        SceneManager.LoadScene(1);
    }
    void shipButtotnİnvoke()
    {
        SceneManager.LoadScene(2);
    }
    public void başLwlYKLE()
    {
      

        SceneManager.LoadScene(13);
    }
    
}
