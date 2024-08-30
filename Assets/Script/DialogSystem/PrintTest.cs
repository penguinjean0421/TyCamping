using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintTest : MonoBehaviour
{
    TextAnimationPrinter printer;
    // Start is called before the first frame update
    void Start()
    {
        printer = GetComponent<TextAnimationPrinter>();
        StartCoroutine(printer.Print());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
