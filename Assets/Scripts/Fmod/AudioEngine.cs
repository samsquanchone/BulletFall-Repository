using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEngine : MonoBehaviour
{

    public EvenReferences fmodEventReferences;
    public PlayerData playerData;
    private UnityAction someListener;

    //Initlize initial unityAction/Listener and calls StartGameMusic
    private void Awake()
    {
        someListener = new UnityAction(SomeFunction);
        StartGameMusic();
   
        
    }

    //Start listening for events
    void OnEnable()
    {
        EventManager.StartListening("test", someListener);
        EventManager.StartListening("FireGunFmodEvent", FireGunEvent);
        EventManager.StartListening("StartGameMusic", StartGameMusic);
        EventManager.StartListening("StopGameMusic", StopGameMusic);
        EventManager.StartListening("PickUpHealth", PickUpHealthEvent);
        EventManager.StartListening("PickUpSpeed", PickUpSpeedEvent);
        EventManager.StartListening("GameOverMusic", GameOverMusic);
    }

    //Disable listeners for events (key for avoiding data leaks)
    void OnDisable()
    {
        EventManager.StopListening("test", someListener);
        EventManager.StopListening("FireGunFmodEvent", FireGunEvent);
        EventManager.StopListening("StartGameMusic", StartGameMusic);
        EventManager.StopListening("StopGameMusic", StopGameMusic);
        EventManager.StopListening("PickUpHealth", PickUpHealthEvent);
        EventManager.StopListening("PickUpSpeed", PickUpSpeedEvent);
        EventManager.StopListening("GameOverMusic", GameOverMusic);
    }

    private void SomeFunction()
    {
        Debug.Log("Some Function was called!");
    }

    //Event for oneshot fireGun, creates an instance of Fmod event to use, then startsEvent and then releases it for memory 
    private void FireGunEvent()
    {
        Debug.Log("Boom");
        fmodEventReferences.ShootInstance();
        fmodEventReferences.shootInstance.start();
        fmodEventReferences.shootInstance.release();
        
    }

    //Creates instance of music looping fmod event and then starts it
    private void StartGameMusic()
    {
        fmodEventReferences.MusicInstance();
        fmodEventReferences.musicInstance.start();
    }

    //Stops game music looping fmod event (with fade out) and releases it from memory
    private void StopGameMusic()
    {
        fmodEventReferences.musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        fmodEventReferences.musicInstance.release();
    }

    private void PickUpHealthEvent()
    {
        fmodEventReferences.PickUpHealthInstance();
        fmodEventReferences.pickUpHealthInstance.start();
        fmodEventReferences.pickUpHealthInstance.release();
    }

    private void PickUpSpeedEvent()
    {
        fmodEventReferences.PickUpSpeedInstance();
        fmodEventReferences.pickUpSpeedInstance.start();
        fmodEventReferences.pickUpSpeedInstance.release();
    }

    private void GameOverMusic()
    {
        fmodEventReferences.GameOverMusicInstance();
        fmodEventReferences.gameOverMusicInstance.start();
        fmodEventReferences.gameOverMusicInstance.release();
    }
    
}
