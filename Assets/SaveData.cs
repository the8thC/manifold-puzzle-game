using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SaveData 
{
[Serializable]
    class SaveData 
    {
        public float positionX  {get; set;}
        public float positionY {get; set;}
        public float positionZ {get; set;}
        public string saveName;
    }
}

