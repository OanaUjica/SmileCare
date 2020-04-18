using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string Dentist { get; set; }
        public string Patient { get; set; }
        public Stage Stage { get; set; }
        public DateTime Date { get; set; }
        public string Employee { get; set; }
        public Category Category { get; set; }
        public Tooth Tooth { get; set; }
        public RestorationType RestorationType { get; set; }
        public Shade Shade { get; set; }
        public bool IsImplant { get; set; }
        public string Comment { get; set; }
    }

    public enum Stage
    {
        Received,
        Accepted,
        Delayed,
        [Display(Name = "Case in Production")]
        CaseInProduction,
        Finished
    }

    public enum Category
    {
        Bridge,
        Removable,
        [Display(Name = "Single Unit")]
        SingleUnit,
        [Display(Name = "Bridge Pontic")]
        BridgePontic,
        [Display(Name = "Bridge Crown")]
        BridgeCrown,
        [Display(Name = "Missing Tooth")]
        MissingTooth
    }

    public enum Tooth
    {
        [Display(Name = "Upper Third Molar")]
        UpperThirdMolar,
        [Display(Name = "Upper Second Molar")]
        UpperSecondMolar,
        [Display(Name = "Upper First Molar")]
        UpperFirstMolar,
        [Display(Name = "Upper Second Premolar")]
        UpperSecondPremolar,
        [Display(Name = "Upper First Premolar")]
        UpperFirstPremolar,
        [Display(Name = "Upper Canine")]
        UpperCanine,
        [Display(Name = "Upper Lateral Incisor")]
        UpperLateralIncisor,
        [Display(Name = "Upper Central Incisor")]
        UpperCentralIncisor,
        [Display(Name = "Lower Third Molar")]
        LowerThirdMolar,
        [Display(Name = "Lower Second Molar")]
        LowerSecondMolar,
        [Display(Name = "Lower First Molar")]
        LowerFirstMolar,
        [Display(Name = "Lower Second Premolar")]
        LowerSecondPremolar,
        [Display(Name = "Lower First Premolar")]
        LowerFirstPremolar,
        [Display(Name = "Lower Canine")]
        LowerCanine,
        [Display(Name = "Lower Lateral Incisor")]
        LowerLateralIncisor,
        [Display(Name = "Lower Central Incisor")]
        LowerCentralIncisor
    }

    public enum RestorationType
    {
        [Display(Name = "Crown Over Natural Abutment")]
        CrownOverNaturalAbutment,
        [Display(Name = "Crown Over Implant")]
        CrownOverImplant,
        [Display(Name = "Corono-Radicular")]
        CoronoRadicular,      
        Veneer,
        Inlay,
        Onlay,
        [Display(Name = "Temporary Single Unit Over Natural Abutment")]
        TemporarySingleUnitOverNaturalAbutment,
        [Display(Name = "Temporary Single Unit Over Natural Implant")]
        TemporarySingleUnitOverNaturalImplant,
        [Display(Name = "Single Unit Wax-Up On Natural Abutment")]
        SingleUnitWaxUpOnNaturalAbutment,
        [Display(Name = "Single Unit Wax-Up On Natural Implant")]
        SingleUnitWaxUpOnNaturalImplant
    }

    public enum Shade
    {
        A1, A2, A3, A35, A4, B1, B2, B3, B4, C1, C2, C3, C4, D2, D3, D4
    }
}
