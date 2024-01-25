using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClipRefSo audioClipRefSO;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {

        Instance = this;
     
    }
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnPairedClickers += PlaySuccesfulPairClick;
        Player.Instance.OnClickCliker += PlayFirstClick;
        Player.Instance.OnEmptyCliker += PlayEmptyClick;

       
    }

    private void PlayLevelComplete(object sender, EventArgs e)
    {
      
        AudioSource.PlayClipAtPoint(audioClipRefSO.LevelComplete, Camera.main.transform.position,0.6f);
    }

    private void PlayGameOver(object sender, EventArgs e)
    {
       
        AudioSource.PlayClipAtPoint(audioClipRefSO.GameOver, Camera.main.transform.position,0.6f);
    }

    private void PlayEmptyClick(object sender, EventArgs e)
    {
        AudioSource.PlayClipAtPoint(audioClipRefSO.EmptyClick, Camera.main.transform.position,0.4f);
    }

    private void PlayFirstClick(object sender, EventArgs e)
    {
       
        AudioSource.PlayClipAtPoint(audioClipRefSO.FirstClick, Camera.main.transform.position,0.2f);
    }

    private void PlaySuccesfulPairClick(object sender, Player.OnSelectedPairedClickersEventArgs e)
    {
       
        AudioSource.PlayClipAtPoint(audioClipRefSO.SuccesfulPairClick, Camera.main.transform.position,0.2f);
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }




    
}
