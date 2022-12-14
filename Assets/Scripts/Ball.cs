using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Ball : MonoBehaviour
{
    TrailRenderer TrailRenderer;

    public Text Text;

    Vector3 pos;
    bool onoff;

    float[] posx;
    float[] posy;
    float[] posz;

    float[] traz1_x;
    float[] traz1_y;
    float[] traz1_z;

    float[] traz2_x;
    float[] traz2_y;
    float[] traz2_z;

    float[] traz3_x;
    float[] traz3_y;
    float[] traz3_z;

    int a;
    int count;

    float ballspeed;

    // Start is called before the first frame update
    void Start()
    {
        TrailRenderer = GetComponent<TrailRenderer>();

        pos = Vector3.zero;
        posx = new float[10000];
        posy = new float[10000];
        posz = new float[10000];

        traz1_x = new float[10000];
        traz1_y = new float[10000];
        traz1_z = new float[10000];

        traz2_x = new float[10000];
        traz2_y = new float[10000];
        traz2_z = new float[10000];

        traz3_x = new float[10000];
        traz3_y = new float[10000];
        traz3_z = new float[10000];

        onoff = true;
        List<Dictionary<string, object>> data = CSVReader.Read("people");

        for (var i = 0; i < data.Count; i++)
        {
            traz1_x[i] = float.Parse(data[i]["traz1_x"].ToString());
            traz1_y[i] = float.Parse(data[i]["traz1_y"].ToString());
            traz1_z[i] = float.Parse(data[i]["traz1_z"].ToString());
            /*
            traz2_x[i] = float.Parse(data[i]["traz2_x"].ToString());
            traz2_y[i] = float.Parse(data[i]["traz2_y"].ToString());
            traz2_z[i] = float.Parse(data[i]["traz2_z"].ToString());

            traz3_x[i] = float.Parse(data[i]["traz3_x"].ToString());
            traz3_y[i] = float.Parse(data[i]["traz3_y"].ToString());
            traz3_z[i] = float.Parse(data[i]["traz3_z"].ToString());
            */
        }
            
        posx = traz1_x;
        posy = traz1_y;
        posz = traz1_z;

        count = data.Count;

    }

    // Update is called once per frame
    void Update()
    {
        ballspeed = float.Parse(Text.text);
        

        if (Input.GetKeyDown(KeyCode.P))
        {
            playball();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TrailRenderer.time = 0;
            this.transform.position = new Vector3(0, 1f, 3f);
        }
    }

    public void TRAJMODI1()
    {
        posx = traz1_x;
        posy = traz1_y;
        posz = traz1_z;
    }
        
    public void TRAJMODI2()
    {
        posx = traz2_x;
        posy = traz2_y;
        posz = traz2_z;
    }

    public void TRAJMODI3()
    {
        posx = traz3_x;
        posy = traz3_y;
        posz = traz3_z;
    }

    public void playball()
    {
        StopAllCoroutines();
        a = 0;
        onoff = true;
        TrailRenderer.time = 0;
        StartCoroutine(WaitAndPrint());
    }

    public IEnumerator WaitAndPrint()
    {
        while (onoff)
        {
            yield return new WaitForSeconds(ballspeed); //waitTime 만큼 딜레이후 다음 코드가 실행된다.
            Shot();
            //While문을 빠져 나가지 못하여 waitTime마다 Shot함수를 반복실행 됩니다.
        }
    }

    public void Shot()
    {
        pos = new Vector3(posx[a], posy[a]*2, posz[a]*2);
        transform.position = Vector3.MoveTowards(transform.position, pos, ballspeed);
        transform.position = pos;

        if (a == 1)
        {
            TrailRenderer.time = 1000;
        }

        if (a < count - 1)
            a++;
        else 
        { 
            onoff = false;
            StopCoroutine(WaitAndPrint());
        }
    }  
}
