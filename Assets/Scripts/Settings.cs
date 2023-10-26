using System;

public class Settings
{
    const string Sound = "sound";
    const string Effects = "effects";

    public void Init()
    {
        if (PlayerPrefs.GetBool("notFirstRun") == false)
        {
            SetIsSoundEnabled(true);
            SetIsEffectsEnabled(true);
            PlayerPrefs.SetBool("notFirstRun",true); 
        }
    }

    public bool GetIsSoundEnabled() => PlayerPrefs.GetBool(Sound);

    public bool GetIsEffectsEnabled() => PlayerPrefs.GetBool(Effects);

    public void SetIsSoundEnabled(bool value)
    {
        PlayerPrefs.SetBool(Sound, value);
        if (value == false) OnSoundDisabled?.Invoke();
        else OnSoundEnabled?.Invoke();
    }

    public void SetIsEffectsEnabled(bool value)
    {
        PlayerPrefs.SetBool(Effects, value); 
        if (value == false) OnEffectsDisabled?.Invoke();
        else OnEffectsEnabled?.Invoke();
    }

    public event Action OnSoundDisabled;
    public event Action OnSoundEnabled;

    public event Action OnEffectsDisabled;
    public event Action OnEffectsEnabled;
}