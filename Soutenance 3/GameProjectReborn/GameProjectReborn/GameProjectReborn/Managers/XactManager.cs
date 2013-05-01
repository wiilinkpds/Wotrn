using Microsoft.Xna.Framework.Audio;

namespace GameProjectReborn.Managers
{
    public static class XactManager
    {
        public static AudioEngine Engine { get; private set; }
        public static SoundBank SoundBank { get; private set; }
        public static WaveBank WaveBank { get; private set; }

        // SoundEffect
        public static Cue Bolt01 { get; set; }

        // Song
        public static Cue Menu01 { get; set; }
        public static Cue Day01 { get; set; }

        public static Cue CurrentSong { get; set; }

        public static float SongVolume;
        public static float SoundEffectVolume;

        public static void Load()
        {
            Engine = new AudioEngine("Content\\Musique\\GameProjectRebornSound.xgs");
            SoundBank = new SoundBank(Engine, "Content\\Musique\\Sound Bank.xsb");
            WaveBank = new WaveBank(Engine, "Content\\Musique\\Wave Bank.xwb");
        }

        public static void PlaySong(string cue)
        {
            if (CurrentSong != null)
                CurrentSong.Stop(AudioStopOptions.Immediate);
            CurrentSong = SoundBank.GetCue(cue);
            CurrentSong.Play();
        }
    }
}
