using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Infrastructure
{
    public class ScorePersistence : MonoBehaviour
    {

        public static void saveData(ScoreData data)
        {
            string name = data.GetType().Name;
            //  PlayerPrefs.SetInt("score" + name, data.score);
            PlayerPrefs.SetInt("highscore" + name, data.highscore);
        }



        public static ScoreData getData()
        {
            ScoreData data = new ScoreData();
            string name = data.GetType().Name;
            // data.score = PlayerPrefs.GetInt("score" + name, 0);
            data.highscore = PlayerPrefs.GetInt("highscore" + name, 0);
            return data;
        }
    }
}
