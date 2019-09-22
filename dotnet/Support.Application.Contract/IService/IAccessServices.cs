using System.Collections.Generic;
using Framework.Core.Filtering;
using Support.Application.Contract.DTO;

namespace Support.Application.Contract.IService
{
    public interface IAccessServices:IApplicationService
    {
        AccessDTO GetById(int Id);
        string GetAllAccessId(string loginName);
        BaseResponseDTO Create(AccessDTO accessvm);
        void Delete(int Id);
        BaseResponseDTO Edit(AccessDTO accessvm);
        FilterResponse<AccessDTO> GetForGrid(GridRequest request);
        List<PersonAccessDTO> PersonAccess(int id);

    }
}
