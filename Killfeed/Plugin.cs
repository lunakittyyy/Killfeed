using BepInEx;
using UnityEngine;
using HoneyLib.Events;
using System.Text.RegularExpressions;

namespace Killfeed
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        string killFeed = "";
        string latestTag;

        void Start()
        {
            Events.InfectionTagEvent += InfectionTagEvent;
        }

        void OnGUI()
        {
            GUI.Box(new Rect(Screen.width - 320, 20, 300, 200), killFeed);
            if (GUI.Button(new Rect(Screen.width - 70, 235, 50, 30), "Clear"))
            {
                killFeed = "";
            }
        }
        
        void InfectionTagEvent(object sender, InfectionTagEventArgs e)
        {
            latestTag = e.taggingPlayer.NickName + " tagged " + e.taggedPlayer.NickName;
            
            if (Regex.Matches(killFeed, "\n").Count > 10)
            {
                killFeed = latestTag;
            }
            else killFeed = killFeed + "\n" + latestTag;
        }
    }
}