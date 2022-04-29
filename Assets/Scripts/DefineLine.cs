using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineLine : MonoBehaviour
{
    // Start is called before the first frame update



    enum Rows
    {
        FirstRow=1,
        SecondRow,
        ThirdRow,
        FourthRow,
    }
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rows[] rows=new Rows[4];
        rows[0]=Rows.FirstRow;
        rows[1]=Rows.SecondRow;
        rows[2]=Rows.ThirdRow;
        rows[3]=Rows.FourthRow;
        var parent = GetComponentInParent<UnitLine>();

        foreach (var row in rows)
        {
           
            if (collision.name == row.ToString())
            {
                if (parent != null)
                {
                    parent.line = (int)row;
                    parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, (float)parent.line / 100); //Исправление визуального бага (наложение спрайтов)
                }

            }

        }
        if (parent.tag == "Cowboys")
        {
            GetComponentInParent<Cowboys>().line = parent.line;
            parent.gameObject.layer = parent.line + 5;
        }

        if (parent.tag == "Robber")
        {
            GetComponentInParent<Robber>().line = parent.line;

        }
            

    }
}
