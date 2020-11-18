using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class grapplinghook : MainMenu 
{
    // Start is called before the first frame update
    DistanceJoint2D joint;
    Vector3 targetpos;
    RaycastHit2D hit;
   [SerializeField] GameObject hing;
   [SerializeField]  float distance = 1000.0f;
    public LayerMask mask;
    public LineRenderer line;
    [SerializeField] public float step ;
    [SerializeField] GameObject healthbar;
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject blood;
    [SerializeField] GameObject scoreTxt;
    [SerializeField] List<GameObject> backgrounds;
    public float health;
    public int score;
    public int coins;
    public int dist;
   
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        //  joint.enabled = false;
        //line.enabled = false;
        healthbar.transform.localScale = new Vector3(1f, 1f);
        health = 100;
        score = 0;
        coins = 0;
        dist = 0;
        for(int i=0;i<3;i++)
        backgrounds[i].gameObject.SetActive(false);
        
        backgrounds[playBackground].gameObject.SetActive(true);
        

    }
  

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
     
        health -= 10;
        if (health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Debug.Log(health);
        healthbar.transform.localScale = new Vector3(health / 100,1f);
        var contact = collision.contacts[0];
        Instantiate(blood, contact.point,Quaternion.FromToRotation(Vector3.up,contact.normal));
       // Destroy(blood);
       
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Coin")
        {
            coins++;
            //score+=1000;
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {
       // Debug.Log(health);
       // Debug.Log(coins);
        Debug.Log(score);
        scoreTxt.GetComponent<TextMeshProUGUI>().text = score.ToString();
       // Debug.Log(dist);
        if((int) transform.position.x > dist)
        {
            dist = (int)transform.position.x;
            score = dist + 50 * coins;
        }
       
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            
         //   Debug.Log("yes");
            // targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetdir = new Vector2(.5f,1f);
           // Debug.Log(targetpos);
            targetpos = hing.transform.position;
            targetpos.z = 0;
            hit = Physics2D.Raycast(transform.position, targetdir,distance,mask);

//            Debug.Log(hit.point);
  //          Debug.Log(hit.collider.gameObject);
            
            if(hit.collider!=null  && hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
            {
                joint.enabled = true;
              //  joint.connectedBody = hing.GetComponent<Rigidbody2D>();
            //     joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
               joint.connectedAnchor = hit.point /* - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y)*/;
              joint.distance = Vector2.Distance(transform.position, hit.point);
              //  joint.distance = 2;
            //    Debug.Log(hit.point);
              //  Debug.Log(joint.connectedBody);
                line.enabled = true;
              line.SetPosition(0, transform.position);
             line.SetPosition(1, hit.point);
            }
            
        }
        if(Input.GetKey(KeyCode.W))
        {
          //  Debug.Log(joint.distance);
            line.SetPosition(0, transform.position);
            if (joint.distance > 4f) joint.distance -= step;
            else
            {
               
                //line.enabled = false;
                //joint.enabled = false;
            }

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
           // Debug.Log("yes2");
           joint.enabled = false;
            line.enabled = false;
        }
    }
}
