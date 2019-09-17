using System.Collections.Generic;
using System.Linq;
using Framework.Core.Filtering;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
using Support.Application.Mapper;
using Support.Domain.Exception;
using Support.Domain.IRepositories;

namespace Support.Application.Service
{
    public class ResponseService : IResponseService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IResponseRepository _responseRepository;
        private readonly IPersonServices _personService;

        public ResponseService(IRequestRepository requestRepository, IPersonServices personService,
           IResponseRepository responseRepository)
        {
            this._requestRepository = requestRepository;
            this._personService = personService;
            this._responseRepository = responseRepository;
        }
        public BaseResponseDTO Create(ResponseCreateDTO dto, string userName)
        {
            var personId = _personService.GetPersonByLogin(userName);
            _responseRepository.Create(ResponseMapper.MapToModel(dto, personId));
            return BaseResponseHelper.Success();
        }

        public BaseResponseDTO Delete(int responseId, string userName)
        {
            var responseToDelete = _responseRepository.GetById(responseId);
            if (responseToDelete == null)
            {
                throw new ResponseNotFoundException();
            }
            var personId = _personService.GetPersonByLogin(userName);
            if (personId != 0)
            {
                throw new InvalidDataAccessException();
            }
            _responseRepository.Delete(responseId);
            return BaseResponseHelper.Success();
        }

        public List<ResponseDTO> GetAll(int requestId,string userName)
        {

            var personId = _personService.GetPersonByLogin(userName);
            var request = _requestRepository.GetById(requestId);
            if (request == null)
            {
                throw new RequestNotFoundException();
            }

            if (personId != request.RequestById && personId != 0)
            {
                throw new InvalidDataAccessException();
            }
            return _responseRepository.Get(x => x.RequestId == requestId).Select(ResponseMapper.Map).OrderByDescending(d => d.ResponseDate).ToList();

           
        }
    }
}
