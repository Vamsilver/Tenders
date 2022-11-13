using Tenders.Core.Entities;
using Tenders.Core.Enums;

namespace Tenders.Core.Projects;

public class WaterSupplyProject : Project
{
    public double PipelineDiameter { get; set; }
    public double ObjectLength { get; set; }
    public double PerformanceBiofeedback { get; set; }
    public string NumberAndCapacityOfSewagePumpingStations { get; set; }
    public double EstimatedCost { get; set; }
    public double DevelopmentTime { get; set; }
    
    public WaterSupplyProject(string name) : base(name)
    {
        IndustryType = IndustryType.WaterSupply; 
        Documents = new List<Document>
        {
            new ("Акт обследования и выбора трассы сети водоснабжения", RoleType.Builder, true),
            new ("Акт обследования и выбора места под проектируемую скважину", RoleType.Builder, true),
            new ("Акт обследования и выбор места под проектируемую скважину", RoleType.Builder, true),
            new ("Согласованный ситуационный план (М1:10000 или М1:25000) с нанесением"
                         +" источников воды (скважин, родников и тп.), существующих водонапорных башен,"
                         +"предполагаемой трассой водопровода и места врезки в существующую сеть", 
                RoleType.Builder, true),
            new ("План населённого пункта в М 1:1000 или М 1:500 топографическая съемка",
                RoleType.Builder, true),
            new ("Технические условия на водоснабжение", RoleType.Builder, true),
            new ("Технические условия на электроснабжение (для насосной станции первого" +
                         " или второго подъема)", RoleType.Builder, true),
            new ("Градостроительный план земельного участка", RoleType.Builder, true),
            new ("Справка согласования с собственниками земельных участков", RoleType.Builder, true),
            new ("Подтверждающий проведение межевания с присвоением кадастрового номера"
                         +" земельного участка под строительство водопровода и сооружений на нем", 
                RoleType.Builder, true),
            new ("заключение Органа Роспотребнадзора санитарно-эпидемиологической"
                         +" службы по отводу земельного участка и результат радиационного обследования.",
                RoleType.Builder, true),
            new ("Сведения о наличие водозаборных скважин (родников) на территории хозяйства",
                RoleType.Builder, true),
            new("Смета на ПИР", RoleType.Projector, true),
            new("График проектирования", RoleType.Projector, true)
        };
    }
}