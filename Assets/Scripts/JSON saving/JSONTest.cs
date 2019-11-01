using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class JSONTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("InsideStartJSON");
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
           FileStream readStream =  File.Open(Application.persistentDataPath + "/" + "text.txt", FileMode.Open);
            byte[] bytes = new byte[readStream.Length];
            readStream.Read(bytes, 0, bytes.Length);

            string data = Encoding.ASCII.GetString(bytes);

            PlayerInfo pInfo = JsonUtility.FromJson<PlayerInfo>(data);


            Debug.Log("FName: " + pInfo.firstName);
            Debug.Log("LName: " + pInfo.lastName);

            Debug.Log("Age: " + pInfo.age);
             
            Debug.Log("Height: " + pInfo.height);

            Debug.Log("Weight: " + pInfo.weight);

            readStream.Close();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            FileStream writeStream = null;
            if (!File.Exists(Application.persistentDataPath + "/" + "text.txt"))
                writeStream = File.Create(Application.persistentDataPath + "/" + "text.txt");
            else
                writeStream = File.Open(Application.persistentDataPath + "/"+ "text.txt", FileMode.Open);

            PlayerInfo pInfo = new PlayerInfo();

            pInfo.firstName = "Nicholas";
            pInfo.lastName = "Walker";
            pInfo.age = 26;
            pInfo.height = 60;
            pInfo.weight = 300;


            string data = JsonUtility.ToJson(pInfo);
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            writeStream.Write(bytes, 0, bytes.Length);
            writeStream.Close();

        }

    }

    void JsonLoad()
    {
        string data = PlayerPrefs.GetString("Info", "");

        PlayerInfo pInfo = JsonUtility.FromJson<PlayerInfo>(data);

        Debug.Log("FName: " + pInfo.firstName);
        Debug.Log("LName: " + pInfo.lastName);

        Debug.Log("Age: " + pInfo.age);

        Debug.Log("Height: " + pInfo.height);

        Debug.Log("Weight: " + pInfo.weight);
    }

    void JsonWrite()
    {
        PlayerInfo pInfo = new PlayerInfo();

        pInfo.firstName = "Nicholas";
        pInfo.lastName = "Walker";
        pInfo.age = 26;
        pInfo.height = 60;
        pInfo.weight = 300;


        string data = JsonUtility.ToJson(pInfo);

        PlayerPrefs.SetString("Info", data);
        PlayerPrefs.Save();
    }


}
