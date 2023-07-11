using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomTextGen : MonoBehaviour
{
    protected List<Class> namese = new List<Class>();
    [Header("Text Input / Output")]
    public TextMeshProUGUI text;
    public TextAsset wordData;
    protected int lines;
    // Start is called before the first frame update
    void Start()
    {
        

        string[] data = wordData.text.Split(new char[] { '\n'} );

        // count the amount of rows in the txt file
        lines = 0;
        foreach (var word in data)
        {
            lines +=1;
        }


        System.Random rand = new System.Random();
        Debug.Log("No. of lines: " + lines);
        int number = rand.Next(1,lines-1);
        
        List<string> names = new List<string>();

        string[] row = data[number].Split(new char[] { ',' } );

        Class n = new Class();
        n.name = row[0];

        namese.Add(n);

        Debug.Log(n.name);

        text.text = n.name;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
