using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Punching : MonoBehaviour
{

    public static Punching instance;
    public GameObject player;
    public GameObject villain;
    public Rigidbody mit;
    public ParticleSystem poof;
    public Text killText;
    public AudioSource killSound;
    public GameObject ps;

    SphereCollider col;
    private bool punching = false;
    private int kills;

    private void Awake()
    {
        kills = 0;
        killSound = GetComponent<AudioSource>();
        col = GetComponentInChildren<SphereCollider>();
        villain = GameObject.FindGameObjectWithTag("Villain");
    }
    void Update()
    {
        var orgScale = transform.localScale;
        if (!punching && Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Punch(0.5f, 60.0f, transform.forward));
        }
    }
    IEnumerator Punch(float time, float distance, Vector3 direction)
    {
        punching = true;
        var timer = 0.0f;
        var orgPos = transform.position;
        var orgRot = transform.rotation;
        var orgScale = transform.localScale;

        transform.localScale += new Vector3(2.0F, 2.0f, 2.0f);
        transform.Rotate(-15.0f, 0.0f, 0f);

        direction.Normalize();
        Debug.Log("Above the loop");
        while (timer <= time)
        {
            Debug.Log("----");
            transform.position = orgPos + (Mathf.Sin(timer / time * Mathf.PI) + 1.0f) * direction; //move mit forward
            yield return null;
            timer += Time.deltaTime;
        }
        transform.position = orgPos;
        transform.rotation = orgRot;
        transform.localScale = orgScale;
        punching = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Villain"))
        {
            other.gameObject.SetActive(false);
            KillPoint(); //increase kill num
      
        }
    }
    public void KillPoint()
    {
        kills++;
        killText.text = "KILLS: " + kills.ToString(); //display updated score
        killSound.Play();
        Instantiate(ps);
    }

}