using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PoopInMyPants
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public Vector2 startCheckpointPos; 
        public Vector2 lastCheckPointPos;
        bool oneOff = true; 


        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }

        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(PlayerMovement.instance.playerHealth <= 0)
            {
                if (oneOff)
                {
                    PlayerMovement.instance.rb.transform.position = lastCheckPointPos;
                    oneOff = false; 
                }
            }
        }
    }
}
