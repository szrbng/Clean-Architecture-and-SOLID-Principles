using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Custom_Exceptions;
using HR.LeaveManagement.Application.DTOs.LeaveTypeDtos.Validators;
using HR.LeaveManagement.Application.Features.LeaveType.Command.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.Handlers
{
    public class UpdateLeaveTypeRequestHandler : IRequestHandler<UpdateLeaveTypeRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveType = await _unitOfWork.LeaveTypeRepository.GetAsync(request.LeaveTypeDto.Id);

            if (leaveType is null)
                throw new NotFoundException(nameof(leaveType), request.LeaveTypeDto.Id);

            _mapper.Map(request.LeaveTypeDto, leaveType);

            await _unitOfWork.LeaveTypeRepository.UpdateAsync(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
