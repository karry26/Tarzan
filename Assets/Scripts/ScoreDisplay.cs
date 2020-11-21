using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreDisplay : grapplinghook
{
    // Start is called before the first frame update
    [SerializeField] GameObject scoretxt;
    [SerializeField] GameObject coinTxt;
    [SerializeField] GameObject distanceTxt;
    void Start()
    {
        dist= dist/9;
        scoretxt.GetComponent<TextMeshProUGUI>().text = score.ToString();
        coinTxt.GetComponent<TextMeshProUGUI>().text = coins.ToString();
        distanceTxt.GetComponent<TextMeshProUGUI>().text = dist.ToString()+" m ";
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
