using System.ComponentModel.DataAnnotations;

namespace Tenders.Core.Enums;

public enum IndustryType
{
    [Display(Name = "Водоснабжение")] WaterSupply,
    [Display(Name = "Газификация")] GasFixation,
    [Display(Name = "Общий")] General
}