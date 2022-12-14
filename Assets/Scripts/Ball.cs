using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Ball : MonoBehaviour
{
    TrailRenderer TrailRenderer;

    public Text Text;
    public Text yText;
    public Text zText;

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

    float[] traz4_x;
    float[] traz4_y;
    float[] traz4_z;

    float[] traz5_x;
    float[] traz5_y;
    float[] traz5_z;

    int a;
    int count;

    float ballspeed;
    float w1, w2, w3 = 0;
    float a1 = 1;
    float a2 = 1;
    float a3 = 1;

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

        traz4_x = new float[10000];
        traz4_y = new float[10000];
        traz4_z = new float[10000];

        traz5_x = new float[10000];
        traz5_y = new float[10000];
        traz5_z = new float[10000];

        onoff = true;
        List<Dictionary<string, object>> data = CSVReader.Read("people");

        for (var i = 0; i < data.Count; i++)
        {
            traz1_x[i] = float.Parse(data[i]["traz1_x"].ToString());
            traz1_y[i] = float.Parse(data[i]["traz1_y"].ToString());
            traz1_z[i] = float.Parse(data[i]["traz1_z"].ToString());
            
            traz2_x[i] = float.Parse(data[i]["traz2_x"].ToString());
            traz2_y[i] = float.Parse(data[i]["traz2_y"].ToString());
            traz2_z[i] = float.Parse(data[i]["traz2_z"].ToString());

            traz3_x[i] = float.Parse(data[i]["traz3_x"].ToString());
            traz3_y[i] = float.Parse(data[i]["traz3_y"].ToString());
            traz3_z[i] = float.Parse(data[i]["traz3_z"].ToString());
            
            traz4_x[i] = float.Parse(data[i]["traz4_x"].ToString());
            traz4_y[i] = float.Parse(data[i]["traz4_y"].ToString());
            traz4_z[i] = float.Parse(data[i]["traz4_z"].ToString());

            traz5_x[i] = float.Parse(data[i]["traz5_x"].ToString());
            traz5_y[i] = float.Parse(data[i]["traz5_y"].ToString());
            traz5_z[i] = float.Parse(data[i]["traz5_z"].ToString());
            
        }
            
        posx = traz1_x;
        posy = traz1_y;
        posz = traz1_z;
        w1 = 115;
        w2 = -129;
        w3 = -88;

        count = data.Count;

    }

    // Update is called once per frame
    void Update()
    {
        ballspeed = float.Parse(Text.text);
        a2 = float.Parse(zText.text);
        a3 = float.Parse(yText.text);


        if (Input.GetKeyDown(KeyCode.P))
        {
            playball();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TrailRenderer.time = 0;
            this.transform.position = new Vector3(0, 1.5f * a2, 0.5f * a3);
        }
    }

    public void TRAJMODI1()
    {
        //curveball
        posx = traz1_x;
        posy = traz1_y;
        posz = traz1_z;
        w1 = 122;
        w2 = 20;
        w3 = -195;
    }
        
    public void TRAJMODI2()
    {
        posx = traz2_x;
        posy = traz2_y;
        posz = traz2_z;
        w1 = 195;
        w2 = 12;
        w3 = 8;
    }

    public void TRAJMODI3()
    {
        posx = traz3_x;
        posy = traz3_y;
        posz = traz3_z;
        w1 = 51;
        w2 = 26;
        w3 = -52;
    }

    public void TRAJMODI4()
    {
        posx = traz4_x;
        posy = traz4_y;
        posz = traz4_z;
        w1 = 166;
        w2 = -166;
        w3 = 0;
    }

    public void TRAJMODI5()
    {
        posx = traz5_x;
        posy = traz5_y;
        posz = traz5_z;
        w1 = 133;
        w2 = -133;
        w3 = 1;
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
        pos = new Vector3(posx[a]*a1, posz[a]*a2, posy[a]*a3);
        transform.position = Vector3.MoveTowards(transform.position, pos, ballspeed);
        this.transform.Rotate(w1, w2, w3);
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
