using AutoMapper;
using VAMSBSRMApi.Application.Dtos;
using VAMSBSRMApi.Application.Interfaces;
using VAMSBSRMApi.Persistance.Models;

namespace VAMSBSRMApi.Persistance.Services
{
    public class VehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<Employee> _employeeRepository;


        public VehicleService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _vehicleRepository = _unitOfWork.GetRepository<Vehicle>(); // Assuming the unit of work provides this method
            _employeeRepository = _unitOfWork.GetRepository<Employee>();

        }

        //public async Task<VehicleDto> GetVehicleByIdAsync(int id)
        //{
        //    var vehicle = await _vehicleRepository.GetByIdAsync(id);
        //    if (vehicle == null)
        //    {
        //        return null;
        //    }

        //    var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
        //    return vehicleDto;
        //}

        //public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        //{
        //    var vehicles = await _vehicleRepository.GetAllAsync();
        //    var vehicleDtos = _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        //    return vehicleDtos;
        //}

        //public async Task AddVehicleAsync(VehicleDto vehicleDto)
        //{
        //    var vehicle = _mapper.Map<Vehicle>(vehicleDto);
        //    await _vehicleRepository.AddAsync(vehicle);
        //    await _unitOfWork.SaveChangesAsync();
        //}

        //public async Task UpdateVehicleAsync(VehicleDto vehicleDto)
        //{
        //    var vehicle = _mapper.Map<Vehicle>(vehicleDto);
        //    await _vehicleRepository.UpdateAsync(vehicle);
        //    await _unitOfWork.SaveChangesAsync();
        //}


        public async Task<Vehicle> RegisterVehicleAsync(VehicleRegistrationDto vehicleDto)
        {
            // Use IMapper to map DTO to entity
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            vehicle.RegisteredDate = DateTime.Now;

            await _vehicleRepository.AddAsync(vehicle);
            await _unitOfWork.SaveChangesAsync(); // Commit the transaction using UnitOfWork

            return vehicle;
        }

        public async Task<Vehicle?> GetVehicleByIdAsync(int id)
        {
            return await _vehicleRepository.GetByIdAsync(id);
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await _vehicleRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
