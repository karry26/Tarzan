using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createobstacle : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField] private List<Transform>  levelpart;
    [SerializeField] private Transform levelpart_start;
    [SerializeField] private GameObject player;
    private const float min_dis = 60f;
    private Vector3 lastendpos;
    private void Awake()
    {
        lastendpos = levelpart_start.Find("endpoint").position;
        spawnlevel();
        spawnlevel();



    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastendpos) < min_dis)
        {
            spawnlevel();
        }
    }
    private void spawnlevel()
    {
        Transform lastlevelparttransform = spawnlevel(lastendpos);
        lastendpos = lastlevelparttransform.Find("endpoint").position;
    }
    private Transform spawnlevel(Vector3 spawnpos)
    {
        return Instantiate(levelpart[Random.Range(0,levelpart.Count)], spawnpos, Quaternion.identity);
    }
}
