using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleObject : MonoBehaviour
{
    public GameObject obj;

    public void toggleObjActive()
    {
        obj.SetActive(!obj.activeSelf);
    }

}
