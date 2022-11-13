using System.ComponentModel.DataAnnotations;

namespace Tenders.Core.Enums;

public enum RoleType
{
    [Display(Name = "Заказчик")] Customer,
    [Display(Name = "Проектировщик")] Projector,
    [Display(Name = "Застройщик")] Builder,
}