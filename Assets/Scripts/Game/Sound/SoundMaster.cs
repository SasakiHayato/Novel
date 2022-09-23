using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundMaster
{
    public static float MasterVolume { get; private set; }
    public static float BGMVolume { get; private set; }
    public static float SEVolume { get; private set; }

    public static void SetMasterVolume(float volume)
    {
        MasterVolume = volume;
    }

    public static void SetBGMVolume(float volume)
    {
        BGMVolume = volume;
    }

    public static void SetSEVolume(float volume)
    {
        SEVolume = volume;
    }
}
