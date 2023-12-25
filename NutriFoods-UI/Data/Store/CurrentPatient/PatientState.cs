using Fluxor;
using NutriFoods_UI.Data.Dto;

namespace NutriFoods_UI.Data.Store.CurrentPatient;

[FeatureState]
public class PatientState
{
    public PatientState(PatientDto patient, bool initialized = false)
    {
        Patient = patient;
        Initialized = initialized;
    }
    
    public bool Initialized { get; set; }
    
    public PatientState(){}

    public PatientDto Patient { get; } = new();


}