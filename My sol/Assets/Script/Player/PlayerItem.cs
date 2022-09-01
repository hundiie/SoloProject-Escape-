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
    public GameObject LayObject;


    private PlayerInput _PlayerInput;

    private bool Light;

    LineRenderer li;
    private void Awake()
    {
        li = LayObject.AddComponent<LineRenderer>();
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(0, 195, 255, 0.5f);
        li.positionCount = 2;
        // 레이저 굵기 표현
        li.startWidth = 0.01f;
        li.endWidth = 0.01f;



        _PlayerInput = GetComponent<PlayerInput>();
        CAMERA = GetComponent<PlayerManager>().CAMERA;
        Light = false;
    }
    private void Update()
    {
        li.SetPosition(0, LayObject.transform.position);
        li.SetPosition(1, LayObject.transform.position + (LayObject.transform.forward * 2));
        if (!Light)
        {
            Item = Cameracenter();
        }
        if (Item != null)
        {
            if (!Light)
            {
                ItemLight(Item, true);
                if (Input.GetKeyDown(KeyCode.Mouse0) || OVRInput.GetDown(OVRInput.Button.One))
                {
                    Item.GetComponent<Item>().Player = gameObject; 
                    
                    Light = true;
                }
                
            }
            else if (Light)
            {
                CatchItem(Item);
                //잡는 키
                if (Input.GetKeyDown(KeyCode.Mouse0) || OVRInput.GetDown(OVRInput.Button.One))
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
        Debug.DrawRay(LayObject.transform.position, LayObject.transform.forward * 2, Color.blue);

        if (Physics.Raycast(LayObject.transform.position, LayObject.transform.forward, out hit))
        {
            
            if (hit.collider.gameObject.tag == "Item")
            {
                float Distance = Vector3.Distance(transform.position, hit.transform.position);
                delta = 0;
                if (Distance <= 2.5f)
                {
                    li.SetPosition(1, hit.point);
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
