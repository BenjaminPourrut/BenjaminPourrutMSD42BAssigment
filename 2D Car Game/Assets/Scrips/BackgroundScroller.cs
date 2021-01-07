using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] float backgroundScrollSpeed = 0.02f;

    Material MyMaterial;

    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        MyMaterial = GetComponent<Renderer>().material;

        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        MyMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
