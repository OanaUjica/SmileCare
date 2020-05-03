using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmileCare.Domain
{
    public class Case
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Dentist is required.")]
        public int DentistId { get; set; }
        public Dentist Dentist { get; set; }

        [Required(ErrorMessage = "Patient is required.")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "Employee is required.")]
        [StringLength(50)]
        public string Employee { get; set; }

        [Required]
        [EnumDataType(typeof(Stage), ErrorMessage = "Please enter a stage.")]
        public Stage? Stage { get; set; }

        [Required]
        [EnumDataType(typeof(Category), ErrorMessage = "Please enter a category.")]
        public Category? Category { get; set; }

        [Required]
        [EnumDataType(typeof(Tooth), ErrorMessage = "Please enter a tooth.")]
        public Tooth? Tooth { get; set; }

        [Required]
        [EnumDataType(typeof(RestorationType), ErrorMessage = "Please enter a restoration type.")]
        [Display(Name = "Restoration Type")]
        public RestorationType? RestorationType { get; set; }

        [Required]
        [EnumDataType(typeof(Shade), ErrorMessage = "Please enter a shade.")]
        public Shade Shade { get; set; }

        [StringLength(5000)]
        public string Comment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        //[DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Implant")]
        public bool IsImplant { get; set; }
       
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
