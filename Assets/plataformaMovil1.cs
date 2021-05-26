using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaMovil1 : MonoBehaviour
{
    public GameObject ObjetoAmover;
    public Transform Start1;
    public Transform Finish;

    public float Velocidad;
    private Vector3 MoverHacia;



    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = Finish.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, Velocidad * Time.deltaTime);
    
        if(ObjetoAmover.transform.position == Finish.position)
        {
            MoverHacia = Start1.position;
        }
        if(ObjetoAmover.transform.position == Start1.position)
        {
            MoverHacia = Finish.position;
        }
    }
}
