using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransport : MonoBehaviour
{
    public GameObject player;
    public GameObject reticle;
    public Color targetColor;
    private Color initial;
    private float timer;
    private bool hasFocus = false;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        hasFocus = false;
        meshRenderer=this.GetComponent<MeshRenderer>();
        initial = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFocus)
        {
            meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, targetColor,Time.deltaTime/2f);
            timer += Time.deltaTime;
            if (timer > 2)
            {
                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
                gameObject.SetActive(false);
            }
        }
    }

    public void teletransport()
    {
        player.transform.position = new Vector3(transform.position.x,player.transform.position.y,transform.position.z);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public void teletransportTime(bool selected)
    {
        hasFocus = selected;
        if (!hasFocus)
        {
            timer = 0;
            meshRenderer.material.color = initial;
        }
    }

}
