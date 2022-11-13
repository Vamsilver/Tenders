using Tenders.Core.Enums;
using Tenders.Core.Interfaces;

namespace Tenders.Core.Entities;

public class Projector : User
{
    public string PSRN { get; set; }
    public string TIN { get; set; }
    public string TRRC { get; set; }
    public string Address { get; set; }
    public string Director { get; set; }
    public string MainEngineer { get; set; }
    
    public Projector(string login, string password, string email, RoleType roleType, string phoneNumber, string nickname)
        : base(login, password, email, roleType, phoneNumber)
    {
        PSRN = "Не указано";
        TIN = "Не указано";
        TRRC = "Не указано";
        Address = "Не указано";
        Director = "Не указано";
        MainEngineer = "Не указано";
        NickName = nickname;
    }
    
    public bool CheckTheCompleteAbsenceOfAdditionalData()
    {
        return String.IsNullOrEmpty(PSRN) && String.IsNullOrEmpty(TIN) && String.IsNullOrEmpty(TRRC)
               && String.IsNullOrEmpty(Address) && String.IsNullOrEmpty(Director) && String.IsNullOrEmpty(MainEngineer);
    }
}