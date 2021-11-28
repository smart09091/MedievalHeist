using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Infrastructure
{
    public class SettingsPersistence : MonoBehaviour
    {


        public static void saveData(SettingsData data)
        {
            string name = data.GetType().Name;
            PlayerPrefs.SetInt("isSound" + name, Convert.ToInt32(data.isSound));
            PlayerPrefs.SetInt("isVibration" + name, Convert.ToInt32(data.isVibration));


        }



        public static SettingsData getData()
        {
            SettingsData data = new SettingsData();
            string name = data.GetType().Name;
            data.isSound = Convert.ToBoolean(PlayerPrefs.GetInt("isSound" + name, 1));
            data.isVibration = Convert.ToBoolean(PlayerPrefs.GetInt("isVibration" + name, 1));

          

            return data;
        }

    }



}
