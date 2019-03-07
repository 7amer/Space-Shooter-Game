using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class düşmanGemiKodu : MonoBehaviour {

    Rigidbody fizik;
    public GameObject mermi;
    public Transform mermiPos;
    float zaman = 0f;
    GameObject gemiPlayer1;
    int darbeSayısı = 0;
    //public GameObject patlamaEfekti;
    GameObject oyunKontroller;
    public ParticleSystem patlama;
   // public ParticleSystem sonPatlama;
    AudioSource[] sesler;

    public Image canBarı;
    float oyunbas = 0f;

    //public GameObject bigEXP;
    public GameObject mysprite;
    Collider mycoll;
    
    bool ptlamaEfktAçık = false;
    //public GameObject didIt;
    bool mermiAtsın = true;

     void Awake()
    {
        oyunKontroller = GameObject.FindGameObjectWithTag("GameController");
    }
    void Start () {
        fizik = GetComponent<Rigidbody>();
        InvokeRepeating("mermiAt", 1f, 3f);
        canBarı.fillAmount = 1f;
       // gemiPlayer1 = GameObject.FindGameObjectWithTag("gemi1Sprite");

        Invoke("gemiPlayerBulucu", 0.1f);
        sesler = GetComponents<AudioSource>();
        mycoll = GetComponent<Collider>();
    }


    void Update()
    {
        zaman = zaman + Time.deltaTime;
        if (zaman > 0.5f)
        {
            enemiyoluyap();

        }




        //if (gemiPlayer1!=null)  //sorun burada gemiplayer1 i bulamıor instantied edildikten sonra fix it
        //{
        //    enemiyoluyap();
        //}
        //  enemiyoluyap();

    }

    void enemiyoluyap()
    {
        
        if (transform.position.y < gemiPlayer1.transform.position.y)
        {
            fizik.velocity = new Vector3(0f, 0.5f, 0f);
            
            if (gemiPlayer1.transform.position.y - transform.position.y < 0.1f)
            {
                fizik.velocity = new Vector3(0f, 0f, 0f);

            }
        }
        if (transform.position.y > gemiPlayer1.transform.position.y)
        {
            fizik.velocity = new Vector3(0f, -0.5f, 0f);
            Debug.Log("inior tamer");
            if (transform.position.y - gemiPlayer1.transform.position.y < 0.1f)
            {
                fizik.velocity = new Vector3(0f, 0f, 0f);

            }
        }
    }




    void mermiAt()
    {
        if(mermiAtsın==true)
        {
            //Instantiate(mermi, mermiPos.position, Quaternion.Euler(0f,-90f,0f));
            Instantiate(mermi, mermiPos.position, Quaternion.identity);
        }
       
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="mermitagi")
        {
            darbeSayısı++;
            canBarı.fillAmount = canBarı.fillAmount - 0.05f;
            //if(ptlamaEfktAçık==false)
            //  {
            //      
            //      ptlamaEfktAçık = true;
            //  }
            //GameObject efekt = Instantiate(patlamaEfekti, transform.position, Quaternion.identity);
            //Destroy(efekt, 2f);
            patlama.Play();
            Destroy(coll.gameObject);
            if (canBarı.fillAmount<=0f)
            {
                //Destroy(gameObject);
                // Instantiate(bigEXP, coll.transform.position, Quaternion.identity);
                //  sonPatlama.Play();
                patlama.transform.localScale = new Vector3(5f, 5f, 5f);
                patlama.Play();
            
                sesler[0].Play();
                //gameObject.SetActive(false);
                mysprite.SetActive(false);
                mycoll.enabled = false;
                //transform.position = new Vector3(500, 500, 500);
                // SceneManager.LoadScene(0);
                //didIt.SetActive(true);
                //sesler[1].Play();
                mermiAtsın = false;
                oyunKontroller.GetComponent<oyunahakimimkodu>().didİtÇal();
                GameObject.FindGameObjectWithTag("gemi1Sprite").GetComponent<GemiPlayerKodu>().yıldızlarıEkle(); //bura ii durmadı burayı düzelt
               // Invoke("AnaMenüReturn", 2.5f);                                                                     //çünkü sadece tek bir gemi tagi için yapabilir   

                
            }
        }
    }


    void gemiPlayerBulucu()
    {
         gemiPlayer1 = GameObject.FindGameObjectWithTag("gemi1Sprite");
       
    }
    public void AnaMenüReturn()
    {
        SceneManager.LoadScene(0);
        
    }

}
