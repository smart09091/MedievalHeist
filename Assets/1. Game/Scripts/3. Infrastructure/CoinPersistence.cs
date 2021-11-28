using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Infrastructure
{
    public class CoinPersistence : MonoBehaviour
    {
        public static void saveData(CoinData data)
        {
            string name = data.GetType().Name;
            // PlayerPrefs.SetFloat("levelCoin" + name, data.levelCoin);
            PlayerPrefs.SetFloat("totalCoin" + name, data.totalCoin);
        }



        public static CoinData getData()
        {
            CoinData data = new CoinData();
            string name = data.GetType().Name;
            //   data.levelCoin =PlayerPrefs.GetFloat("levelCoin" + name, 0);
            data.totalCoin = PlayerPrefs.GetFloat("totalCoin" + name, 0);
            return data;
        }
    }
}