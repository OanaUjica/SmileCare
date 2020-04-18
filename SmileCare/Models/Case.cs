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
        public string Date { get; set; }
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
        UpperThirdMolar,
        UpperSecondMolar,
        UpperFirstMolar,
        UpperSecondPremolar,
        UpperFirstPremolar,
        UpperCanine,
        UpperLateralIncisor,
        UpperCentralIncisor,
        LowerThirdMolar,
        LowerSecondMolar,
        LowerFirstMolar,
        LowerSecondPremolar,
        LowerFirstPremolar,
        LowerCanine,
        LowerLateralIncisor,
        LowerCentralIncisor
    }

    public enum RestorationType
    {
        CrownOverNaturalAbutment,
        CrownOverImplant,
        CoronoRadicular,
        Veneer,
        Inlay,
        Onlay,
        TemporarySingleUnitOverNaturalAbutment,
        TemporarySingleUnitOverNaturalImplant,
        SingleUnitWaxUpOnNaturalAbutment,
        SingleUnitWaxUpOnNaturalImplant
    }

    public enum Shade
    {
        A1, A2, A3, A35, A4, B1, B2, B3, B4, C1, C2, C3, C4, D2, D3, D4
    }
}
