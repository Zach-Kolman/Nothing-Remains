using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    //public TMP_InputField saveName;
    //public GameObject loadButtonPrefabs;
    //public IEnumerable loadArea;

    //public void OnSave()
    //{
    //    SerializationManager.Save(saveName.text, SaveData.current);
    //}

    //public string[] saveFiles;
    //public void GetLoadFile()
    //{
    //    if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
    //    {
    //        Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
    //    }

    //    saveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves");
    //}

    //public void ShowLoadScreen()
    //{
    //    GetLoadFile();

    //    foreach(Transform button in loadArea)
    //    {
    //        Destroy(button.gameObject);
    //    }

    //    for(int i = 0; i < saveFiles.Length; i++)
    //    {
    //        GameObject buttonObject = Instantiate(loadButtonPrefabs);
    //        buttonObject.transform.SetParent(loadArea.transform, false);

    //        var index = i;
    //        buttonObject.GetComponent<Button>().onClick.AddListener(() =>
    //        {

    //        });
    //    }
    //}
}
