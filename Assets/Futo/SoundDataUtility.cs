using UnityEngine;

public static class SoundDataUtility
{
    public static class KeyConfig
    {
        public static class Se
        {
            public static readonly string ButtonMove = "ButtonMove";
            public static readonly string Button = "Button";
            public static readonly string Count = "Count";
            public static readonly string Start = "Start";
            public static readonly string Walk = "Walk";
            public static readonly string Goal = "Goal";
        }

        public static class Bgm
        {
            public static readonly string InGame = "InGame";
            public static readonly string Title = "Title";
        }
    }

    public enum SoundType
    {
        Bgm = 0,
        Se = 1
    }

    public static void PrepareAudioSource(this AudioSource source, SoundData soundData)
    {
        source.playOnAwake = soundData.PlayOnAwake;
        source.volume = soundData.Volume;
        source.loop = soundData.IsLoop;
        source.clip = soundData.Clip;
    }
}
