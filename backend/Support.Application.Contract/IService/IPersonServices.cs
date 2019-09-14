using System.Collections.Generic;
using Framework.Core.Filtering;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IPersonServices : IApplicationService
    {
        bool GetAuthenticated(string loginName, string password);
        bool ChangePassword(string name, string passkey, string newPassword);
        PersonDTO GetById(int Id);
        List<PersonDTO> GetAll(int personTypeId = 0);
        void Delete(int Id);
        int GetCurrentPersonTypeId(string loginName);
        PersonDTO GetByLogin(string name);
        int GetPersonByLogin(string userName);
        FilterResponse<PersonDTO> GetForGrid(GridRequest request);
        BaseResponseDTO DeActivateUser(int id);
        ProfileDTO GetProfile(object currentUserName);
        BaseResponseDTO Edit(object currentUserName, ProfileDTO request);
        BaseResponseDTO ValidateUser(int id);
        BaseResponseDTO ActivateUser(int id);
    }
}