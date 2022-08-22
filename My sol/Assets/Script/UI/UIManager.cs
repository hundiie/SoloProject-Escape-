using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Foot;
    private GameObject[] Direction = new GameObject[2];

    public GameObject Die;
    private Image _Image;

    private void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            Direction[i] = Foot.transform.GetChild(i).gameObject;
        }
        _Image = Die.transform.GetChild(0).GetComponent<Image>();
    }

    public void Setway(Transform trans, bool direction, Color COLOR)
    {
        Vector3 v3 = new Vector3(trans.position.x, trans.position.y - 0.998f, trans.position.z);
        if (direction)
        {
            Direction[0].transform.GetChild(0).gameObject.GetComponent<RawImage>().color = COLOR;
            Instantiate(Direction[0], v3, trans.rotation);
        }
        else
        {
            Direction[1].transform.GetChild(0).gameObject.GetComponent<RawImage>().color = COLOR;
            Instantiate(Direction[1], v3, trans.rotation);
        }
    }

    public void PlayRed()
    {
        Debug.Log("µé¾î¿È0!");
        StartCoroutine(_PlayRed());
    }

    private IEnumerator _PlayRed()
    {
        Debug.Log("µé¾î¿È2!");
        while (true)
        {
            Debug.Log("µé¾î¿È3!");
            Color color = _Image.color;
            color.a += 0.1f * Time.deltaTime;
            if (_Image.color.a > 255)
            {
                break;
            }
            _Image.color = color;
        }
        Debug.Log("µé¾î¿È4!");
        yield return null;
    }
}
