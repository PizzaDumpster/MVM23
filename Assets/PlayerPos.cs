using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoopInMyPants
{
    public class PlayerPos : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.position = GameManager.instance.lastCheckPointPos;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
