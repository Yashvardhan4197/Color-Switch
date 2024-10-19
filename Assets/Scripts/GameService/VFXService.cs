using UnityEngine;

public class VFXService
{
    private VFXSO fXSO;
    public VFXService(VFXSO data)
    {
        fXSO = data;
    }

    public ParticleSystem GetParticleSystem(ColorStates colorStates)
    {
        /*
        for(int i = 0;i<fXSO.vFXDatas.Length;i++)
        {
            if (fXSO.vFXDatas[i].state == colorStates)
            {
                return fXSO.vFXDatas[i].particleSystem;
            }
        }*/
        return null;
    }

}