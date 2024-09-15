using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update


    public static GameController instance;




    public GameObject canvas;

    public Item_SO iso;



    public Text txtTitle;
    public Text txtDescription;

    public VideoPlayer vpl;

    public GameObject gmInstancePoint;
    public GameObject gmToInstance;



    public AudioClip acRight;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (iso == null)
        { 
            canvas.SetActive(false); 
           
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        LetsTouch();
    }



    public void setISO(Item_SO so)
    {
        //  vpl.Stop();
        iso = so;
        if(gmToInstance != null)
        {
            Destroy(gmToInstance);
        }

        
        canvas.SetActive(true);
        vpl.clip = iso.vcClips[0];
        gmToInstance = Instantiate(iso.gmCharacter, gmInstancePoint.transform.position, iso.gmCharacter.transform.rotation);
        txtTitle.text = iso.title;
        txtDescription.text = iso.description;
        vpl.Play();
    }


    public void ChangeVideo()
    {
      // vpl.Stop();
        if (iso!= null)
        {
            int n = Random.Range(0,iso.vcClips.Count);
            vpl.clip = iso.vcClips[n];
            vpl.Play();

        }
    }


    public void LetsTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = GetFirstActiveCamera().ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject touchedObject = hit.collider.gameObject;
                    if (touchedObject.CompareTag("Build"))
                    {
                        AudioManager.instance.PlaySFX(acRight);
                        Build b = touchedObject.GetComponent<Build>();
                        setISO(b.so);

                    }
                }
            }
        }

    }



    Camera GetFirstActiveCamera()
    {
        return GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    public void CloseALl()
    {
          vpl.Stop();
        
        if (gmToInstance != null)
        {
            Destroy(gmToInstance);
        }

        
        canvas.SetActive(false);
    }

}
