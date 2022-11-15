using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Custom_Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Command.Requests;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.Handlers
{
    public class DeleteLeaveTypeRequestHandler : IRequestHandler<DeleteLeaveTypeRequest,BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var leaveType = await _unitOfWork.LeaveTypeRepository.GetAsync(request.Id);

            if (leaveType == null)
            {
                response.Success = false;
                response.Message = "Deleted Failed";
               
            }
                //throw new NotFoundException(nameof(LeaveTypee), request.Id);

            await _unitOfWork.LeaveTypeRepository.DeleteAsync(leaveType);

            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Deleted Successful";
            response.Id = leaveType.Id;

            return response;
        }
        
    }
}
