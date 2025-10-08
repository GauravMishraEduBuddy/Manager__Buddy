using EduBuddyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFacilityService
{
    Task<List<FacilityStatusDto>> GetFacilitiesStatusAsync(int schoolId);
}