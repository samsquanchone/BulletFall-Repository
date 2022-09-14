using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{

    private Dictionary<string, UnityEvent> eventDictionary; //Declaring Dictionary with keypair types of string(eventName) and UnityEvent

    private static EventManager eventManager; //Will be used to populate dictionary

    public static EventManager instance //Will be used to start and stop listening and as well as for triggering events
    {
        get
        {
            if (!eventManager) // If there is no eventManager reference, findObjectOftype event manager, if still no reference throw error, else if reference found initialize dictionary
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager; //Return reference to eventManager
        }
    }

    void Init()
    {
        //Initialize dictionary
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null; //Make thisEvent instance null
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) //Find parameter values for eventDictionary, then add listener to thisEvent
        {
            thisEvent.AddListener(listener);
        }
        else //If no value found from dictionary, then create an event and add listener, and add instance to dictionary
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) return; //Return if no eventMANAGER
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) //Get values from dictionary then remove current listner from thisEvent
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null; //Make this eventNull
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) //Get event from dictionray and then invoke its methods/functions
        {
            thisEvent.Invoke();
        }
    }
}