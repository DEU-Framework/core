using AutoMapper;
using DEU_Backend.DTOs;
using DEU_Lib.Model;
using DEU_Lib.Model.Identity;
namespace DEU_Backend
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            //Department
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();
            //Operation
            CreateMap<Operation, OperationDTO>();
            CreateMap<OperationDTO, Operation>();
            //OperationAction
            CreateMap<OperationAction, OperationActionDTO>();
            CreateMap<OperationActionDTO, OperationAction>();
            //OperationResponse
            CreateMap<OperationResponse, OperationResponseDTO>();
            CreateMap<OperationResponseDTO, OperationResponse>();
            //OperationType
            CreateMap<OperationType, OperationTypeDTO>();
            CreateMap<OperationTypeDTO, OperationType>();
            //OperationSubType
            CreateMap<OperationSubType, OperationSubTypeDTO>();
            CreateMap<OperationSubTypeDTO, OperationSubType>();
            //Poi
            CreateMap<Poi, PoiDTO>();
            CreateMap<PoiDTO, Poi>();
            //Vehicle
            CreateMap<Vehicle, VehicleDTO>();
            CreateMap<VehicleDTO, Vehicle>();
            //VehicleStatus
            CreateMap<VehicleStatus, VehicleStatusDTO>();
            CreateMap<VehicleStatusDTO, VehicleStatus>();
            //WaKaWaterSource
            CreateMap<WaKaWaterSource, WaKaWaterSourceDTO>();
            CreateMap<WaKaWaterSourceDTO, WaKaWaterSource>();
            //ApplicationUser
            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();
            //ApplicationUserDepartmentSetting
            CreateMap<ApplicationUserDepartmentSetting, ApplicationUserDepartmentSettingDTO>();
            CreateMap<ApplicationUserDepartmentSettingDTO, ApplicationUserDepartmentSetting>();
            //UserDepartmentSkill
            CreateMap<UserDepartmentSkill, UserDepartmentSkillDTO>();
            CreateMap<UserDepartmentSkillDTO, UserDepartmentSkill>();
            //UserDepartmentRole
            CreateMap<UserDepartmentRole, UserDepartmentRoleDTO>();
            CreateMap<UserDepartmentRoleDTO, UserDepartmentRole>();
            //Action
            CreateMap<IOperationAction, OperationActionDTO>();
            CreateMap<OperationActionDTO, IOperationAction>();
        }
    }
}