using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is where string references to all the event instances will go and instances will be initialized

[CreateAssetMenu(menuName = "SO/Audio/Events", fileName = "New Event Reference Sheet")]
public class EvenReferences : ScriptableObject
{
    //Setting inspector heading
    [Header("Attacks")]
    //Deeclaring shootinstance and inspector string variable
    [SerializeField] private string shootEventName = null;
    public FMOD.Studio.EventInstance shootInstance;

    //Setting inspector heading
    [Header("Non-Diagetic Audio")]
    //Declaring music instance and event string
    [SerializeField] private string musicEventName = null;
    public FMOD.Studio.EventInstance musicInstance;

    [SerializeField] private string gameOverMusicEventName = null;
    public FMOD.Studio.EventInstance gameOverMusicInstance;

    [SerializeField] private string pickUpHealthEventName = null;
    public FMOD.Studio.EventInstance pickUpHealthInstance;

    [SerializeField] private string pickUpSpeedEventName = null;
    public FMOD.Studio.EventInstance pickUpSpeedInstance;




    public void ShootInstance()
    {
        shootInstance = FMODUnity.RuntimeManager.CreateInstance("event:/" + shootEventName);
        Debug.Log(shootEventName);
    }

    public void MusicInstance()
    {
        musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/" + musicEventName);
        Debug.Log(musicEventName);
    }

    public void PickUpHealthInstance()
    {
        pickUpHealthInstance = FMODUnity.RuntimeManager.CreateInstance("event:/" + pickUpHealthEventName);
        Debug.Log(pickUpHealthEventName);
    }

    public void PickUpSpeedInstance()
    {
        pickUpSpeedInstance = FMODUnity.RuntimeManager.CreateInstance("event:/" + pickUpSpeedEventName);
        Debug.Log(pickUpSpeedEventName);
    }

    public void GameOverMusicInstance()
    {
        gameOverMusicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/" + gameOverMusicEventName);
        Debug.Log(gameOverMusicEventName);
    }



   

   
}
