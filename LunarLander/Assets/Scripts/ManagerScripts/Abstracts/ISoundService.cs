using Assembly_CSharp.Assets.Scripts.EnumScripts;

public interface ISoundService
{
    void PlaySound(SoundManagerTypeEnum soundManagerTypeEnum);
    void StopSound(SoundManagerTypeEnum soundManagerTypeEnum);
}