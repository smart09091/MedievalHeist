using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Infrastructure
{
    public class LevelPersistence : MonoBehaviour
    {
        public static void saveData(LevelData data)
        {
            string name = data.GetType().Name;
            PlayerPrefs.SetInt("level" + name, data.level);
        }



        public static LevelData getData()
        {
            LevelData data = new LevelData();
            string name = data.GetType().Name;
            data.level = PlayerPrefs.GetInt("level" + name, 0);
            return data;
        }
    }
}
