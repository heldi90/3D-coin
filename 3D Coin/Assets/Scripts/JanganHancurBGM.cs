using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanganHancurBGM : MonoBehaviour
{
    // Start is called before the first frame update
    private static JanganHancurBGM instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame

}
