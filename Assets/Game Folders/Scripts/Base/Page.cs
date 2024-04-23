using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public PageName namaPage;

    public void DisablePage()
    {
        gameObject.SetActive(false);
    }
}
