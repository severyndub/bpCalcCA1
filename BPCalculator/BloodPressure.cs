using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {

        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Normal Blood Pressure")] Normal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")] High,
        [Display(Name = "Outside of measurable ranges")] Abnormal
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Display(Name = "Systolic blood pressure")]
        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Display(Name = "Diastolic blood presure")]
        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        [Display(Name = "Calculate blood presure")]
        public BPCategory Category
        {
            get
            {
                /*application insight in azure for telemetry
                release as a container or azure app service

               acceptence testing bdd, business tesing tests, can be written in visual studio, automate user input see whats comming back, write selenium tests to simulate this process
                perfromance test in azure portal 50 users over 2 minutes build either in vs or azure, if perfromnce does not meet req hold the release
                */
                if (IsWithinRange(Systolic, 140, 190) && IsWithinRange(Diastolic, 90, 100))
                { return BPCategory.High; }
                else if(IsWithinRange(Systolic, 120, 140) && IsWithinRange(Diastolic, 80, 90))
                { return BPCategory.PreHigh; }
                else if(IsWithinRange(Systolic, 90, 120) && IsWithinRange(Diastolic, 60, 80))
                { return BPCategory.Normal; }
                else if(IsWithinRange(Systolic, 70, 90) && IsWithinRange(Diastolic, 40, 60))
                { return BPCategory.Low; }
                else
                { return BPCategory.Abnormal; }
            }
        }

        /// <summary>
        /// Calculate if blood preasure is within ranges
        /// </summary>
        /// <param name="value">bp value</param>
        /// <param name="minimum">min range</param>
        /// <param name="maximum">max range</param>
        /// <returns></returns>
        public bool IsWithinRange(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }
    }
}
