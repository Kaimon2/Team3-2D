using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource bgmSource;
    public AudioClip gameplayMusic;
    public AudioClip menuMusic;

    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(this);
            Debug.Log(SceneManager.GetActiveScene().name);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(this);
        }

        bgmSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
       if (scene.name == "Level1" || scene.name == "Level2")
       {
            if (bgmSource.clip != gameplayMusic) 
            {
                bgmSource.clip = gameplayMusic;
                bgmSource.Play();
            }
            
       }
        else
        {
            if (bgmSource.clip != menuMusic)
            {
                bgmSource.clip = menuMusic;
                bgmSource.Play();
            }
        }

        //AudioSource source = new AudioSource();

        //switch (scene.name)
        {
            //case "Level1":
            //source.clip = gameplay;
            //break;
            //case "Level2":
            // source.clip = gameplay;
            //break;
            //default:
            // source.clip = menu;
            //break;
        }

        //if(source.clip != bgmSource.clip)
        {
            //bgmSource.enabled = false;
            //bgmSource.clip = source.clip;
            //bgmSource.enabled = true;
        }
        
    }
}
