using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] GameObject character;
    public float y_cord;
    // Start is called before the first frame update
    void Start()
    {
        y_cord = this.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 charpos = character.transform.position;
        charpos[0] = character.transform.position.x+12f;
        charpos[1] = y_cord;
        charpos[2] = this.transform.position.z;

        this.transform.position = charpos;
       // Debug.Log(charpos);
    }
}
