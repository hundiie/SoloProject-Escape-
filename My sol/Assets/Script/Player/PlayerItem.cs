using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private GameObject CAMERA;
    private GameObject Item;

    public LayerMask ItemMask;
    public Material HighlightMaterial;
    public GameObject CatchPosition;

    private PlayerInput _PlayerInput;

    private bool Light;

    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        CAMERA = GetComponent<PlayerManager>().CAMERA;
        Light = false;
    }
    private void Update()
    {
        if (!Light)
        {
            Item = Cameracenter();
        }
        if (Item != null)
        {
            if (!Light)
            {
                ItemLight(Item, true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Item.GetComponent<Item>().Player = gameObject; 
                    
                    Light = true;
                }
                
            }
            else if (Light)
            {
                CatchItem(Item);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    CastItem(Item);
                    Light = false;
                }
                
            }
        }
    }

    private void CatchItem(GameObject CatchItem)
    {
        CatchItem.GetComponent<Rigidbody>().useGravity = false;
        CatchItem.tag = "Untagged";
        CatchItem.transform.rotation = CAMERA.transform.rotation;
        CatchItem.transform.position = Vector3.MoveTowards(CatchItem.transform.position, CatchPosition.transform.position, 5f * Time.deltaTime);
        
    }

    private void CastItem(GameObject CastItem)
    {
        CastItem.GetComponent<Rigidbody>().useGravity = true;
        CastItem.tag = "Item";
        CastItem.GetComponent<Rigidbody>().AddRelativeForce(CAMERA.transform.forward + new Vector3(0, 10000, 30000) * Time.smoothDeltaTime, ForceMode.Force);
    }

    private Material SaveMaterial;
    private void ItemLight(GameObject ItemLight , bool Switch)
    {
        switch (Switch)
        {
            case true:
                {
                    SaveMaterial = ItemLight.GetComponent<Renderer>().material;
                    ItemLight.GetComponent<Renderer>().material = HighlightMaterial;
                    
                }
                break;
            case false:
                {
                    ItemLight.GetComponent<Renderer>().material = SaveMaterial;
                    SaveMaterial = null;
                }
                break;
        }
    }


    private GameObject SaveItem = null;
    private float delta;
    private GameObject Cameracenter()
    {
        delta += Time.deltaTime;
        RaycastHit hit;
        Debug.DrawRay(CAMERA.transform.position, CAMERA.transform.forward * 2, Color.blue);

        if (Physics.Raycast(CAMERA.transform.position, CAMERA.transform.forward, out hit))
        {
            //SaveItem = null;
            if (hit.collider.gameObject.tag == "Item")
            {
                float Distance = Vector3.Distance(transform.position, hit.transform.position);
                delta = 0;
                if (Distance <= 1.5f)
                {
                    SaveItem = hit.collider.gameObject;
                }
            }
            else if(delta >= 0.1f)
            {
                delta = 0;
                SaveItem = null;
            }
        }
        if (Item != null)
        {
            ItemLight(Item, false);
        }
        return SaveItem;
    }

}
