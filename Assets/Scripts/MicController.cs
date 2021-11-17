using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicController : MonoBehaviour
{
    
    /*
    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity;
    public bool flew;

    public void Awake()
    {
        //init microphone input
        if (Microphone.devices.Length>0){
            microphoneInput = Microphone.Start(Microphone.devices[0],true,999,44100);
            microphoneInitialized = true;
        }
    }

    public void Update()
    {
        //get mic volume
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null)-(dec+1); // null means the first microphone
        microphoneInput.GetData(waveData, micPosition);
	
        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++) {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak) {
                levelMax = wavePeak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));
        
        
        
        if (level>sensitivity && !flew){
		    Fly();
		    flew = true
	    }
	    if (level<sensitivity && flew)
		    flew = false;
	    }
        
    }

    */
 
        public float MicLoudness;
 
        private string _device;
     
        //mic initialization
        void InitMic(){
            _device ??= Microphone.devices[0];
            _clipRecord = GetComponent<AudioClip>(); 
            _clipRecord = Microphone.Start(_device, true, 999, 44100);
        }
     
        void StopMicrophone()
        {
            Microphone.End(_device);
        }
     
 
        private AudioClip _clipRecord;
        int _sampleWindow = 128;
     
        //get data from microphone into audioclip
        float  LevelMax()
        {
            float levelMax = 0;
            float[] waveData = new float[_sampleWindow];
            int micPosition = Microphone.GetPosition(null)-(_sampleWindow+1); 
            if (micPosition < 0) return 0;
            _clipRecord.GetData(waveData, micPosition);
            
            // get the largest value within the 128 samples
            
            for (int i = 0; i < _sampleWindow; i++) {
                float wavePeak = waveData[i] * waveData[i];
                if (levelMax < wavePeak) {
                    levelMax = wavePeak;
                }
            }
            return levelMax;
        }
     
     
     
        void Update()
        {
            // levelMax equals to the highest normalized value power 2, a small number because < 1
            // pass the value to a static var so we can access it from anywhere
            MicLoudness = LevelMax ();
            //Debug.Log(MicLoudness);
 
        }
     
        bool _isInitialized;
        // start mic when scene starts
        void OnEnable()
        {
            InitMic();
            _isInitialized=true;
        }
     
        //stop mic when loading a new level or quit application
        void OnDisable()
        {
            StopMicrophone();
        }
     
        void OnDestroy()
        {
            StopMicrophone();
        }
     
     
        // make sure the mic gets started & stopped when application gets focused
        void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                //Debug.Log("Focus");

                if (!_isInitialized)
                {
                    //Debug.Log("Init Mic");
                    InitMic();
                    _isInitialized = true;
                }
            }

            if (!focus)
            {
                //Debug.Log("Pause");
                StopMicrophone();
                //Debug.Log("Stop Mic");
                _isInitialized = false;

            }
        }
 
}
