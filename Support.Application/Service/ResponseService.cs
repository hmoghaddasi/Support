using System.Collections.Generic;
using System.Linq;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.IRepository;

namespace Support.Application.Service
{
   public class ResponseService:IResponseService
    {
        private readonly IResponseRepository _responseRepository;
        private readonly IPersonServices _personService;

        public ResponseService(IResponseRepository responseRepository, IPersonServices personService)
        {
            this._responseRepository = responseRepository;
            this._personService = personService;
        }
        public ResponseDTO GetById(int ResponseId)
        {
            return ResponseMapper.Map(_responseRepository.Get(a => a.ResponseId == ResponseId).First());
        }
        

       //public FilterResponse<ResponseDTO> GetAllFilter(GridRequest request)
       // {
       //     var result = _responseRepository.GetAll().Select(ResponseMapper.Map).AsQueryable();
       //     var data = result.ApplyFilters(request, false);
       //     return new FilterResponse<ResponseDTO>(data.Data, data.Count);
       // }

        public List<ResponseDTO> GetAll()
        {
            return _responseRepository.GetAll().Select(ResponseMapper.Map).ToList();

        }

        public void Delete(int ResponseId)
       {
            _responseRepository.Delete(ResponseId);
        }
        
       public List<ResponseDTO> GetResponseByRequest(int requestId, bool showPrivate)
       {
           return _responseRepository.Get(a => a.RequestId == requestId && (showPrivate
                                               || a.Private == showPrivate))
               .Select(ResponseMapper.Map).ToList();
       }
        

       public void Create(ResponseDTO dto, string userName)
       {
           dto.CreateById = _personService.GetPersonByLogin(userName);
        _responseRepository.Create(ResponseMapper.MapToModel(dto));
        }

    }
}
