using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reading
{
    public float temperature;
    public float humidity;
    public float pressure;

    public Reading(float t, float h, float p)
    {
        temperature = t;
        humidity = h;
        pressure = p;
    }
}

public class DataExercise : MonoBehaviour
{
    private List<string> words;
    private Dictionary<float, Reading> sensorData;
    public GameObject graphBar;
    private LineRenderer lr;
    
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        //ListExploration();
        sensorData = new Dictionary<float, Reading>();
        StartCoroutine(SensorReading());
    }

    IEnumerator SensorReading()
    {
        while (sensorData.Count < 10)
        {
            float time = Time.realtimeSinceStartup;
            sensorData.Add(time, new Reading(Random.value, Random.value, Random.value));

            //Reading r = sensorData[time];
            //Debug.Log("Reading: " + r.temperature + ", " + r.pressure + ", " + r.humidity);
            yield return new WaitForSeconds(Random.value);
        }

        GenerateGraph();
    }

    void GenerateGraph()
    {
        Vector3[] positions = new Vector3[sensorData.Count];
        
        int count = 0;
        foreach (KeyValuePair<float,Reading> dataPoint in sensorData)
        {
            float barHeight = dataPoint.Value.temperature * 2f;
            Vector3 p = new Vector3(dataPoint.Key * 2.1f, barHeight, 0);
            GameObject go = Instantiate(graphBar, p, Quaternion.identity);
            positions[count] = p;
            count++;
            //go.transform.localScale = new Vector3(1.0f, barHeight, 1.0f);
        }
        
        lr.positionCount = sensorData.Count;
        lr.SetPositions(positions);
    }
    
    void ListExploration()
    {
        words = new List<string>();
        Debug.Log(words.Capacity);

        for (int i = 0; i < 5; i++)
        {
            words.Add("Item " + i);
        }
        
        Debug.Log(words.Capacity);
        
        //words.RemoveRange(0, 10000);
        //words.Clear();
        words.TrimExcess();
        Debug.Log(words.Capacity);
        words.Add("new item");
        Debug.Log(words.Capacity);

        //Debug.Log(words[0]); // David
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
