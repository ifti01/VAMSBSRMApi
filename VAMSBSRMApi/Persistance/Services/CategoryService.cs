using AutoMapper;
using VAMSBSRMApi.Application.Dtos;
using VAMSBSRMApi.Application.Interfaces;
using VAMSBSRMApi.Persistance.Models;

namespace VAMSBSRMApi.Persistance.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<VehicleCategory> _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = _unitOfWork.GetRepository<VehicleCategory>();
        }

        public async Task<VehicleCategory?> GetByNameAsync(string name)
        {
            return await _categoryRepository.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<VehicleCategory?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return false; 
            }

            await _categoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync(); 

            return true;
        }


        public async Task<VehicleCategory> CreateCategoryAsync(CreateVehicleCategoryDto categoryDto)
        {
            var category = _mapper.Map<VehicleCategory>(categoryDto);

            await _categoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<VehicleCategory>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

    }
}
