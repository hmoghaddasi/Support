using System.Collections.Generic;
using Framework.Core.Filtering;
using Framework.Core.OnionClass;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IPersonServices : IApplicationService
    {
      
        PersonDTO GetById(int Id);
        PersonDTO GetByUserName(string loginName);
        void Delete(int Id);
        int GetPersonByLogin(string userName);
        FilterResponse<PersonDTO> GetForGrid(GridRequest request, int statusId);
        BaseResponseDTO DeActivateUser(int id);
        ProfileDTO GetProfile(string currentUserName);
        BaseResponseDTO Edit(string currentUserName, ProfileDTO request);
        BaseResponseDTO ValidateUser(int id);
        BaseResponseDTO ActivateUser(int id);
    }
}