using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCoroutine : MonoBehaviour

{
    // public List<GameObject>

    public List<string> listOfLines = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Conversation());
    }


    IEnumerator Conversation()
    {
        print(listOfLines[0]);
        yield return new WaitForSeconds(2);
        print(listOfLines[1]);
        yield return new WaitForSeconds(2);
        print(listOfLines[2]);
        yield return new WaitForSeconds(2);
        print(listOfLines[3]);
    }
}
