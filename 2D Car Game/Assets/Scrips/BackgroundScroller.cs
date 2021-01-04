using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] float backgroundScrollSpeed = 0.02f;

    Material MyOwnMaterial;

    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        MyOwnMaterial = GetComponent<Renderer>().material;

        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        MyOwnMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
