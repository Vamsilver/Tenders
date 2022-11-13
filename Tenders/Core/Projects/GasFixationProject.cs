using Tenders.Core.Entities;
using Tenders.Core.Enums;

namespace Tenders.Core.Projects;

public class GasFixationProject : Project
{
    public double PipelineDiameter { get; set; }
    public double ObjectLength { get; set; }
    public double EstimatedCost { get; set; }
    public double DevelopmentTime { get; set; }
    
    public GasFixationProject(string name) : base(name)
    {
        IndustryType = IndustryType.GasFixation; 
        Documents = new List<Document>
        {
            new ("Письмо обращение на имя Президента, Премьер министра, Минстрой РТ", RoleType.Builder, true),
            new ("Задание на проектирование", RoleType.Builder, true),
            new ("Ситуационный план (утвержденный исполкомом)", RoleType.Builder, true),
            new ("Технические условия на присоединение к газораспределительной сети (№, дата, срок действий Технических условий)", RoleType.Builder, true),
            new ("Технический паспорт (план БТИ) объекта СКБ", RoleType.Builder, true),
            new ("Технический паспорт (план БТИ) существующей котельной", RoleType.Builder, true),
            new ("АКТ обследования объекта", RoleType.Builder, true),
            new ("Технические условия на сети электроснабжения, водоснабжения, водоотведения при установке БМК", RoleType.Builder, true),
            new ("Согласование посадки котельной", RoleType.Builder, true),
            new("Смета на ПИР", RoleType.Projector, true),
            new("График проектирования", RoleType.Projector, true)
        };
    }
}