using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class DataPlotter : MonoBehaviour {

    

    // Name of the input file, no extension
    public string inputfile;
     
    // List for holding data from CSV reader
    private List<Dictionary<string, object>> pointList;
 
    // Indices for columns to be assigned
    public int columnX = 0;
    public int columnY = 1;
    public int columnZ = 2;

    // Full column names
    public string xName;
    public string yName;
    public string zName;
 
    public float plotScale = 10;
 
    // The prefab for the data points that will be instantiated
    public GameObject PointPrefab;
 
    // Object which will contain instantiated prefabs in hiearchy
    public GameObject PointHolder;
    

        // BFB Additions
    
    // Graph Chosen Boolean
    bool graphLoaded;
    bool canScale = false;

    // TextMesh for Graph Pick
    public TextMesh graphText;

    public GameObject Bar;

    public Vector3 scaleChange = new Vector3 (0.2f, 0.2f, 0.2f);

    // Use this for initialization
    void Start () {
        graphText.text = "No Graph Loaded";

    }

    void Update ()
    {
        // Only 1 and 2 currently have Graphs. Just need to add the inputfile name and the columnX, Y and Z to make sure it matches numerical data.
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "iris";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 0;
            columnY = 1;
            columnZ = 2;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "rollercoaster2";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 3;
            columnY = 5;
            columnZ = 6;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 0;
            columnY = 1;
            columnZ = 2;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 0;
            columnY = 1;
            columnZ = 2;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 0;
            columnY = 1;
            columnZ = 2;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 0;
            columnY = 1;
            columnZ = 2;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 0;
            columnY = 1;
            columnZ = 2;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 0;
            columnY = 1;
            columnZ = 2;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            inputfile = "";
            graphLoaded = true;
            graphText.text = "" + inputfile;
            columnX = 0;
            columnY = 1;
            columnZ = 2;

            PointHolder.transform.localScale = new Vector3 (1f, 1f, 1f);
            Bar.transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Space) && graphLoaded)
        {
            canScale = true;
            graphLoaded = false;
            graphText.text = "No Graph Loaded";

            // Set pointlist to results of function Reader with argument inputfile
            pointList = CSVReader.Read(inputfile);
    
            //Log to console
            Debug.Log(pointList);
    
            // Declare list of strings, fill with keys (column names)
            List<string> columnList = new List<string>(pointList[1].Keys);
    
            // Print number of keys (using .count)
            Debug.Log("There are " + columnList.Count + " columns in the CSV");
    
            foreach (string key in columnList)
                Debug.Log("Column name is " + key);
    
            // Assign column name from columnList to Name variables
            xName = columnList[columnX];
            yName = columnList[columnY];
            zName = columnList[columnZ];
    
            // Get maxes of each axis
            float xMax = FindMaxValue(xName);
            float yMax = FindMaxValue(yName);
            float zMax = FindMaxValue(zName);
    
            // Get minimums of each axis
            float xMin = FindMinValue(xName);
            float yMin = FindMinValue(yName);
            float zMin = FindMinValue(zName);
    
            
            //Loop through Pointlist
            for (var i = 0; i < pointList.Count; i++)
            {
                // Get value in poinList at ith "row", in "column" Name, normalize
                float x = 
                    (System.Convert.ToSingle(pointList[i][xName]) - xMin) 
                    / (xMax - xMin);
    
                float y = 
                    (System.Convert.ToSingle(pointList[i][yName]) - yMin) 
                    / (yMax - yMin);
    
                float z = 
                    (System.Convert.ToSingle(pointList[i][zName]) - zMin) 
                    / (zMax - zMin);
    
    
                // Instantiate as gameobject variable so that it can be manipulated within loop
                GameObject dataPoint = Instantiate(
                        PointPrefab, 
                        new Vector3(x, y, z)* plotScale, 
                        Quaternion.identity);
                            
                // Make child of PointHolder object, to keep points within container in hiearchy
                dataPoint.transform.parent = PointHolder.transform;
    
                // Assigns original values to dataPointName
                string dataPointName = 
                    pointList[i][xName] + " "
                    + pointList[i][yName] + " "
                    + pointList[i][zName];
    
                // Assigns name to the prefab
                dataPoint.transform.name = dataPointName;
    
                // Gets material color and sets it to a new RGB color we define
                dataPoint.GetComponent<Renderer>().material.color = 
                    new Color(x,y,z, 1.0f);
            }
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            foreach(Transform child in PointHolder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        // Scaling tool

        // Scale UP
        if(Input.GetKeyDown(KeyCode.RightBracket) && canScale)
        {
            if(PointHolder.transform.localScale.y < 3)
            {
                PointHolder.transform.localScale += scaleChange;
                Bar.transform.localScale += scaleChange;
                foreach(Transform child in PointHolder.transform)
                {
                    transform.localScale += scaleChange;
                }
            }
        }

        // Scale DOWN
        if(Input.GetKeyDown(KeyCode.LeftBracket) && canScale)
        {
            if(PointHolder.transform.localScale.y > 1)
            {
                PointHolder.transform.localScale -= scaleChange;
                Bar.transform.localScale -= scaleChange;
                foreach(Transform child in PointHolder.transform)
                {
                    transform.localScale -= scaleChange;
                }
            }
        }
    }
    private float FindMaxValue(string columnName)
    {
        //set initial value to first value
        float maxValue = Convert.ToSingle(pointList[0][columnName]);
 
        //Loop through Dictionary, overwrite existing maxValue if new value is larger
        for (var i = 0; i < pointList.Count; i++)
        {
            if (maxValue < Convert.ToSingle(pointList[i][columnName]))
                maxValue = Convert.ToSingle(pointList[i][columnName]);
        }
 
        //Spit out the max value
        return maxValue;
    }
 
    private float FindMinValue(string columnName)
    {
 
        float minValue = Convert.ToSingle(pointList[0][columnName]);
 
        //Loop through Dictionary, overwrite existing minValue if new value is smaller
        for (var i = 0; i < pointList.Count; i++)
        {
            if (Convert.ToSingle(pointList[i][columnName]) < minValue)
                minValue = Convert.ToSingle(pointList[i][columnName]);
        }
 
        return minValue;
    }
 
}